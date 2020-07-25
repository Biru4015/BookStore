using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.WishListModel
{
    /// <summary>
    /// This class contains the code for add wish list details.
    /// </summary>
    public class AddToWishListDetails
    {
        /// <summary>
        /// This  is wishlistid
        /// </summary>
        public int WishListId { get; set; }

        /// <summary>
        /// This is user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// This is book id.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// This is book name.
        /// </summary>
        public string BookName { get; set; }

        public string Catagory { get; set; }

        /// <summary>
        /// This is AuthorName.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// This is price of book.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// This  is quantity of book.
        /// </summary>
        public int Quantity { get; set; }
    }
}
