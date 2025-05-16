using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GreenGuest_Web.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("IsAdmin") != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Admin", null);
            }

            base.OnActionExecuting(context);
        }
    }
}