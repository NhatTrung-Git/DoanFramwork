using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class tbl_order_detailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult payment(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["listc"] = context.Getcart(id);
            ViewData["listv"] = context.GetTbl_voucher();
            return View();
        }
        [HttpPost]
        public JsonResult DatHang(int customer_id, int voucher_id, string order_total, string order_address, List<tbl_order_details> list)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.ThemDonHang(customer_id, voucher_id, order_total, order_address, list);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
