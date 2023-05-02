using System;
using System.Collections.Generic;
using System.Security.Claims;
using JSHub.Domain.Entity;
using JSHub.Domain.Response;
using JSHub.Domain.ViewModels.Account;

namespace JSHub.Service.Interfaces
{
    public interface IUserService
    {
        IBaseResponse<IEnumerable<User>> GetUsers();
    }
}
