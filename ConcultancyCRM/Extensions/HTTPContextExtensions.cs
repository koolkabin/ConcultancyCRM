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
            string m = context.Session.Get<string>("msg");
            if (string.IsNullOrEmpty(m) || m.Length <= 0) { return ""; }
            string msg = $"<div class='alert alert-{c}'>{m}</div>";
            context.Session.Remove("msg");
            context.Session.Remove("status");
            return msg;
        }
    }
}
