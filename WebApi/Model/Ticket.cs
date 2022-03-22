using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WebApplicationAPI.Constant;
using WebApplicationAPI.ModelValidations;

namespace WebApplicationAPI.Model
{
    public class Ticket
    {
       // [FromQuery(Name = "tid")]

        public int? TicketId { get; set; }
        [Required(ErrorMessage = ConstantModel.ValidationRequiredProjectId)]
        // [FromRoute(Name = "pid")]
        public int? ProjectId { get; set; }
        [Required(ErrorMessage = ConstantModel.ValidationRequiredTicketId)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        [Ticket_EnsureDueDateForTicketOwner]
        [Ticket_EnsureDueDateInFuture]
        public DateTime? DueDate { get; set; }
        public DateTime? EnteredDate { get; set; }
    }
}
