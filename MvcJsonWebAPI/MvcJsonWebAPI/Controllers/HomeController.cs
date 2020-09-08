using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcJsonWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestViewBag()
        {
            var person = new { Name = "Kevin", City="Taipei", Phone="0933-155-226"};
            ViewBag.Person = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            ViewBag.Man = Json(person);
            ViewBag.Name = "Kevin";
            return View();
        }
    }
}