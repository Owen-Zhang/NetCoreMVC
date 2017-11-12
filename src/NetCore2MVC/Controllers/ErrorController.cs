using Microsoft.AspNetCore.Mvc;

namespace NetCore2MVC.Controllers
{
    /// <summary>
    /// 错误的管理器(可以定义多个不同的错误页面)
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// 主要错误页面
        /// </summary>
        public ActionResult Main(string msg)
        {
            return Content($"主要页面错误信息提示：{msg}");
        }
    }
}
