using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.CartModel
{
    public class Cart
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int SelectBookQuantity { get; set; }
        public string Email { get; set; }
    }
}
