﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BidProgressManagementSystem.Web.Controllers
{
	public class SharedController : Controller
	{
		// GET: /<controller>/
		public IActionResult Error()
		{
			return View();
		}
	}
}