using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace BanHangOgani.Models.Authentication
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("UserName")==null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                {
                        {"Controller", "Access" },
                        {"Action", "Login" }
                });
            }
        }
    }
}
