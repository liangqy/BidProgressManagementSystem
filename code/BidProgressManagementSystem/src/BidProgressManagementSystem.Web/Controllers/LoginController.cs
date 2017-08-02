using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BidProgressManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
			return View();
		}

		[HttpPost]
		public IActionResult Login()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}