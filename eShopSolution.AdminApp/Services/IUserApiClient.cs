﻿using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> RegistorUser(RegisterRequest request);

        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUsersPagingRequest request);
    }
}
