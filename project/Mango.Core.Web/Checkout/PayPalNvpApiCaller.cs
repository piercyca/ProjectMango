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
        #region Properties

        //Flag that determines the PayPal environment (live or sandbox)
        private static bool _isSandbox { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["PayPal:IsSandbox"]); } }
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

        private string _currencyCode { get { return ConfigurationManager.AppSettings["PayPal:CurrencyCode"]; } }
        private string _brandName { get { return ConfigurationManager.AppSettings["PayPal:BrandName"]; } }

        //Replace <Your API Username> with your API Username
        //Replace <Your API Password> with your API Password
        //Replace <Your Signature> with your Signature
        public static string _apiUsername { get { return ConfigurationManager.AppSettings["PayPal:APIUsername"]; } }
        private static string _apiPassword { get { return ConfigurationManager.AppSettings["PayPal:APIPassword"]; } }
        private static string _apiSignature { get { return ConfigurationManager.AppSettings["PayPal:APISignature"]; } }
        private string _subject = "";
        private string _bnCode = "PP-ECWizard";

        private string _returnUrl { get { return ConfigurationManager.AppSettings["PayPal:ReturnURL"]; } }
        private string _cancelUrl { get { return ConfigurationManager.AppSettings["PayPal:CancelURL"]; } }

        //HttpWebRequest Timeout specified in milliseconds 
        private const int Timeout = 15000;
        private static readonly string[] SECURED_NVPS = new string[] { ACCT, _cvv2, SIGNATURE, PWD };

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PayPalNvpApiCaller()
        {
        }

        public bool ShortcutExpressCheckout(PaypalCartModel cartModel, string amt, ref string token, ref string retMsg)
        {
            int i;

            if (_isSandbox)
            {
                _pEndPointUrl = _pEndPointUrl_sb;
                _host = _host_sb;
            }

            var encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = _returnUrl;
            encoder["CANCELURL"] = _cancelUrl;
            encoder["BRANDNAME"] = "NCIRL Web Store";
            encoder["PAYMENTREQUEST_0_AMT"] = amt;
            encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt;
            encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
            encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = _currencyCode;

            i = 0;
            foreach (var line in cartModel.CartItems)
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + i] = line.ProductName;
                encoder["L_PAYMENTREQUEST_0_AMT" + i] = line.Amount.ToString(CultureInfo.InvariantCulture);
                encoder["L_PAYMENTREQUEST_0_QTY" + i] = line.Quantity.ToString();
                i++;
            }

            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = HttpCall(pStrrequestforNvp);

            var decoder = new PayPalNvpCodec();
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

            var encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "GetExpressCheckoutDetails";
            encoder["TOKEN"] = token;

            var pStrrequestforNvp = encoder.Encode();
            var pStresponsenvp = HttpCall(pStrrequestforNvp);

            decoder = new PayPalNvpCodec();
            decoder.Decode(pStresponsenvp);

            var strAck = decoder["ACK"].ToLower();
            if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
            {
                payerId = decoder["PAYERID"];
                return true;
            }
            retMsg = string.Format("ErrorCode={0}&Desc={1}&Desc2={2}", decoder["L_ERRORCODE0"], decoder["L_SHORTMESSAGE0"], decoder["L_LONGMESSAGE0"]);
            return false;
        }

        public bool DoCheckoutPayment(string finalPaymentAmount, string token, string payerId, ref PayPalNvpCodec decoder, ref string retMsg)
        {
            if (_isSandbox)
            {
                _pEndPointUrl = _pEndPointUrl_sb;
            }

            var encoder = new PayPalNvpCodec();
            encoder["METHOD"] = "DoExpressCheckoutPayment";
            encoder["TOKEN"] = token;
            encoder["PAYERID"] = payerId;
            encoder["PAYMENTREQUEST_0_AMT"] = finalPaymentAmount;
            encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "EUR";
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

            string strPost = string.Format("{0}&{1}", nvpRequest, BuildCredentialsNvpString());
            strPost = string.Format("{0}&BUTTONSOURCE={1}", strPost, HttpUtility.UrlEncode(_bnCode));

            var objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Timeout = Timeout;
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;

            try
            {
                using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(strPost);
                }
            }
            catch (Exception e)
            {
                // Log the exception.
                //TODO ExceptionUtility.LogException(e, "HttpCall in PayPalFunction.cs");
            }


            //Retrieve the Response returned from the NVP API call to PayPal.
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string result;
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        private string BuildCredentialsNvpString()
        {
            var codec = new PayPalNvpCodec();

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

        public static bool IsEmpty(string s)
        {
            return s == null || s.Trim() == string.Empty;
        }
    }

    
}
