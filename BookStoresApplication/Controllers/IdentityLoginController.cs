using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoresApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityLoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly BookDBContext bookDBContext;

        public IdentityLoginController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, BookDBContext bookDBContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.bookDBContext = bookDBContext;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegistrationModel to IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    City = model.City,
                    Gender = model.Gender
                };

                //// Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);
                //// If user is successfully created, sign-in the user using
                //// SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    bookDBContext.LoginTable.Add(model);
                    bookDBContext.SaveChanges();
                    string Message = "Register Sucess Fully";
                    return this.Ok(new { Message });
                }

                //// If there are any errors, add them to the ModelState object
                //// which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            string message = "Put right pattern of email and password";
            return this.BadRequest(new { message });
        }

        [HttpPost]
        [Route("LogOutUser")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            string message = "Logout Sucess Fully";
            return this.Ok(new { message });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginIdentity model)
        {
            string error = " Login Failed Please retry!!";
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    string Message = "Login successfully!!";
                    return this.Ok(new { Message });
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return this.BadRequest(new { error });
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Registration> GetRegisterUser()
        {
            return bookDBContext.LoginTable;
        }
    }
}