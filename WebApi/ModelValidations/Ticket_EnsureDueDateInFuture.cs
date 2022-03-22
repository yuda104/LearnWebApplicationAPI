using System;
using System.ComponentModel.DataAnnotations;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.ModelValidations
{
    public class Ticket_EnsureDueDateInFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket != null && ticket.TicketId == null)
            {
                if (ticket.DueDate.HasValue && ticket.DueDate < DateTime.Now)
                {
                    return new ValidationResult("Due date has to be in the future");
                }

            }

            return ValidationResult.Success;
        }
    }
}
