using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface IProjectRepository
    {
        Task DeleteProject(int id);
        Task<IEnumerable<Project>> Get();
        Task<Project> GetById(int id);
        Task<IEnumerable<Ticket>> GetProjectTickets(int id, string filter = null);
        Task<int> PostProject(Project project);
        Task UpdateProject(Project project);
    }
}