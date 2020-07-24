using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModel
{
    /// <summary>
    /// This class contains code for Book Details.
    /// </summary>
    public class BooksDetail
    {
        /// <summary>
        /// This is BOOK id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// This is Book Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Book Name")]
        public string BookName { get; set; }

        /// <summary>
        /// This is Author name of book
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Author Name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// This is book price
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Price")]
        public double Price { get; set; }

        /// <summary>
        /// This is quantity of book
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// This is  catagory of book.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Catagory")]
        public string Catagory { get; set; }

        /// <summary>
        /// This is book image
        /// </summary>
        [Required]
        public string BookImage { get; set; }

        /// <summary>
        /// This is rating of book.
        /// </summary>
        [Required]
        public double Rating { get; set; }
    }
}
