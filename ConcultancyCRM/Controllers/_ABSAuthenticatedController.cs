using Microsoft.AspNetCore.Mvc;
using ConcultancyCRM.StaticHelpers;
using Microsoft.AspNetCore.Authorization;

namespace ConcultancyCRM.Controllers
{
    [Authorize]
    public abstract class _ABSAuthenticatedController : Controller
    {
        public SessionInfo _ActiveSession => SessionHelper.GetSession();

    }
}
