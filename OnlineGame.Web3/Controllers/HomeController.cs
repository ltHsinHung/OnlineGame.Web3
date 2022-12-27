using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineGame.Web3.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            ViewBag.Names = new List<string>
{
"ViewBag.Names01",
"ViewBag.Names02",
"ViewBag.Names03"
};
            ViewData["Names2"] = new List<string>
{
"ViewData[\"Names\"]01",
"ViewData[\"Names\"]02",
"ViewData[\"Names\"]03"
};
            return View();
        }

    }
}
