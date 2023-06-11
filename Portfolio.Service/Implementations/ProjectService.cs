using Microsoft.Extensions.Logging;
using Portfolio.Dal.Interfaces;
using Portfolio.Domain.Entity;
using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Project;
using Portfolio.Service.Interfaces;

namespace Portfolio.Service.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository<Project> _projectRepository;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IBaseRepository<Project> projectRepository, ILogger<ProjectService> projectService)
        {
            _projectRepository = projectRepository;
            _logger = projectService;
        }

        public BaseResponse<ProjectViewModel> Create(long userId)
        {
            var s = 0;
            return new BaseResponse<ProjectViewModel>() { };
        }
    }
}
