using AspNet.Demo.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo.ViewComponents
{
    public class TicketsViewComponent : ViewComponent
    {
        private TicketContext _ctx;
        public TicketsViewComponent(TicketContext context)
        {
            _ctx = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetTickets();

            return await Task.FromResult(
                (IViewComponentResult)View("Tickets", model)    
            );
        }

        private Task<List<Ticket>> GetTickets()
        {
            return _ctx.Tickets.ToListAsync();
        }
    }
}
