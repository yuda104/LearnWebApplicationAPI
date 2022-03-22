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
  //  [ApiVersion("3.0")]
    [ApiController]
    [Route("api/[controller]")]
    [CustomTokenAuthFilterAttribute]
    // [Route("api/v{version:apiVersion}/Projects")]
    //[Version1DiscontinueResourceFilter]
    public class ProjectsController : Controller
    {
        public BugsContext _db { get; }

        public ProjectsController(BugsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Projects.ToListAsync());
        }

        //[HttpGet]
        //[MapToApiVersion("3.0")]
        //public async Task<IActionResult> GetV3()
        //{
        //    return Ok("Version3");
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public async Task<IActionResult> GetProjectTickets(int pid)
        {
            var tickets = await _db.Tickets.Where(t => t.ProjectId == pid).ToListAsync();
            if (tickets == null || tickets.Count <= 0)
                return NotFound();

            return Ok(tickets);
        }

        //[HttpGet]
        //[Route("/api/projectstickets")]
        //public IActionResult GetProjectTicket([FromBody]Ticket ticket)
        //{
        //    if (ticket == null) return BadRequest("Parameters are not provided properly!");

        //    if (ticket.TicketId == 0)
        //    {
        //        return Ok($"Reading all the tickets belong to project #{ticket.ProjectId}");
        //    }
        //    else
        //    {
        //        return Ok($"Reading project :{ticket.ProjectId}, ticket :{ticket.TicketId}, title :{ticket.Title} and description :{ticket.Description}");
        //    }
        //}
        //[HttpPost]
        //[Route("/api/v1/Projects")]
        //public IActionResult PostV1([FromBody]Ticket ticket)
        //{
        //    return Ok(ticket);
        //}

        //[HttpPost]
        //[Route("/api/v2/Projects")]
        ////[Ticket_EnsureEnteredDate]
        //public IActionResult PostV2([FromBody] Ticket ticket)
        //{
        //    return Ok(ticket);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                    new { id = project.ProjectId },
                    project
                );
        }
        
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();

            _db.Entry(project).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch 
            {
                if (_db.Projects.Find(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project == null) return NotFound();
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();

            return Ok(project);
        }
    }
}
