using MyApp.Repository;
using MyApp.Repository.ApiClient;
using Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.ApplicationLogic
{
    public class ProjectsScreenUseCases : IProjectsScreenUseCases
    {
        public readonly IProjectRepository _projectRepository;

        public ProjectsScreenUseCases(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> ViewProjectsAsync()
        {
            return await _projectRepository.Get();
        }
    }
}
