using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class tbl_customersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string Email, string Password)
        {
            string SessionEmail = "_Email";
            string SessionPassword = "_Password";
            string SessionId = "_ID";
            string SessionName = "_Name";
            string SessionAdress = "_Address";
            string type = "_Type";
            int flag = 0;
            tbl_customers cus;
            tbl_admin ad;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            cus = context.loginUser(Email, Password);
            ad = context.loginAdmin(Email, Password);
            if (ad.Admin_id != 0)
            {
                flag = 1;
            }
            else if (cus.Customer_id != 0)
            {
                flag = 2;
            }
            if (flag == 1)
            {

                HttpContext.Session.SetString(SessionEmail, ad.Admin_email);
                HttpContext.Session.SetString(SessionPassword, ad.Admin_password);
                HttpContext.Session.SetString(SessionName, ad.Admin_name);
                HttpContext.Session.SetString(type, "Admin");
                HttpContext.Session.SetInt32(SessionId, ad.Admin_id);
                ViewData["thongbao"] = "Login thành công admin";
                return RedirectToAction("ProList", "tbl_product");
            }
            else if (flag == 2)
            {
                HttpContext.Session.SetString(SessionEmail, cus.Customer_email);
                HttpContext.Session.SetString(SessionPassword, cus.Customer_password);
                HttpContext.Session.SetString(SessionName, cus.Customer_name);
                HttpContext.Session.SetString(SessionAdress, cus.Customer_address);
                HttpContext.Session.SetString(type, "Customer");
                HttpContext.Session.SetInt32(SessionId, cus.Customer_id);
                ViewData["thongbao"] = "Login thành công customer";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewData["thongbao"] = "Sai thông tin đăng nhập";
                return View();
            }

        }
        [HttpGet]
        public IActionResult register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult register(tbl_customers cs)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            count = context.InsertUser(cs);
            if (count > 0)
            {
                ViewData["thongbao"] = "Đăng ký thành công";
                ViewBag.JavaScriptFunction = string.Format("open()");
                return View();

            }
            else if (count < 0)
            {
                return View();
            }
            else
            {
                ViewData["thongbao"] = "Email đã được sử dụng";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult hoso()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("_ID"));
            return View(context.GetCustomersById(id));
        }
        public JsonResult CapNhatCustomer(int customer_id, string customer_name, string customer_phone, string customer_address)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateCustomer(customer_id, customer_name, customer_phone, customer_address);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
