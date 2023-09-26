using ConcultancyCRM.Extensions;

namespace ConcultancyCRM.StaticHelpers
{
    public static class SessionHelper
    {
        private static string key = "LoggedInUser";
        public static SessionInfo GetSession(HttpContext context)
        {
            return context.Session.Get<SessionInfo>(key);
        }
        public static bool SetSession(HttpContext context, SessionInfo Data)
        {
            context.Session.Set(key, Data);
            return true;
        }
       
    }
}
