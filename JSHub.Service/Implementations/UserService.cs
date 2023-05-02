using JSHub.Dal.Interfaces;
using JSHub.Dal.Repositories;
using JSHub.Domain.Entity;
using JSHub.Domain.Response;
using JSHub.Service.Interfaces;

namespace JSHub.Service.Implementations
{ using JSHub.Domain.Enum;
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IBaseResponse<IEnumerable<User>> GetUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = _userRepository.GetAll() ;
                if (users.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<User> GetUser(int id)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = _userRepository.Get(id);
                if (user == null)
                {
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Description = "Пользователь не найден";
                    return baseResponse;
                }
                baseResponse.Data = user;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[GetUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
