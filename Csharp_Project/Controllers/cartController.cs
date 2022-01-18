using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class cartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ThemCart(int customer_id, int product_id, int cart_quantity, string cart_price)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.InsertCart(customer_id, product_id, cart_quantity, cart_price);
            if(count > 0)
            {
                return Json(1);
            }
            if(count == -1)
            {
                return Json(-1);
            }
            return Json(0);
        }
        public IActionResult cart(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            List<object> list = context.Getcart(id);
            ViewData["listc"] = list;
            ViewData["check"] = list.Count;
            return View();
        }
        public JsonResult XoaCart(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.DeleteCart(id);
            if(count > 0)
            {
                return Json(1);
            }
            return Json(0);
        }
        public JsonResult XoaAllCart(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.DeleteAllCart(id);
            if (count > 0)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}
