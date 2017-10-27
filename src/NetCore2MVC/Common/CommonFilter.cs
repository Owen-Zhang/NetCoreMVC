using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace NetCore2MVC.Common
{
    [AttributeUsage(AttributeTargets.All, Inherited =true, AllowMultiple=true )]
    public class CommonFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = "zh-CN";
            var cultureInput = filterContext.HttpContext.Request.Headers["culture"];

            switch (cultureInput)
            {
                case "zh-HK":
                case "zh-TW":
                    culture = "zh-HK";
                    break;

                default:
                    culture = "zh-CN";
                    break;
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(culture); //en-Us, zh-HK,zh-CN,zh-TW
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
