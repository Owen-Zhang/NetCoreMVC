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
            var validator = new NewInfoValidation();
            var result = validator.Validate(request);
            if (result.IsValid)
                throw new BusinessError(result.Errors.FirstOrDefault().ErrorMessage);

            return null;
        }
    }
}
