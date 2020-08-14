using BookStoreModelLayer.AccountModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer
{
    public class BookDBContext : IdentityDbContext<ApplicationUser>
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }
        public DbSet<Registration> LoginTable
        {
            get; set;
        }
    }
}
