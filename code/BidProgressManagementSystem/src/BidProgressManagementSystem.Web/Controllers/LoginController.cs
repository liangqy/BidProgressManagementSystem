using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BidProgressManagementSystem.EntityFramework;
using Microsoft.AspNetCore.Http;
using BidProgressManagementSystem.Utils;
using BidProgressManagementSystem.Application;

namespace BidProgressManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
        public IActionResult Index(User model)
        {
            if (ModelState.IsValid)
            {
                //检查用户信息
                var user = _userAppService.CheckUser(model.UserName, model.Password);
                if (user != null)
                {
                    //记录Session
                    HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "用户名或密码错误。";
                return View();
            }
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
                    break;
                }
            }
            return View(model);
        }
    }
}