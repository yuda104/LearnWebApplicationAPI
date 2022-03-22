using Core.Models;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ApplicationLogic
{
    public class TicketsScreenUseCases : ITicketsScreenUseCases
    {

        public readonly IProjectRepository _projectRepository;
        public readonly ITicketRepository _ticketRepository;

        public TicketsScreenUseCases(IProjectRepository projectRepository,
            ITicketRepository ticketRepository)
        {
            _projectRepository = projectRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> ViewTickets(int id)
        {
            return await _projectRepository.GetProjectTickets(id);
        }

        public async Task<IEnumerable<Ticket>> SearchTickets(string field)
        {
            if (int.TryParse(field, out int ticketId))
            {
                var ticket = await _ticketRepository.GetByIdAsync(ticketId);
                var tickets = new List<Ticket>();
                tickets.Add(ticket);
                return tickets;

            }
            return await _ticketRepository.GetAsync(field);
        }

        public async Task<IEnumerable<Ticket>> SearchTicketsByProjectId(string field, int? projectId)
        {
            if (int.TryParse(field, out int ticketId))
            {
                var ticket = await _ticketRepository.GetByIdAsync(ticketId);
                var tickets = new List<Ticket>();

                if (int.TryParse(projectId.ToString(), out int projectIdField))
                {
                    if (ticket.ProjectId.Equals(projectIdField))
                    {

                        tickets.Add(ticket);
                    }
                } 
                return tickets;

            }
            return await _ticketRepository.GetAsync(field, projectId);
        }

        public async Task<IEnumerable<Ticket>> ViewOwnersTickets(int projectId, string ownerName = null)
        {
            return await _projectRepository.GetProjectTickets(projectId, ownerName);
        }

        public async Task<Ticket> ViewTicketById(int ticketId)
        {
            return await _ticketRepository.GetByIdAsync(ticketId);
        }
        public async Task UpdateTicket(Ticket ticket)
        {
            await _ticketRepository.UpdateAsync(ticket);
        }


    }
}
