using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }
    }

    public class MyPage : Microsoft.AspNetCore.Mvc.Razor.RazorPage
    {
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
