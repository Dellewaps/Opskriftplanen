using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Opskriftplanen.Areas.Admin.Controllers
{
    public class MeasurmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}