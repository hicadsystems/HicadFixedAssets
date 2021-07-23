using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FixedAssetWeb.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUserService userService;


        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }


        public string RefererUrl()
        {
            return Request.Headers["Referer"].ToString();
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null;
            }
            return await userService.GetUserWithRoles(int.Parse(userId));
        }
    }

}