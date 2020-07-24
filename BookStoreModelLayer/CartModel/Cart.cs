using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.CartModel
{
    /// <summary>
    /// This class contains the code for cart. 
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// This is cart id
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// This is book id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// This is quantity of book
        /// </summary>
        public int SelectBookQuantity { get; set; }

        /// <summary>
        /// This is user email
        /// </summary>
        public string Email { get; set; }
    }
}
