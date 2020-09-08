using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_mobile.Controllers
{
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult HeroList()
        {
            return View();
        }
    }
}