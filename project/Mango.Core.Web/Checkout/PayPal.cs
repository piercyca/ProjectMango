using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;
using System.Globalization;

namespace Mango.Core.Web.Checkout
{
    /// <summary>
    /// 
    /// </summary>
    public class PayPalNvpApiCaller
    {
        //Flag that determines the PayPal environment (live or sandbox)
        private bool _isSandbox = true;
        private const string _cvv2 = "CVV2";

        // Live strings.
        private string _pEndPointUrl = "https://api-3t.paypal.com/nvp";
        private string _host = "www.paypal.com";

        // Sandbox strings.
        private string _pEndPointUrl_sb = "https://api-3t.sandbox.paypal.com/nvp";
        private string _host_sb = "www.sandbox.paypal.com";

        private const string SIGNATURE = "SIGNATURE";
        private const string PWD = "PWD";
        private const string ACCT = "ACCT";

        private string _currencyCode = "USD";
        private string _brandName = "Demo Application";

        //Replace <Your API Username> with your API Username
        //Replace <Your API Password> with your API Password
        //Replace <Your Signature> with your Signature
        public string _apiUsername = "pratbhoir-facilitator_api1.gmail.com";
        private string _apiPassword = "DCTGXU9ZWVS9CTUL";
        private string _apiSignature = "ASiWpfHTWg61XkqgJfyT8KushkN.AKoCgc3aXcwG2bYCBQ3g-epq82hx";
        private string _subject = "";
        private string _bnCode = "PP-ECWizard";

        private string _returnUrl = "http://localhost:55069/Payment/CheckoutReview";
        private string _cancelUrl = "http://localhost:55069/Payment/CheckoutCancel";

        //HttpWebRequest Timeout specified in milliseconds 
        private const int Timeout = 15000;
        private static readonly string[] SECURED_NVPS = new string[] { ACCT, _cvv2, SIGNATURE, PWD };

        /// <summary>
        /// Constructor
        /// </summary>
        public PayPalNvpApiCaller()
        {
            var appSettings = ConfigurationManager.AppSettings;

            _isSandbox = Convert.ToBoolean(appSettings["PayPal:IsSandbox"]);
            _apiUsername = appSettings["PayPal:APIUsername"];
            _apiPassword = appSettings["PayPal:APIPassword"];
            _apiSignature = appSettings["PayPal:APISignature"];
            _currencyCode = appSettings["PayPal:CurrencyCode"];
            _brandName = appSettings["PayPal:BrandName"];
            _returnUrl = appSettings["PayPal:ReturnURL"];
            _cancelUrl = appSettings["PayPal:CancelURL"];
        }


        public void SetCredentials(string userId, string password, string signature)
        {
            _apiUsername = userId;
            _apiPassword = password;
            _apiSignature = signature;
        }

        public bool ShortcutExpressCheckout(PaypalModel model, ref string token, ref string retMsg)
        {
            if (_isSandbox)
            {
                _pEndPointUrl = _pEndPointUrl_sb;
                _host = _host_sb;
            }

            PayPalNvpCodec encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = _returnUrl;
            encoder["CANCELURL"] = _cancelUrl;
            encoder["BRANDNAME"] = _brandName;
            encoder["PAYMENTREQUEST_0_AMT"] = model.TotalAmount.ToString(CultureInfo.InvariantCulture);
            encoder["PAYMENTREQUEST_0_ITEMAMT"] = model.TotalAmount.ToString(CultureInfo.InvariantCulture);
            encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
            encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = _currencyCode;

            //// Get the Shopping Cart Products
            //using (WingtipToys.Logic.ShoppingCartActions myCartOrders = new WingtipToys.Logic.ShoppingCartActions())
            //{
            //    List<CartItem> myOrderList = myCartOrders.GetCartItems();

            //    for (int i = 0; i < myOrderList.Count; i++)
            //    {
            //        encoder["L_PAYMENTREQUEST_0_NAME" + i] = myOrderList[i].Product.ProductName.ToString();
            //        encoder["L_PAYMENTREQUEST_0_AMT" + i] = myOrderList[i].Product.UnitPrice.ToString();
            //        encoder["L_PAYMENTREQUEST_0_QTY" + i] = myOrderList[i].Quantity.ToString();
            //    }
            //}

            for (int i = 0; i < model.Cart.Count; i++)
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + i] = model.Cart[i].ProductName.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + i] = model.Cart[i].UnitPrice.ToString();
                encoder["L_PAYMENTREQUEST_0_QTY" + i] = model.Cart[i].Quantity.ToString();
            }

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            PayPalNvpCodec decoder = new PayPalNvpCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                token = decoder["TOKEN"];
                string ECURL = string.Format("https://{0}/cgi-bin/webscr?cmd=_express-checkout" + "&token={1}", _host, token);
                retMsg = ECURL;
                return true;
            }
            retMsg = string.Format("ErrorCode={0}&Desc={1}&Desc2={2}", decoder["L_ERRORCODE0"], decoder["L_SHORTMESSAGE0"], decoder["L_LONGMESSAGE0"]);
            return false;
        }

        public bool GetCheckoutDetails(string token, ref string payerId, ref PayPalNvpCodec decoder, ref string retMsg)
        {
            if (_isSandbox)
            {
                _pEndPointUrl = _pEndPointUrl_sb;
            }

            PayPalNvpCodec encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "GetExpressCheckoutDetails";
            encoder["TOKEN"] = token;

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            decoder = new PayPalNvpCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                payerId = decoder["PAYERID"];
                return true;
            }
            else
            {
                retMsg = string.Format("ErrorCode={0}&Desc={1}&Desc2={2}", decoder["L_ERRORCODE0"], decoder["L_SHORTMESSAGE0"], decoder["L_LONGMESSAGE0"]);

                return false;
            }
        }

        public bool DoCheckoutPayment(string finalPaymentAmount, string token, string payerId, ref PayPalNvpCodec decoder, ref string retMsg)
        {
            if (_isSandbox)
            {
                _pEndPointUrl = _pEndPointUrl_sb;
            }

            PayPalNvpCodec encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "DoExpressCheckoutPayment";
            encoder["TOKEN"] = token;
            encoder["PAYERID"] = payerId;
            encoder["PAYMENTREQUEST_0_AMT"] = finalPaymentAmount;
            encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "USD";
            encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            decoder = new PayPalNvpCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                return true;
            }

            retMsg = string.Format("ErrorCode={0}&Desc={1}&Desc2={2}", decoder["L_ERRORCODE0"], decoder["L_SHORTMESSAGE0"], decoder["L_LONGMESSAGE0"]);

            return false;
        }

        public string HttpCall(string nvpRequest)
        {
            string url = _pEndPointUrl;

            string strPost = nvpRequest + "&" + BuildCredentialsNvpString();
            strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(_bnCode);

            var objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Timeout = Timeout;
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            
            //If proxy is needed to connect to internet
            //IWebProxy proxy = new WebProxy("10.1.1.253", 3128); // port number is of type integer 
            //proxy.Credentials = new NetworkCredential("pratikb", "wall1!crew");
            //objRequest.Proxy = proxy;

            try
            {
                using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(strPost);
                }
            }
            catch (Exception)
            {
                // No logging for this tutorial.
            }

            string result;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    //var uri = Util.getServiceUri("myservice");
            //    var response = httpClient.GetAsync(uri, cancelToken);
            //}
            //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            //{
            //    result = sr.ReadToEnd();
            //}

            //Retrieve the Response returned from the NVP API call to PayPal.
            var objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        private string BuildCredentialsNvpString()
        {
            PayPalNvpCodec codec = new PayPalNvpCodec();

            if (!IsEmpty(_apiUsername))
                codec["USER"] = _apiUsername;

            if (!IsEmpty(_apiPassword))
                codec[PWD] = _apiPassword;

            if (!IsEmpty(_apiSignature))
                codec[SIGNATURE] = _apiSignature;

            if (!IsEmpty(_subject))
                codec["SUBJECT"] = _subject;

            codec["VERSION"] = "88.0";

            return codec.Encode();
        }

        private static bool IsEmpty(string s)
        {
            return s == null || s.Trim() == string.Empty;
        }
    }

    public sealed class PayPalNvpCodec : NameValueCollection
    {
        private const string AMPERSAND = "&";
        private const string EQUALS = "=";
        private static readonly char[] AMPERSAND_CHAR_ARRAY = AMPERSAND.ToCharArray();
        private static readonly char[] EQUALS_CHAR_ARRAY = EQUALS.ToCharArray();

        public string Encode()
        {
            var sb = new StringBuilder();
            var firstPair = true;
            foreach (var kv in AllKeys)
            {
                var name = HttpUtility.UrlEncode(kv);
                var value = HttpUtility.UrlEncode(this[kv]);
                if (!firstPair)
                {
                    sb.Append(AMPERSAND);
                }
                sb.Append(name).Append(EQUALS).Append(value);
                firstPair = false;
            }
            return sb.ToString();
        }

        public void Decode(string nvpstring)
        {
            Clear();
            foreach (string nvp in nvpstring.Split(AMPERSAND_CHAR_ARRAY))
            {
                string[] tokens = nvp.Split(EQUALS_CHAR_ARRAY);
                if (tokens.Length >= 2)
                {
                    string name = HttpUtility.UrlDecode(tokens[0]);
                    string value = HttpUtility.UrlDecode(tokens[1]);
                    Add(name, value);
                }
            }
        }

        public void Add(string name, string value, int index)
        {
            Add(GetArrayName(index, name), value);
        }

        public void Remove(string arrayName, int index)
        {
            Remove(GetArrayName(index, arrayName));
        }

        public string this[string name, int index]
        {
            get
            {
                return this[GetArrayName(index, name)];
            }
            set
            {
                this[GetArrayName(index, name)] = value;
            }
        }

        private static string GetArrayName(int index, string name)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", string.Format("index cannot be negative : {0}", index));
            }
            return name + index;
        }
    }
}
