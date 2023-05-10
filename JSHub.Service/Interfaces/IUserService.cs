using System;
using System.Collections.Generic;
using System.Security.Claims;
using Portfolio.Domain.Entity;
using Portfolio.Domain.Response;
using Portfolio.Domain.ViewModels.Account;

namespace Portfolio.Service.Interfaces
{
    public interface IUserService
    {
        IBaseResponse<IEnumerable<User>> GetUsers();
    }
}
