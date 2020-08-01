using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using BookStoreModelLayer.CartModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoresApplication.Controllers
{
    /// <summary>
    /// This controller class is created for Order the books.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderManager manager;

        public OrderController(IOrderManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// This method is created for placed the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PlaceOrder(int BookId, int CartId,int UserId)
        {
            string message;
            var result = this.manager.PlaceOrder(BookId,CartId,UserId);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully placed ordered.";
                    manager.EmailOrderNumber(UserId, result.OrderId);
                    return this.Ok(new { message, result });
                }
                message = "Please given correct order details and try again....!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
        
        /// <summary>
        /// This method is created for place order on diffrents address
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="PinCode"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PlaceOrderByAddress")]
        public IActionResult PlaceOrderDiffrentAddress(int UserId,int BookId, int CartId, string Address, string City, int PinCode)
        {
            string message;
            var result = this.manager.PlaceOrderDiffrentAddress(UserId,BookId, CartId,Address,City,PinCode);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully placed ordered in given address details.";
                    manager.EmailOrderNumber(UserId, result.OrderId);
                    return this.Ok(new { message, result });
                }
                message = "Please given correct order details and try again....!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created for checking the order placed.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ViewOrderPlaced(int UserId)
        {
            string message;
            var result = this.manager.ViewOrderPlaced(UserId);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Order of given userId is :";
                    return this.Ok(new { message, result });
                }
                message = "Please enter correct UserId,and retry!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }

        /// <summary>
        /// This method is created for cancel the order.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult CancelOrder(int UserId, int OrderId)
        {
            string message;
            var result = this.manager.CancelOrder(UserId,OrderId);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Cancel the  order successfully.";
                    return this.Ok(new { message, result });
                }
                message = "Please enter correct UserId and OrderId and retry!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }
    }
}