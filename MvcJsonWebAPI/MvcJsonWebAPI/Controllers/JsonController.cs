using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJsonWebAPI.Models;

namespace MvcJsonWebAPI.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LineTemperatureJSON()
        {
            //1.Label
            string[] Labels = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };

            //序列化成為JSON物件結構字串
            string jsonLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Labels);

            //以ViewBag將資料傳給View
            ViewBag.JsonLabels = jsonLabels;

            //2.List集合包含台北,台中及高雄三個地方的氣溫資料
            List<Location> Locations = new List<Location>
            {
                new Location{
                    City="台北",
                    Temperature = new double[] { 16.1, 16.5, 18.5, 21.9, 25.2, 27.7, 29.6, 29.2, 27.4, 24.5, 21.5, 17.9 }
                },
                new Location{
                    City="台中",
                    Temperature = new double[] {16.6, 17.3, 19.6, 23.1, 26.0, 27.6, 28.6, 28.3, 27.4, 25.2, 21.9, 18.1}

                },
                new Location{
                    City="高雄",
                    Temperature = new double[]{19.3, 20.3, 22.6, 25.4, 27.5, 28.5, 29.2, 28.7, 28.1, 26.7, 24.0, 20.6 }
                }
            };

            //將List集合序列化成為JSON物件結構字串
            string JsonLocations = Newtonsoft.Json.JsonConvert.SerializeObject(Locations);
            //以ViewBag將資料傳給View
            ViewBag.JsonLocations = JsonLocations;
            
            return View(Locations);
        }

        public ActionResult TemperatureAjaxJSON()
        {
            return View();
        }

        public ActionResult CarSalesAjaxJSON()
        {
            return View();
        }


        //介紹.post(), .get(), getJSON()三種方法
        public ActionResult CarSalesAjax3JSON()
        {
            return View();
        }
    }
}