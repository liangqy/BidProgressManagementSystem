using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BidProgressManagementSystem.Web.Controllers
{
    public class BidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult GetAllPageList(int startPage, int pageSize)
		{
			int rowCount = 0;
			return Json(new
			{
				rowCount = 100,
				pageCount = 10,
				rows =new int[10],
			});
		}
	}
}