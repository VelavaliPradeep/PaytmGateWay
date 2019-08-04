using paytm;
using PaytmApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaytmApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePayment(RequestData data)
        {
            String merchantKey = PaytmTest.merchantKey ;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", PaytmTest.merchantId);
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL", data.Email);
            parameters.Add("MOBILE_NO", data.MobileNumber);
            parameters.Add("CUST_ID", "22");
            parameters.Add("ORDER_ID", "abcdefghijklmnodfdfdsfp");
            parameters.Add("TXN_AMOUNT", data.Amount);
            parameters.Add("CALLBACK_URL", "https://merchant.com/callback/"); //This parameter is not mandatory. Use this to pass the callback url dynamically.

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction?orderid=" + parameters.FirstOrDefault(x=> x.Key == "ORDER_ID").Value;


            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);

            ViewBag.htmldata = outputHTML;

            return View("PaymentPage");
        }

        [HttpPost]
        public ActionResult PaytmResponse(PaytmResponse data)
        {
            return View("PaytmResponse", data);
        }
    }
}