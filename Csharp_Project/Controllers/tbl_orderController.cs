using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;

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
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listo"] = context.GetTbl_Orders();
            return View();
        }
        public JsonResult CapNhatOrder(int order_id, string order_status)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateOrder(order_id, order_status);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
