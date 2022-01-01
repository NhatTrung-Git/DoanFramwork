using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Controllers
{
    public class tbl_voucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
