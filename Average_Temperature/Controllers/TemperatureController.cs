using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Average_Temperature.Models;

namespace Average_Temperature.Controllers
{
    public class TemperatureController : Controller
    {
        // GET: Temperature
        public ActionResult Temperaature()
        {
            string[] labels = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };  //C#字串陣列

            ViewBag.in_label = labels;                                                                                    //別忘記丟Controller物件到view要用三方法之一

            List<TemperatureModel> My_Temperature = new List<TemperatureModel>                                              //C#泛型
                                                                                                                          // 別忘記new、並以model型態填值
            {
                new TemperatureModel                                                                                       //資料  1
                {
                    City = "台北",
                    Temperature = new double[]{ 10.1, 10.9, 13.0, 16.4, 19.4, 21.8, 23.2, 22.9, 21.0, 17.9, 14.9, 11.4 }
                },                                                                                                         //要以逗點區隔

                new TemperatureModel
                {
                    City = "台中",
                    Temperature = new double[]{ 19.5, 20.0, 21.8, 24.1, 26.2, 27.8, 28.9, 28.7, 27.5, 25.7, 23.3, 20.5 }    //資料  2
                },

                new TemperatureModel
                {
                    City = "高雄",
                    Temperature = new double[]{ 19.5, 20.0, 21.8, 24.1, 26.2, 27.8, 28.9, 28.7, 27.5, 25.7, 23.3, 20.5 }    //資料  3
                }



            };
    
            return View(My_Temperature);                                                                                    //最後丟入所創模型 物件 物件 是物件喔 
        }
    }
}