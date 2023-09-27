using Microsoft.AspNetCore.Mvc;
using ConcultancyCRM.StaticHelpers;
using Microsoft.AspNetCore.Authorization;
using ConcultancyCRM.CustomAttibutes;

namespace ConcultancyCRM.Controllers
{
    [CustomAuthenticationAttribute]
    public abstract class _ABSAuthenticatedController : Controller
    {
        public SessionInfo _ActiveSession => SessionHelper.GetSession(HttpContext);

    }
}
