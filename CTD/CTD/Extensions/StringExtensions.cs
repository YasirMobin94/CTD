using System.Globalization;
using System.Runtime.CompilerServices;

namespace CTD.Extensions
{
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
