using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;
using Microsoft.AspNetCore.Http;

namespace Csharp_Project.Controllers
{
    public class tbl_orderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Donhang()
        {
            if (HttpContext.Session.GetInt32("_ID") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listo"] = context.GetTbl_Orders();
            return View();
        }
        public IActionResult total_cart()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listo"] = context.GetTbl_OrdersByCusId(Convert.ToInt32(HttpContext.Session.GetInt32("_ID")));
            return View();
        }
        public IActionResult trackingUser(long order_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            return View(context.GetTbl_OrdersById(order_id));
        }
        public JsonResult CapNhatOrder(long order_id, string order_status)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateOrder(order_id, order_status);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
