using System.Threading.Tasks;
using FixedAssetCore.Core.Data;
using FixedAssetWeb.IServices;
using FixedAssetWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FixedAssetWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        private readonly IUnitOfWork unitOfWork;
        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IUnitOfWork unitOfWork)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult  Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var auth = await authenticationService.SignInUserAsync(login.UserName, login.Password, "false");

            if (!auth.Success)
            {
                TempData["ErrorMessage"] = auth.Message;
                return RedirectToAction("Login", "Authentication");
            }
           
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await authenticationService.SignOutUserAsync();
            return RedirectToAction("Login", "Authentication");
        }
    }
}