using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetCore2MVC.Models;
using Microsoft.Extensions.Options;
using KJT.ServiceInterface;
using Microsoft.AspNetCore.Http;
using KJT.WebFrameWork.Common;
using Microsoft.Extensions.Configuration;
using KJT.Resouce;
using NetCore2MVC.Common;
using KJT.Model;
using NetCore2MVC.Validation;
using System.Linq;

namespace NetCore2MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Inter inter;
        private readonly IHttpContextAccessor access; //通过注入方式去取httpContext, 也可以通过autofac的getservice去取

        
        public HomeController(Inter inter, IHttpContextAccessor access)
        {
            this.inter = inter;
            this.access = access;
        }

        public IActionResult Index()
        { 
            var value = Message.key;
            var value2 = Message.adsfafdasdf;
            var result = Common.AutofacProvider.GetService<Inter>().TestInterfaceInfo("111");
            return View();
        }

        public IActionResult About()
        {
            var test2 = ConfigurationManager.GetValue("Logging:LogLevel:Default");
            var result = ConfigurationManager.GetData<TestJsonModel>("TestJson");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = string.Format("Your contact page.{0}",inter.TestInterfaceInfo("input test"));

            return View();
        }


        public IActionResult Error(bool fromBack = false)
        {
            if (!fromBack)
            {
                access.HttpContext.Response.WriteAsync("<html><body><div style=\"color:red\">sdfasdfasdfadaafda</div><div>224323423</div></body></html>");
                return View();
            }else 
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveNews(NewInfo request)
        {
            Validator.Validate<NewInfoValidation, NewInfo>(request);

            return null;
        }
    }
}
