using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CTD.ViewsExtensions
{
    public static class ViewsExtensionMethods
    {
        public static string CurrentActive(this IHtmlHelper html, string controller = null, string actionName = null)
        {
            var context = html.ViewContext.ActionDescriptor as ControllerActionDescriptor;

            return (context.ActionName.Equals(actionName) && context.ControllerName.Equals(controller)) ? "current" : null;
        }
        public static string HomeLayoutClass(this HtmlHelper html, string controller, string actionName)
        {
            return null;
        }
    }
}
