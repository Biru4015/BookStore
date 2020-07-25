using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.WishListModel
{
    /// <summary>
    /// This class contains the code for Customer WishList details.
    /// </summary>
    public class CustomerWishListDetails
    {
        /// <summary>
        /// This is wishlist id.
        /// </summary>
        [Required]
        public int WishListId { get; set; }

        /// <summary>
        /// This is bookId.
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// This is BookName
        /// </summary>
        [Required]
        public string BookName { get; set; }

        /// <summary>
        /// This is AuthorName
        /// </summary>
        [Required]
        public string AuthorName { get; set; }

        /// <summary>
        /// This is price of book.
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// This  is book Quantity.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsMoved { get; set; }

        /// <summary>
        /// This is checking deleted details or not.
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// This is date of creation.
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// This is date of modified
        /// </summary>
        [Required]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// This is BookImage
        /// </summary>
        [Required]
        public string BookImage { get; set; }
    }
}
