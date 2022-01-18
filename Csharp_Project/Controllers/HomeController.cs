using Csharp_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Csharp_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_Products();
            ViewData["Listc"] = context.GetTbl_Category_Products_Home();
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email, string Password)
        {
            string SessionEmail = "_Email";
            string SessionPassword = "_Password";
            string SessionId = "_ID";
            string SessionName = "_Name";
            string type = "_Type";
            string SessionAdress = "_Address";
            int flag = 0;
            tbl_customers cus;
            tbl_admin ad;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_Products();
            ViewData["Listc"] = context.GetTbl_Category_Products_Home();
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
                HttpContext.Session.SetString(SessionAdress, cus.Customer_address);
                HttpContext.Session.SetString(SessionPassword, cus.Customer_password);
                HttpContext.Session.SetString(SessionName, cus.Customer_name);
                HttpContext.Session.SetString(type, "Customer");
                HttpContext.Session.SetInt32(SessionId, cus.Customer_id);
                ViewData["thongbao"] = "Login thành công customer";
                return View("~/Views/Home/Index.cshtml");


            }
            else
            {
                ViewData["thongbao"] = "Sai thông tin đăng nhập";
                return RedirectToAction("login", "tbl_customers");
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
