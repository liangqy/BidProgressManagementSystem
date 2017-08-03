using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BidProgressManagementSystem.EntityFramework;
using BidProgressManagementSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using BidProgressManagementSystem.Utils;

namespace BidProgressManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
			return View();
		}
        [HttpPost]
        public IActionResult Index(User input)
        {
            if (ModelState.IsValid)
            {
                //����û���Ϣ
                var user = _userService.CheckUser(input.UserName, input.Password);
                if (user != null)
                {
                    //��¼Session
                    HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    //��ת��ϵͳ��ҳ
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "�û������������";
                return View();
            }

            return View(input);
        }
    }
}