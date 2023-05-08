using JSHub.Domain.Entity;
using JSHub.Domain.Response;
using JSHub.Domain.ViewModels.Account;
using JSHub.Domain.ViewModels.Profile;
using System.Security.Claims;

namespace JSHub.Service.Interfaces
{
    public interface IProfileService
    {
        BaseResponse<ProfileViewModel> GetProfile(long id);
        BaseResponse<ProfileViewModel> CreateProfile(ProfileViewModel model, long userId);
        BaseResponse<ProfileViewModel> UpdateProfile(ProfileViewModel model, long userId);
    }
}
