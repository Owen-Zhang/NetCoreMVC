using Microsoft.AspNetCore.Mvc;

namespace NetCore2MVC.Common
{
    [CommonFilter]
    [ManageExceptionFilter]
    public class BaseController : Controller
    {
    }
}
