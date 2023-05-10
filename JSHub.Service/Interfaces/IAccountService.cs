using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Account;
using System.Security.Claims;

namespace Portfolio.Service.Interfaces
{
    public interface IAccountService
    {
        BaseResponse<ClaimsIdentity> Register(RegisterViewModel model);
        BaseResponse<ClaimsIdentity> Login(LoginViewModel model);
    }
}
