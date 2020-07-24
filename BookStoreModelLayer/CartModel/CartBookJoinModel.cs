using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.CartModel
{
    /// <summary>
    /// This class contains the model code for join book deetails and cart.
    /// </summary>
    public class CartBookJoinModel
    {
        /// <summary>
        /// This is cart id
        /// </summary>
        [Required]
        public int CartId { get; set; }

        /// <summary>
        /// This is book Id
        /// </summary>
        [Required(ErrorMessage ="Please Enter valid BookId")]
        public int BookId { get; set; }

        /// <summary>
        /// This is quantity of book.
        /// </summary>
        [Required]
        public int SelectBookQuantity { get; set; }

        /// <summary>
        /// This is Book Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Book Name")]
        public string BookName { get; set; }

        /// <summary>
        /// This is Author Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Author Name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// This is price  of book.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Price")]
        public double Price { get; set; }

        /// <summary>
        /// This is quantity of book.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// This is catagory of book
        /// </summary>
        [Required(ErrorMessage = "Please Enter Valid Catagory")]
        public string Catagory { get; set; }

        /// <summary>
        /// This Book image
        /// </summary>
        [Required]
        public string BookImage { get; set; }

        /// <summary>
        /// This is  rating of book.
        /// </summary>
        [Required]
        public double Rating { get; set; }
    }
}
