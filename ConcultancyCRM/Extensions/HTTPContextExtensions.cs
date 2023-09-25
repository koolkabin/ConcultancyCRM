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
            string c = context.Session.Get<bool>("status") ? "success" : "danger";
            string msg = $"<div class='alert alert-{c}'>{context.Session.Get("msg")}</div>";
            context.Session.Remove("msg");
            context.Session.Remove("status");
            return msg;
        }
    }
}
