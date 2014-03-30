using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleStripeExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            return View("Payment");
        }

        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            string apiKey = "your-test-secret-key";
            var stripeClient = new Stripe.StripeClient(apiKey);

            dynamic response = stripeClient.CreateChargeWithToken(2500, stripeToken, "GBP", stripeEmail);

            if (response.IsError == false && response.Paid)
            {
                // success
            }

            return View("Payment");

        }

    }
}
