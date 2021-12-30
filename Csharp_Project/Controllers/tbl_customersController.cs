using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Csharp_Project.Models;
namespace Csharp_Project.Controllers
{
    public class tbl_customersController : Controller
    {
        StoreContext storeContext = new StoreContext();
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
            string type ="_Type";
            int flag = 0;
            tbl_customers cus;
            tbl_admin ad;
            tbl_shipping ship;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            cus = context.loginUser(Email, Password);
            ad = context.loginAdmin(Email, Password);
            ship = context.loginShipping(Email, Password);
            if (ad.Admin_id != 0)
            {
                flag = 1;
            }else if(cus.Customer_id != 0)
            {
                flag = 2;
            }
            else if (ship.Shipping_id != 0)
            {
                flag = 3;
            }
            if (flag == 1)
            {
                
                HttpContext.Session.SetString(SessionEmail, ad.Admin_email);
                HttpContext.Session.SetString(SessionPassword, ad.Admin_password);
                HttpContext.Session.SetString(SessionName, ad.Admin_name);
                HttpContext.Session.SetString(type, "Admin");
                HttpContext.Session.SetInt32(SessionId, ad.Admin_id);
                ViewData["thongbao"] = "Login thành công admin";
                return RedirectToAction("demo2");
            }
             else if (flag==2)
            {
              
                HttpContext.Session.SetString(SessionEmail, cus.Customer_email);
                HttpContext.Session.SetString(SessionPassword, cus.Customer_password);
                HttpContext.Session.SetString(SessionName, cus.Customer_name);
                HttpContext.Session.SetString(type, "Customer");
                HttpContext.Session.SetInt32(SessionId, cus.Customer_id);
                ViewData["thongbao"] = "Login thành công customer"; 
                return View("~/Views/Home/Index.cshtml");


            }
            else if (flag == 3)
            {
               
                HttpContext.Session.SetString(SessionEmail, ship.Shipping_email);
                HttpContext.Session.SetString(SessionName, ship.Shipping_name);
                HttpContext.Session.SetString(SessionPassword, ship.Shipping_password);
                HttpContext.Session.SetString(type, "Shipper");
                HttpContext.Session.SetInt32(SessionId, ship.Shipping_id);
                ViewData["thongbao"] = "Login thành công shipper";
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
                ViewData["thongbao"] = "Đăng ký không thành công";
                return View();
            }
            else
            {
                ViewData["thongbao"] = "Email đã được sử dụng";
                return View();
            }
        }
        public IActionResult demo(tbl_customers cs )
        {
           
            return View();
        }
        public IActionResult demo2(tbl_customers cs)
        {
            
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
