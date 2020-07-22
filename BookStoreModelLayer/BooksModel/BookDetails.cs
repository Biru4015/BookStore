using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModel
{
    public class BooksDetail
    {
        
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Author Name")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
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
