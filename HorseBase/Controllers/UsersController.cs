using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HorseBase.Models.ViewModels.User;
using HorseBase.Models;

namespace HorseBase.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    PasswordHash = userRegister.Password,
                    FirstName = userRegister.FirstName,
                    MiddleName = userRegister.MiddleName,
                    LastName = userRegister.LastName,
                };
                var result = await _userManager.CreateAsync(user, userRegister.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userRegister);
        }


        [HttpGet]
        public IActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogin logInRequest)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(logInRequest.Email);

                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, logInRequest.Password);

                    if (passwordCheck)
                    {
                        await _signInManager.PasswordSignInAsync(user, logInRequest.Password, false, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(logInRequest);
        }
    }
}
