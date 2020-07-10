using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Demo.Models;
using Microsoft.VisualBasic.CompilerServices;
using AspNet.Demo.EF;

namespace AspNet.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestService _testSvc;
        //private readonly ITestService _testSvc;

        public HomeController(ILogger<HomeController> logger, TestService tst)  // , ITestService tst)
        {
            _logger = logger;
            _testSvc = tst;
        }
        
        public IActionResult Index()
        {
            ViewBag.Strings = _testSvc.GetData();
            ViewBag.Tickets = new List<Ticket>
            {
                new Ticket { Title = "Primo Ticket" },
                new Ticket { Title = "Secondo Ticket" },
                new Ticket { Title = "Terzo Ticket" },
            };

            return View();
        }

        public IActionResult UpdatePartial()
        {
            var tickets = new List<Ticket>
            {
                new Ticket { Title = "Primo Ticket **" },
                new Ticket { Title = "Secondo Ticket **" },
                new Ticket { Title = "Terzo Ticket **" },
            };

            return PartialView("_TicketList", tickets);
        }

        public IActionResult UpdateViewComponent()
        {
            return ViewComponent("Tickets");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
