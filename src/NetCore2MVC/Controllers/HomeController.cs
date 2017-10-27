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

namespace NetCore2MVC.Controllers
{
    [CommonFilter]
    public class HomeController : Controller
    {
        private readonly AppSettingDetail settings;
        private readonly TestJsonModel jsonModel;
        private readonly Inter inter;
        private readonly IHttpContextAccessor access; //通过注入方式去取httpContext, 也可以通过autofac的getservice去取

        
        public HomeController(IOptions<AppSettingDetail> setting, Inter inter, IHttpContextAccessor access, IOptions<TestJsonModel> jsonModel)
        {
            this.settings = setting.Value;
            this.inter = inter;
            this.access = access;
            this.jsonModel = jsonModel.Value;
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
            var value = Message.key;
            var test2 = ConfigurationManager.GetValue("Logging:LogLevel:Default");
            var result = ConfigurationManager.GetData<TestJsonModel>("TestJson");
            ViewData["Message"] = $"Your application description page.{settings.test}";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = string.Format("Your contact page.{0}",inter.TestInterfaceInfo("input test"));

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
