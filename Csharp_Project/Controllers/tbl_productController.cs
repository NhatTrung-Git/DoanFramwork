using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class tbl_productController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProList()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_Products();
            ViewData["Listcp"] = context.GetTbl_Category_Products();
            ViewData["Listb"] = context.GetTbl_Brands();
            return View();
        }
        [HttpPost]
        public JsonResult GetProductById(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            object p = context.GetTbl_ProductById(id);
            return Json(JsonSerializer.Serialize(p));
        }
        [HttpPost]
        public JsonResult ThemProduct(string product_name, int category_id, int brand_id, string product_price, string product_image, int product_status)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.InsertProduct(product_name, category_id, brand_id, product_price, product_image, product_status);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult CapNhatProduct(int product_id, string product_name, int category_id, int brand_id, string product_price, string product_image, int product_status)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.UpdateProduct(product_id, product_name, category_id, brand_id, product_price, product_image, product_status);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        [HttpPost]
        public JsonResult XoaProduct(int product_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            int count = context.DeleteProduct(product_id);
            if (count > 0)
                return Json(1);
            return Json(0);
        }
        public IActionResult buyingpage(int product_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
            ViewData["Listp"] = context.GetTbl_ProductById_buying(product_id);
            return View();
        }
    }
}
