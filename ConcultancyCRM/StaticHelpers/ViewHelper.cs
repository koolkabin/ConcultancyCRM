using ConcultancyCRM.Extensions;

namespace ConcultancyCRM.StaticHelpers
{
    public static class SessionHelper
    {
        public static SessionInfo GetSession()
        {
            return new SessionInfo()
            {
                EmployeeId = 1,
                EmpName = "StaticAdmin",
                UserName = "SuperAdmin"
            };
        }
        public static bool SetSession(HttpContext context, SessionInfo Data)
        {
            context.Session.Set("LoggedInUser", Data);
            return true;
        }
    }
    public class SessionInfo
    {
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public string UserName { get; set; }
    }
    public static class ViewHelper
    {
        public static string GetDate(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }
    }
}
