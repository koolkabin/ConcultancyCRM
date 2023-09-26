using ConcultancyCRM.Extensions;
using ConcultancyCRM.Models;

namespace ConcultancyCRM.StaticHelpers
{
    public static class SessionHelper
    {
        private static string key = "LoggedInUser";
        public static SessionInfo GetSession(HttpContext context)
        {
            return new SessionInfo()
            {
                Id = "2112",
                Email = "test@gmail.com",
                EmployeeId =0,
                EmpName = "ram",
                UserName = "test",
                AssociatedRoles = new[] { enumUserType.SuperAdmin.ToString() }
            };
            //return context.Session.Get<SessionInfo>(key);
        }
        public static bool SetSession(HttpContext context, SessionInfo Data)
        {
            context.Session.Set(key, Data);
            return true;
        }

    }
}
