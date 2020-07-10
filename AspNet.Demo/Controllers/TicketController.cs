using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Demo.EF;
using AspNet.Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Demo.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext _ctx;

        public TicketController(TicketContext context)
        {
            _ctx = context;
        }

        // GET: Ticket
        public ActionResult Index()
        {
            ViewBag.DateLabel = "Today it's ";

            var results = _ctx
                .Tickets
                .Select(t => new TicketListViewModel
                {
                    Id = t.Id,
                    IssueDate = t.IssueDate.ToString("dd-MMM-yyyy"),
                    Description = t.Description,
                    Title = t.Title
                });

            return View(results);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            var result = _ctx
               .Tickets.Find(id);

            return View(result);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _ctx.Tickets.Add(ticket);
                    _ctx.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Layout = "~/Views/Shared/_Layout_due.cshtml";
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsStateValid(int stateId)
        {
            if (stateId > 0 && stateId <= 3)
                return Json(true);
            return Json("State ID must be between 1 and 3");
        }
    }
}