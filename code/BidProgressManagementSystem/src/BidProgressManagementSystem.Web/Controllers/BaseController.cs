using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BidProgressManagementSystem.Controllers
{
    public class BaseController:Controller
    {
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			byte[] result;
			filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);
			if (result == null)
			{
				filterContext.Result = new RedirectResult("/Login/Index");
				return;
			}
			base.OnActionExecuting(filterContext);
		}
	}
}
