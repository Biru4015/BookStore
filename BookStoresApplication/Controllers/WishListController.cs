using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoresApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        public IWishListManager manager;

        public WishListController(IWishListManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// This method is created for Add to wish List  details.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddToWishList(int UserId, int BookId, int Quantity)
        {
            string message;
            var result = this.manager.AddToWishList(UserId,BookId,Quantity);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully added wish list details in database.";
                    return this.Ok(new { message, result });
                }
                message = "Please given correct wishList details and try again....!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is getting WishList of given UserId.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ViewWishListDetails(int UserId)
        {
            string message;
            var result = this.manager.ViewWishListDetails(UserId);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully shown all book details  in wishList of given UserId.";
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
        /// This method is deleting wishList of given userId and WishListId.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteFromWishList(int UserId, int WishListId)
        {
            string message;
            try
            {
                if (this.manager.DeleteFromWishList(UserId,WishListId))
                {
                    message = "Successfully deleted wishlist deatils of given userId and wishListId";
                    return this.Ok(new { message });
                }
                message = "WishLIst details is not match with our database.Please give correct UserId and WishList.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }

        /// <summary>
        /// This method is created for move wishlist to cart.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="WishListId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("WishListToCart/{WishListId}")]
        public IActionResult WishListToCart(int UserId, int WishListId)
        {
            string message;
            var result = this.manager.WishListToCart(UserId, WishListId);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successfully moved wishlist to cart.";
                    return this.Ok(new { message});
                }
                message = "Please given correct userid and wishlistid details and try again....!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
    }
}