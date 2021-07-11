using eShopSolution.AdminApp.Services;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyWord,int pageIndex = 1,int pageSize =10)
        {
            var session = HttpContext.Session.GetString("Token");
            var request = new GetUsersPagingRequest()
            {
                BearerToken = session,
                Keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var res = await _userApiClient.GetUsersPaging(request);
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
                return View();
            var res = await _userApiClient.RegistorUser(registerRequest);
            if (res)
            {
                return RedirectToAction("Index", "User");
            }
            return View(registerRequest);
        }

        
    }

}
