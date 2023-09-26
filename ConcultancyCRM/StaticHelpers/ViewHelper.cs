using Newtonsoft.Json;

namespace ConcultancyCRM.StaticHelpers
{
    public static class ViewHelper
    {
        public static string GetDate(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }
    }

    public class FlashBag
    {
        private bool Status { get; set; } = false;
        private string Message { get; set; } = "";

        public void SetMessage(bool key, string value)
        {
            Status = key;
            Message = value;
        }

        public object GetMessage()
        {
            string c = Status ? "success" : "danger";
            return $"<div class='alert alert-{c}'>{Message}</div>";
        }

        public void ClearTempData()
        {
        }
    }
}
