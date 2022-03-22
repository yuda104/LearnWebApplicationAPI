using System.ComponentModel.DataAnnotations;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.ModelValidations
{
    public class Ticket_EnsureDueDateForTicketOwner : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.DueDate.HasValue)
                {
                    return new ValidationResult("Due date is required when the tickets has an owner");
                }

            }

            return ValidationResult.Success;
        }
    }
}
