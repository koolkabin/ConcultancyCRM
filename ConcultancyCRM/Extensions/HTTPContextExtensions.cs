using ConcultancyCRM.Models;
using System.Data;

namespace ConcultancyCRM.Extensions
{
    public static class HTTPContextExtensions
    {
        public static void SetMessage(this HttpContext context, bool status, string message)
        {
            context.Session.Set("msg", message);
            context.Session.Set("status", status);
        }
        public static string GetMessage(this HttpContext context)
        {
            string m = context.Session.Get<string>("msg");
            if (string.IsNullOrEmpty(m) || m.Length <= 0) { return ""; }
            string c = context.Session.Get<bool>("status") ? "success" : "danger";
            string msg = $"<div class='alert alert-{c}'>{m}</div>";
            //context.Session.Remove("xxx");// Session.Remove("msg");
            //Session.Remove("status");
            return msg;
        }
    }
    public static class ArrayExtensions
    {
        public static string[] Push(this string[] arr, string newElement)
        {
            List<string> NewRoles = new List<string>(arr);
            NewRoles.Add(newElement);
            return NewRoles.ToArray();
        }
        public static string QuickJoin(this string[] arr, string joinChar = ",")
        {
            return string.Join(joinChar, arr);
        }
    }
}
