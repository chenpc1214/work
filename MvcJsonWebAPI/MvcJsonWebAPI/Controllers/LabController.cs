using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJsonWebAPI.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace MvcJsonWebAPI.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            //C#字串陣列
            string[] Months = { "1月", "2月", "3月", "4月", "5月", "6月" };

            //C#集合
            List<Employee> Employees = new List<Employee>
            {
                new Employee { Id=1, Name="Kevin", Department="RD" },
                new Employee { Id=2, Name="David", Department="HR" },
                new Employee { Id=3, Name="Mary", Department="Sales" },
            };

            //將C#陣列與集合編碼成JSON格式字串
            string jsonMonths = JsonConvert.SerializeObject(Months);
            string jsonEmployees = JsonConvert.SerializeObject(Employees);

            //傳遞JSON字串到Razor View
            ViewBag.JsonMonths = jsonMonths;
            ViewBag.JsonEmployees = jsonEmployees;

            return View(Employees);
        }


        public ActionResult JsonMD5()
        {
            string message = @"This is a string MD5 demo.";
            MD5 md5 = MD5.Create();//建立一個MD5
            byte[] data = Encoding.Default.GetBytes(message);//將字串轉為Byte[]
            byte[] md5Hashcode = md5.ComputeHash(data);//進行MD5加密

            //用StringBuilder將陣列元素逐一加入
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Hashcode.Length; i++)
            {
                //用.ToString("x2")轉成16進位Literal帳面值
                sb.Append(md5Hashcode[i].ToString("x2"));
            }

            string md5String = sb.ToString();

            ViewBag.Md5String = md5String;

            return View();
        }
    }
}