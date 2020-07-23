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
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        public IBookStoreDetailsManager manager;
        private readonly IConfiguration config;

        public BookStoreController(IBookStoreDetailsManager manager, IConfiguration config)
        {
            this.config = config;
            this.manager = manager;
        }

       
        [HttpPost]
        public IActionResult AddBookDetails(BooksDetail booksDetail)
        {
            string message;
            var result = this.manager.AddBookDetails(booksDetail);
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
        public IActionResult GetAllBooksDetails()
        {
            string message;
            var result = this.manager.GetAllBooksDetails();
            try
            {
                if (!result.Equals(null))
                {
                    message = "Successful";
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
                    message = "Successful";
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

        [HttpDelete]
        public IActionResult DeleteBookDetailsByBookId(int bookId)
        {
            string message;  
            try
            {
                if (this.manager.DeleteBookDetailsByBookId(bookId))
                {
                    message = "Successful";
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