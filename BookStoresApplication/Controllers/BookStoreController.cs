using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStoresApplication.Controllers
{
    /// <summary>
    /// This is Book Store controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        public IBookStoreDetailsManager manager;

        public BookStoreController(IBookStoreDetailsManager manager)
        {
            this.manager = manager;
        }

        MSMQ msmq = new MSMQ();

        /// <summary>
        /// This method is adding book details.
        /// </summary>
        /// <param name="booksDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBookDetails(BooksDetail booksDetail)
        {
            string message;
            var result = this.manager.AddBookDetails(booksDetail);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Book details added successfully.";
                    msmq.SendMessage("Books name " + booksDetail.BookName + " added successfully.", result);
                    return this.Ok(new { message, result });
                }
                message = "Please insert correct book details.!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method  is getting all book details from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooksDetails()
        {
            string message;
            var result = this.manager.GetAllBooksDetails();
            try
            {
                if (!result.Equals(null))
                {
                    message = "All books are shown....";
                    return this.Ok(new { message, result });
                }
                message = "Something went wrong please try again!!";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }

        /// <summary>
        /// This method  is getting book details of gievn bookId from database.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchBookByBookId/{bookId}")]
        public IActionResult GetBookDetailsByBookId(int bookId)
        {
            string message;
            var result = this.manager.GetBookDetailsByBookId(bookId);
            try
            {
                if (result !=null)
                {
                    message = "The book details of given bookId is..";
                    return this.Ok(new { message, result });
                }
                message = "Book id is not match with our database.Please give correct book id.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }

        /// <summary>
        /// This method  is deleting book details of  given book id.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBookDetailsByBookId(int bookId)
        {
            string message;  
            try
            {
                if (this.manager.DeleteBookDetailsByBookId(bookId))
                {
                    message = "Successfully deleted book details of given bookId.";
                    return this.Ok(new { message});
                }
                message = "Book id is not match with our database.Please give correct book id.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.OPTIONS_NOT_MATCH);
            }
        }
    }
}