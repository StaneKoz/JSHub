using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.ViewModels.Project;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        public readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProjectViewModel model)
        {
            return View();
        }
    }
}
