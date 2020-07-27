using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.AccountModel
{
    /// <summary>
    /// This class contains the code for user registration.
    /// </summary>
    public class UserRegistration
    {
        /// <summary>
        /// This is user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// This is user first name
        /// </summary>
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Your First Name should only contain Alphabets!")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        /// <summary>
        /// This is user last name
        /// </summary>
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Your Last Name should only contain Alphabets!")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        /// <summary>
        /// This  is user email
        /// </summary>
        [Required(ErrorMessage = "EmailAddress is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// This is user password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// This is Address of users.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// This is city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// This is pincode of user
        /// </summary>
        public int PinCode { get; set; }

        /// <summary>
        /// This is  phone number of users.
        /// </summary>
        public string PhoneNumber { get; set; }

    }
}
