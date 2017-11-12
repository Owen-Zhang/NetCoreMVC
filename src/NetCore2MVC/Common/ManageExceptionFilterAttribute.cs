using KJT.WebFrameWork.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCore2MVC.Common
{
    public class ManageExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private string errorActionPath;

        public ManageExceptionFilterAttribute(string errorActionPath = null)
        {
            this.errorActionPath = errorActionPath;
        }

        /// <summary>
        /// 可以跳转到不同的错误页面(如果为ajax就返回相应的结构数据)
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.HttpContext.Request.Headers["HTTP_X_REQUESTED_WITH"]))
            {
                //业务错误，直接返回就可以了
                var message = context.Exception.Message;
                if (!(context.Exception is BusinessError))
                {  
                    message = "出现了系统错误，请联系管理员";
                    Logger.WriteLog(context.Exception.ToString());
                }
                context.Result = new JsonResult(new AjaxResult { Status = 0, Message = message });
            } else
            {
                if (string.IsNullOrWhiteSpace(errorActionPath))
                    errorActionPath = "Error/Main";

                var actionResult = errorActionPath.Split(@"/");
                var result = new RedirectToActionResult(actionResult[0], actionResult[1], context.Exception.Message);
            }
            context.ExceptionHandled = true;
        }
    }
}
