using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.WishListModel
{
    public class AddToWishListDetails
    {
        public int WishListId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Catagory { get; set; }

        public string AuthorName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
