using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;

namespace ConcultancyCRM.StaticHelpers
{
    public static class TempDataHelper
    {
        public static void SetTempData(ITempDataDictionary tempData, string key, object value)
        {
            tempData[key] = value;
        }

        public static T GetTempData<T>(ITempDataDictionary tempData, string key)
        {
            if (tempData.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            return default(T);
        }

        internal static void SetMsg(ITempDataDictionary tempData, bool v, string message)
        {
            SetTempData(tempData, "FlashStatus", v);
            SetTempData(tempData, "FlashMsg", message);
        }
        internal static string ShowMsg(ITempDataDictionary tempData)
        {
            string s1 = GetTempData<string>(tempData, "FlashMsg");
            if (string.IsNullOrEmpty(s1) || s1.Trim().Length == 0) { return ""; }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='alert alert-{0}'>", GetTempData<bool>(tempData, "FlashStatus") == true ? "success" : "danger");
            sb.AppendLine(s1);
            sb.AppendLine("</div>");
            return sb.ToString();
        }
    }
}
