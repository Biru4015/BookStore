using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer.CartModel
{
    public class CartBookJoinModel
    {
        [Required]
        public int CartId { get; set; }

        [Required(ErrorMessage ="Please Enter valid BookId")]
        public int BookId { get; set; }

        [Required]
        public int SelectBookQuantity { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Author Name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Catagory")]
        public string Catagory { get; set; }

        [Required]
        public string BookImage { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
