﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mango.Core.Web.Helpers
{
    public class UserSessionData
    {

        //Session variable constants
        private const string PAYPALEMAIL = "PayPalEmail";
        private const string TOKEN = "Token";
        private const string PAYMENTAMOUNT = "PaymentAmount";
        private const string PAYERID = "PayerID";

        private const string ORDERID = "OrderID";


        public static T Read<T>(string variable)
        {
            object value = System.Web.HttpContext.Current.Session[variable];
            if (value == null)
                return default(T);
            else
                return ((T)value);
        }

        public static void Write(string variable, object value)
        {
            HttpContext.Current.Session[variable] = value;
        }

        public static string PayPalEmail
        {
            get { return Read<string>(PAYPALEMAIL); }
            set { Write(PAYPALEMAIL, value); }
        }

        public static string Token
        {
            get { return Read<string>(TOKEN); }
            set { Write(TOKEN, value); }
        }

        public static decimal PaymentAmount
        {
            get { return Read<decimal>(PAYMENTAMOUNT); }
            set { Write(PAYMENTAMOUNT, value); }
        }

        public static string PayerID
        {
            get { return Read<string>(PAYERID); }
            set { Write(PAYERID, value); }
        }

        public static int OrderId
        {
            get { return Read<int>(ORDERID); }
            set { Write(ORDERID, value); }
        }

    }
}