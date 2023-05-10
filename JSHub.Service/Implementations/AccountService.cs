using Portfolio.Dal.Interfaces;
using Portfolio.Domain.Entity;
using Portfolio.Domain.Enum;
using Portfolio.Domain.Helpers;
using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Account;
using Portfolio.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Portfolio.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IBaseRepository<User> userRepository, ILogger<AccountService> accountService)
        {
            _userRepository = userRepository;
            _logger = accountService;
        }

        public BaseResponse<ClaimsIdentity> Register(RegisterViewModel model)
        {
            try
            {
                var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким почтовым адресом уже зарегистрирован"
                    };
                }
                user = new User()
                {
                    Email = model.Email,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password)
                };
                _userRepository.Create(user);
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>
                {
                    Data = result,
                    Description = "Пользователь создан",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<ClaimsIdentity> Login(LoginViewModel model)
        {
            try
            {
                var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }
                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль"
                    };
                }
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
