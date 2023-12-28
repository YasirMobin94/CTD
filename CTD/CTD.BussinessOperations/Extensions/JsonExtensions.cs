using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }
    }
    public static class StringExtensions
    {
        public static string ToReplaceString(this string str)
        {
            return str?.Trim()?.Replace(" - ", "-")?.Replace(" ", "-")?.Replace("/", "-")?.Replace(@"\", "-")?.Replace("&", "-")?.Replace("*", "")?.Replace("(", "")?.Replace(")", "")?.Replace(".", "")?.Replace("_", "");
        }
        public static string ToTitleCaseText(this string Name)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            Name = Name?.Replace("-", " ");
            Name = textInfo?.ToTitleCase(Name);
            return Name;
        }
    }
}
