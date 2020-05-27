using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Opskriftplanen.Areas.Users.Controllers
{
    public class UserWeekPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}