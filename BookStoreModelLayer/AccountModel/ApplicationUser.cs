using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.AccountModel
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }

        public string Gender { get; set; }
    }
}
