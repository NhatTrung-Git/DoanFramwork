using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Project.Models;

namespace Csharp_Project.Controllers
{
    public class ThongKeController : Controller
    {
        List<DSThongKe> ds = new List<DSThongKe>();
        public IActionResult Static(int nam)
        {
            if (nam == 0)
            {
                nam = 2022;
                StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
                ViewData["Listds"] = context.GetListDS(nam);
                return View();
            }

            else {
                StoreContext context = HttpContext.RequestServices.GetService(typeof(Csharp_Project.Models.StoreContext)) as StoreContext;
                ViewData["Listds"] = context.GetListDS(nam);
                return View(); 
            }
         
        }
        public List<DSThongKe> test()
        {
            return ds;
        }
    }
}
