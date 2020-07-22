using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModel
{
    public class PurchaseDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("UserRegistration")]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Please Enter Home Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter PinCode ")]
        [RegularExpression(@"[0-9]{6}|[0-9]{3}\s[0-9]{3}", ErrorMessage = "Please Enter 6 Digit Number Only")]
        public int PinCode { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter 10 Digit Number Only")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }

        public string Book { get; set; }

        public DateTime PurchaseData { get; set; }

        public double TotalAmount { get; set; }

    }
}
