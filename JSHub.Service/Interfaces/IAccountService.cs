
using JSHub.Domain.Response;
using JSHub.Domain.ViewModels.Account;
using System.Security.Claims;

namespace JSHub.Service.Interfaces
{
    public interface IAccountService
    {
        BaseResponse<ClaimsIdentity> Register(RegisterViewModel model);
        BaseResponse<ClaimsIdentity> Login(LoginViewModel model);
    }
}
