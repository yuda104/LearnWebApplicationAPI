using MyApp.Repository;
using MyApp.Repository.ApiClient;
using Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
IWebApiExecuter apiExecuter = new WebApiExecuter("https://localhost:44326", httpClient, new TokenRepository(null));


Console.WriteLine("///////////");
Console.WriteLine("Reading projects...");
await GetProjects();

Console.WriteLine("///////////");
Console.WriteLine("Reading project tickets...");
await GetProjectTickets(1);

Console.WriteLine("///////////");
Console.WriteLine("Creating a project...");
await PostProject();
await GetProjects();

Console.WriteLine("///////////");
Console.WriteLine("Updating a project...");
await UpdateProject();
await GetProjects();


Console.WriteLine("///////////");
Console.WriteLine("Deleting a project...");
await DeleteProject();
await GetProjects();

async Task GetProjects()
{
    ProjectRepository repository = new(apiExecuter);
    var projects = await repository.Get();

    foreach (var project in projects)
    {
        Console.WriteLine($"Project: {project.Name}");
    }
}

async Task<Project> GetProjectsById(int id)
{
    ProjectRepository repository = new(apiExecuter);
    return await repository.GetById(id);
}

async Task GetProjectTickets(int id)
{
    var project = await GetProjectsById(id);
    Console.WriteLine($"Project : {project.Name}");

    ProjectRepository repository = new(apiExecuter);
    var tickets = await repository.GetProjectTickets(id);

    foreach (var ticket in tickets)
    {
        Console.WriteLine($"     {ticket.Title}");
    }
}

async Task<int> PostProject()
{
    Project project = new Project { };

    ProjectRepository repository = new(apiExecuter);
    return await repository.PostProject(project);
}

async Task UpdateProject()
{
    ProjectRepository repository = new(apiExecuter);
    var project = await GetProjectsById(3);
    project.Name += " Update";
    await repository.UpdateProject(project);
}

async Task DeleteProject()
{
    ProjectRepository repository = new(apiExecuter);
    await repository.DeleteProject(3);
}