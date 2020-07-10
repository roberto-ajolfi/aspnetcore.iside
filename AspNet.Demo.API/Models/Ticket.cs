using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo.API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StateId { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual State State { get; set; }
    }
}
