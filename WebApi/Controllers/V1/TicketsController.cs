using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebApplicationAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [CustomTokenAuthFilterAttribute]
    public class TicketsController : Controller
    {
        private readonly BugsContext _db;
        public TicketsController(BugsContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Tickets.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
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
