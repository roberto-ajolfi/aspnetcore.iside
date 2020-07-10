using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo.Models
{
    public class TicketListViewModel
    {
        public int Id { get; set; }
        public string IssueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
