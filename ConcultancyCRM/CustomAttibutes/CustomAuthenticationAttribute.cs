using Microsoft.AspNetCore.Mvc.Filters;

namespace ConcultancyCRM.CustomAttibutes
{
    public class CustomAuthenticationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Teacher SessionValue = context.HttpContext.Session.Get<Teacher>("LoggedInUser");

            //if (SessionValue == null)
            //{
            //    //
            //    context.Result = new RedirectToActionResult("Login", "Home", new { });
            //}
        }
    }
}
