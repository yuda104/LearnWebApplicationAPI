using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using WebApi.Filters.V2;
using WebApi.QueryFilter;

namespace WebApplicationAPI.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/tickets")]
    [CustomTokenAuthFilterAttribute]
    //[APIKeyAuthFilterAttribute]
    public class TicketsV2Controller : ControllerBase
    {
        private readonly BugsContext _db;
        public TicketsV2Controller(BugsContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TicketQueryFilter ticketQueryFilter)
        {
            IQueryable<Ticket> tickets = _db.Tickets;

            if (ticketQueryFilter != null)
            {
                if (ticketQueryFilter.Id.HasValue && ticketQueryFilter.ProjectId.HasValue)
                {
                    tickets = tickets.Where(p => p.TicketId.Equals(ticketQueryFilter.Id) && p.ProjectId.Equals(ticketQueryFilter.ProjectId));
                }

                if (ticketQueryFilter.Id.HasValue && !ticketQueryFilter.ProjectId.HasValue)
                {
                    tickets = tickets.Where(p => p.TicketId.Equals(ticketQueryFilter.Id));
                }

                if (!string.IsNullOrWhiteSpace(ticketQueryFilter.TitleOrDescription) 
                    && ticketQueryFilter.ProjectId.HasValue)
                {
                    tickets = tickets.Where(p => (p.Title.Contains(ticketQueryFilter.TitleOrDescription, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(ticketQueryFilter.TitleOrDescription, StringComparison.OrdinalIgnoreCase)) &&
                    p.ProjectId.Equals(ticketQueryFilter.ProjectId));
                }

                if (string.IsNullOrWhiteSpace(ticketQueryFilter.TitleOrDescription) 
                    && ticketQueryFilter.ProjectId.HasValue)
                {
                    tickets = tickets.Where(p => 
                    p.ProjectId.Equals(ticketQueryFilter.ProjectId));
                }
            }

            return Ok(await tickets.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        [Ticket_EnsureDescriptionPresentActionFilter]
        public async Task<IActionResult> Post([FromBody]Ticket ticket)
        {
            _db.Add(ticket);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), 
                new { id = ticket.TicketId},
                ticket
                );
        }

        [HttpPut("{id}")]
        [Ticket_EnsureDescriptionPresentActionFilter]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();
            _db.Entry(ticket).State = EntityState.Modified;
           
            try
            {
                await _db.SaveChangesAsync();

            }
            catch (System.Exception)
            {
                if (await _db.Tickets.FindAsync(id) == null) return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = _db.Tickets.Find(id);
            if (ticket == null) return NotFound();

            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}
