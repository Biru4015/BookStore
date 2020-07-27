using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.OrderModel
{
    public class OrderInformation
    {
        public int OrderId { get; set; }

        public int CartId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int PinCode { get; set; }

        public double TotalPrice { get; set; }

        public bool OrderPlaced { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string BookImage { get; set; }
    }
}
