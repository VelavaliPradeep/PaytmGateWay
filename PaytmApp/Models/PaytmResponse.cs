using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaytmApp.Models
{
    public class PaytmResponse
    {
        public int MID { get; set; }
        public int ORDERID { get; set; }
        public int TXNAMOUNT { get; set; }
        public int CURRENCY { get; set; }
        public int TXNID { get; set; }
        public int BANKTXNID { get; set; }
        public int STATUS { get; set; }
        public int RESPCODE { get; set; }
        public int RESPMSG { get; set; }
        public int TXNDATE { get; set; }
        public int GATEWAYNAME { get; set; }
        public int BANKNAME { get; set; }
        public int PAYMENTMODE { get; set; }
        public int CHECKSUMHASH { get; set; }

    }
}