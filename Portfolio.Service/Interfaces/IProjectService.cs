using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Project;

namespace Portfolio.Service.Interfaces
{
    public interface IProjectService
    {
        public BaseResponse<ProjectViewModel> Create(long userId);
    }
}
