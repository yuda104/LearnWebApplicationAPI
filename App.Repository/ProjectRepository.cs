using MyApp.Repository.ApiClient;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IWebApiExecuter WebApiExecuter;
        public ProjectRepository(IWebApiExecuter webApiExecuter)
        {
            WebApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<Project>> Get()
        {
            return await WebApiExecuter.InvokeGet<IEnumerable<Project>>("api/projects");
        }

        public async Task<Project> GetById(int id)
        {
            return await WebApiExecuter.InvokeGet<Project>($"api/projects/{id}");
        }

        public async Task<IEnumerable<Ticket>> GetProjectTickets(int id, string filter = null)
        {
            string uri = $"api/projects/{id}/tickets";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                uri += $"?owner={filter}&api-version=2.0";
            }

            return await WebApiExecuter.InvokeGet<IEnumerable<Ticket>>(uri);
        }

        public async Task<int> PostProject(Project project)
        {
            project = await WebApiExecuter.InvokePost<Project>("api/projects", project);

            return project.ProjectId;
        }

        public async Task UpdateProject(Project project)
        {
            await WebApiExecuter.InvokePut<Project>($"api/projects/{project.ProjectId}", project);
        }

        public async Task DeleteProject(int id)
        {
            await WebApiExecuter.InvokeDelete($"api/projects/{id}");
        }
    }
}
