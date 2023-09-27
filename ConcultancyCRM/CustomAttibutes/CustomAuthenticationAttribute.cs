using ConcultancyCRM.StaticHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConcultancyCRM.CustomAttibutes
{
    public class CustomAuthenticationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            SessionInfo SessionValue = SessionHelper.GetSession(context.HttpContext);

            if (SessionValue == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { });
            }
        }
    }
}
