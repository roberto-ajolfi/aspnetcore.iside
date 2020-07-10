using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AspNet.Demo.Models;

namespace AspNet.Demo.EF
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<AspNet.Demo.Models.TicketListViewModel> TicketListViewModel { get; set; }
    }
}
