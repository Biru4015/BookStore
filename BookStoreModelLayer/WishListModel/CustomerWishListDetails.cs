using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.WishListModel
{
    public class CustomerWishListDetails
    {
        [Required]
        public int WishListId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsMoved { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public string BookImage { get; set; }
    }
}
