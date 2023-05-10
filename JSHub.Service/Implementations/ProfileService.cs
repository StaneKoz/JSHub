using Portfolio.Dal;
using Portfolio.Domain.Entity;
using Portfolio.Domain.Enum;
using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Profile;
using Portfolio.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Portfolio.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(AppDBContext dbContext, ILogger<ProfileService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public BaseResponse<ProfileViewModel> GetProfile(long userId)
        {
            try
            {
                var user = _dbContext.Users.Include(u => u.Profile).FirstOrDefault(u => u.Id == userId);
                var profile = user.Profile;
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
                    // Костыль. Исправить
                    Email = _dbContext.Users.FirstOrDefault(u => u.Id == userId).Email,
                    Experience = profile.Experience,
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
                    Experience = model.Experience,
                };
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                user.Profile = profile;
                _dbContext.SaveChanges();
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

        public BaseResponse<ProfileViewModel> UpdateProfile(ProfileViewModel model, long userId)
        {
            try
            {
                var oldProfile = _dbContext.Profiles.FirstOrDefault(u => u.Id == userId);
                oldProfile.FirstName = model.FirstName;
                oldProfile.LastName = model.LastName;
                oldProfile.PhoneNumber = model.PhoneNumber;
                oldProfile.AboutMe = model.AboutMe;
                oldProfile.Employment = model.Employment;
                oldProfile.Age = model.Age;
                oldProfile.Experience = model.Experience;
                _dbContext.SaveChanges();
                return new BaseResponse<ProfileViewModel>()
                {
                    Data = model,
                    StatusCode = StatusCode.OK
                };
            }
            catch
            {
                return new BaseResponse<ProfileViewModel>()
                {
                    StatusCode = StatusCode.InternalServerError,
                };                
            };
        }
    }
}
