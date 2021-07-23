using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using FixedAssetWeb.IServices;
using Microsoft.AspNetCore.Identity;
using System;

using System.Threading.Tasks;
using FixedAssetCore.Core.Extention;

namespace FixedAssetWeb.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<ResponseModel<User>> SignInUserAsync(string UserName, string password, string client)
        {
            var user = await userManager.FindByNameAsync(UserName);


            if (user == null)
            {
                return user.ToResponse("Account Not Founds");
            }

            SignInResult result = null;
            if (client == "true")
            {
                result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            else
            {
                result = await signInManager.PasswordSignInAsync(user, password, true, false);
            }

            if (result.Succeeded)
            {
                return user.ToResponse(success: true);
            }
            return user.ToResponse("Password incorrect or account inactive");
        }

        public async Task SignOutUserAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
