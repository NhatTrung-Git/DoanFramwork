using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Csharp_Project.Models;
using Microsoft.AspNetCore.Http;

namespace Csharp_Project.Controllers
{
    public class tbl_voucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Voucher()
        {
            if (HttpContext.Session.GetInt32("_ID") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_Voucher();
            return View();
        }
        public IActionResult Voucher_hoso()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listv"] = context.GetTbl_Voucher();
            return View();
        }
        [HttpPost]
        public JsonResult GetVoucherId(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            object p = context.GetTbl_VoucherById(id);
            return Json(JsonSerializer.Serialize(p));
        }
        [HttpPost]
        public JsonResult ThemVoucher(string voucher_name, string voucher_code, int voucher_quantity, string voucher_date, int voucher_sale)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.InsertVoucher(voucher_name, voucher_code, voucher_quantity, voucher_date, voucher_sale);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult CapNhatVoucher(int voucher_id, string voucher_name, string voucher_code, int voucher_quantity, string voucher_date, int voucher_sale)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateVoucher(voucher_id, voucher_name, voucher_code, voucher_quantity, voucher_date, voucher_sale);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult XoaVoucher(int voucher_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.DeleteVoucher(voucher_id);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }

}
