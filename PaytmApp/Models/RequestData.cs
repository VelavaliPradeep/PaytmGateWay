using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaytmApp.Models
{
    public class RequestData
    {
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
    }
}