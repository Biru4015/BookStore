using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using BookStoreModelLayer.AccountModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoresApplication.Controllers
{
    /// <summary>
    /// This is controller class for user account.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserAccountManager manager;
        private readonly IConfiguration config;

        public UserController(IUserAccountManager manager,IConfiguration config)
        {
            this.config = config;
            this.manager = manager;
        }

        /// <summary>
        /// This method is created for user registration.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserDetails(UserRegistration user)
        {
            string message;
            var result = this.manager.AddUserDetails(user);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successful";
                    return this.Ok(new { message, result });
                }
                message = "Details adding can't be possible";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method  is created for user login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLogin login)
        {
            string message, jsonToken;
            var result = this.manager.Login(login);
            try
            {
                if (result != null)
                {

                    jsonToken = GenerateToken(result , "User");
                    message = "Successful";
                    return this.Ok(new { message, result,jsonToken });
                }
                message = "Please check email and password and try again!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This meythod is creating for reset password.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string email,string password)
        {
            string message;
            var result = this.manager.ResetPassword(email,password);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successful";
                    return this.Ok(new { message, result });
                }
                message = "Resetting the password can't be done,something went wrong.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created for generating token for user login.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GenerateToken(UserLogin login, string type)
        {
            
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("Email", login.Email.ToString()));
                claims.Add(new Claim("Password", login.Password.ToString()));
                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}