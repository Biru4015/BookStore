using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using BookStoreModelLayer.AccountModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoresApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserAccountManager manager;

        public UserController(IUserAccountManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public IActionResult AddUserDetails(User user)
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

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(string email, string password)
        {
            string message;
            var result = this.manager.UserLogin(email, password);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successful";
                    return this.Ok(new { message, result });
                }
                message = "Please check email and password and try again!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string email)
        {
            string message;
            var result = this.manager.ResetPassword(email);
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
    }
}