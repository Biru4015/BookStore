using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using BookStoreModelLayer.CartModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStoresApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public IBookCartManager manager;
        private readonly IConfiguration config;

        public CartController(IBookCartManager manager, IConfiguration config)
        {
            this.config = config;
            this.manager = manager;
        }
        [HttpPost]
        public IActionResult AddCartDetails(Cart cart)
        {
            string message;
            var result = this.manager.AddCartDetails(cart);
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

        [HttpGet]
        public IActionResult GetAllBooksFromCart(string Email)
        {
            string message;
            var result = this.manager.GetAllBooksFromCart(Email);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successful";
                    return this.Ok(new { message, result });
                }
                message = "Please enter correct email,and retry!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCartDetailsByCartId(int cartId)
        {
            string message;
            try
            {
                if (this.manager.DeleteCartDetailsByCartId(cartId))
                {
                    message = "Successful";
                    return this.Ok(new { message });
                }
                message = "Cart id is not match with our database.Please give correct CartId.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }
    }
}