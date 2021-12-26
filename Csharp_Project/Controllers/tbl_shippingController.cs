using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class tbl_shippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CusList()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Lists"] = context.GetTbl_Shippings();
            return View();
        }
        public JsonResult CapNhatShipping(int shipping_id, string shipping_notes)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateShipping(shipping_id, shipping_notes);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
