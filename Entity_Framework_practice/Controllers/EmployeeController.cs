using Entity_Framework_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Entity_Framework_practice.Controllers
{
    public class EmployeeController : Controller
    {
        private CmsContext db = new CmsContext();     //Context環境，用來對資料庫作存取
    
     /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        public ActionResult Index()                   // 網頁1
        {
            var emps = db.Employees.ToList();        //從資料庫讀取資料，建立model，讀取Employee，並轉換為List集合

            return View(emps);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Details(int? Id)       //網頁2(需透過網頁1連線) //  可以https://localhost:44386/Employee/Detail  或者 帶有Id  hhttps://localhost:44386/Employee/Detail/152
        {

            if (Id == null)                         //檢查是否有員工Id的判斷
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Employee emp = db.Employees.Find(Id);    //以Id找尋員工資料


            if (emp == null)                        //如果沒有找到員工，回傳HttpNotFound
            {
                return HttpNotFound();
            }

            return View(emp);


        }

         ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Create()                   //網頁3//負責GET
        {
            return View();
        }

       //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]                                         //負責POS
        [ValidateAntiForgeryToken]                       //防止跨網站偽造請求攻擊
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)   //Bind用來防止over-pasting攻擊指定的欄位
        {
            
            if (ModelState.IsValid)                                   //用ModelState.IsValid判斷資料是否通過驗證
            {
               
                db.Employees.Add(emp);                               //通過驗證,將資料異動儲存到資料庫
                db.SaveChanges();                                    //儲存完成後，導向Index動作法方
              
                return RedirectToAction("Index");                   //若未通過驗證, 再次返回顯示Form表單,直到資料提交完全正確
            }

            return View(emp);
        }

 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Edit(int? Id)
        {
           
            if (Id == null)                                          //檢查是否有員工Id的判斷
            {
                return Content("查無此資料, 請提供員工編號!");
            }
            
            Employee emp = db.Employees.Find(Id);                   //以Id找尋員工資料
            
            if (emp == null)                                       //如果沒有找到員工，回傳HttpNotFound
            {
                return HttpNotFound();
            }
            return View(emp);
        }
    
     /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        [HttpPost]                                                   //負責POS
        [ValidateAntiForgeryToken]                                  //防止跨網站偽造請求攻擊
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)  //Bind用來防止over-pasting攻擊指定的欄位
        {
            
            if (ModelState.IsValid)                              //用ModelState.IsValid判斷資料是否通過驗證
            {
                
                
                db.Entry(emp).State = EntityState.Modified;        //將emp這個Entity狀態設為Modified,
                db.SaveChanges();                                  //當SaveChanges()執行時,會向SQL Server發出Update陳述式命令
                return RedirectToAction("Index");
            }

            return View(emp);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Delete(int? Id)
        {
           
            if (Id == null)                                                   //檢查是否有員工Id
            {
                return Content("查無此資料, 請提供員工編號!");
            }
           
            Employee emp = db.Employees.Find(Id);                             //以Id找尋員工資料
             
            if (emp == null)                                                  //如果沒有找到員工，回傳HttpNotFound
            {
                return HttpNotFound();
            }

            return View(emp);
        }
     
      /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            
            Employee emp = db.Employees.Find(Id);                        //以Id找尋Entity，然後刪除
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

