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
                //����û���Ϣ
                var user = _userAppService.CheckUser(model.UserName, model.Password);
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