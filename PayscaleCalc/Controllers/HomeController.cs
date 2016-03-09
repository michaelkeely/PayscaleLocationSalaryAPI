using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayscaleCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string city, string state, string title)
        {
            var payscaleClient = new PayscaleClient(title, city, state);

            return View(payscaleClient.GetPayscale());
        }
    }
}
