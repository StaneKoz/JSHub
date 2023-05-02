
using JSHub.Dal.Interfaces;
using JSHub.Domain.Entity;
using JSHub.Domain.Enum;
using JSHub.Domain.Response;
using JSHub.Domain.ViewModels.Profile;
using JSHub.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace JSHub.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IBaseRepository<Profile> _profileRepository;
        private readonly ILogger<ProfileService> _logger;
        public ProfileService(IBaseRepository<Profile> profileRepository, ILogger<ProfileService> logger)
        {
            _profileRepository = profileRepository;
            _logger = logger;
        }

        public BaseResponse<ProfileViewModel> GetProfile(string userId)
        {
            try
            {
                var userIdAsNumber = long.Parse(userId);
                var profile = _profileRepository.GetAll().FirstOrDefault(p => p.UserId == userIdAsNumber);
                if (profile == null) return new BaseResponse<ProfileViewModel>()
                {
                    StatusCode = StatusCode.ProfileNotFound   
                };
                var viewModelProfile = new ProfileViewModel()
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    PhoneNumber = profile.PhoneNumber,
                    AboutMe = profile.AboutMe,
                    Age = profile.Age,
                    Speciality = profile.Speciality,
                };
                return new BaseResponse<ProfileViewModel>()
                {
                    Data = viewModelProfile,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Profile]: {ex.Message}");
                return new BaseResponse<ProfileViewModel>()
                {
                    Description = $"[GetProfile] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            };
        }
        public BaseResponse<ProfileViewModel> CreateProfile(ProfileViewModel model, long userId)
        {
            try
            {
                var profile = new Profile()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    AboutMe = model.AboutMe,
                    Age = model.Age,
                    UserId = userId,
                    Speciality = model.Speciality,
                };
                _profileRepository.Create(profile);
                return new BaseResponse<ProfileViewModel>()
                {
                    Data = model,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[CreateProfile]: {ex.Message}");
                return new BaseResponse<ProfileViewModel>()
                { 
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
