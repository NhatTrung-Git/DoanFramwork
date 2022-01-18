using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Csharp_Project.Controllers
{
    public class tbl_brandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nhacc()
        {
            if (HttpContext.Session.GetInt32("_ID") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_Products_ncc();
            return View();
        }
        [HttpPost]
        public JsonResult GetNhaccById(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            object p = context.GetTbl_brandById(id);
            return Json(JsonSerializer.Serialize(p));
        }
        [HttpPost]
        public JsonResult ThemNhacc(string brand_name, string brand_desc, int brand_status, string brand_image)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.InsertNhacc(brand_name, brand_desc, brand_status, brand_image);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult CapNhatNhacc(int brand_id, string brand_desc, string brand_name, int brand_status, string brand_image)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateNhacc(brand_id, brand_name, brand_desc, brand_status, brand_image);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult XoaNhacc(int brand_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.DeleteNhacc(brand_id);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
    }
}
