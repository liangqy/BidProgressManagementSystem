using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BidProgressManagementSystem.Web.Controllers
{
    public class Menu : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

		/// <summary>
		/// 新增或编辑功能
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public IActionResult Edit()
		{
			return Json(new { Result = "Success" });
		}

	}
}
