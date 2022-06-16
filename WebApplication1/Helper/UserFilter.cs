using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Helper
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? id = context.HttpContext.Session.GetString("id");

            if (id == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"action","Login" },
                    {"controller","Account" }
                });
            }

            base.OnActionExecuting(context);
        }
    }
}
