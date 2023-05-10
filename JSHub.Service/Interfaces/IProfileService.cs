using Portfolio.Domain.Entity;
using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Account;
using Portfolio.Domain.ViewModels.Profile;
using System.Security.Claims;

namespace Portfolio.Service.Interfaces
{
    public interface IProfileService
    {
        BaseResponse<ProfileViewModel> GetProfile(long id);
        BaseResponse<ProfileViewModel> CreateProfile(ProfileViewModel model, long userId);
        BaseResponse<ProfileViewModel> UpdateProfile(ProfileViewModel model, long userId);
    }
}
