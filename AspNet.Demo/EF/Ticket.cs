using AspNet.Demo.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNet.Demo.EF
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        [Range(1,3)]
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(40, MinimumLength = 0)]
        public string Description { get; set; }
        [Remote(action: "IsStateValid", controller: "Ticket")]
        public int StateId { get; set; }

        public virtual Category Category { get; set; }
        public virtual State State { get; set; }
        public virtual Priority Priority { get; set; }
    }
}
