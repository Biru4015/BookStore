using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.BookStoreRepository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Trusted_Connection=True";
        private readonly IConfiguration configuration;
        public UserAccountRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object AddUserDetails(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return "registration done successfully.";
            }
        }

        public object ResetPassword(string email)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spResetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

               

                con.Open();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return "reset password done successfully.";
            }
        }

        public object UserLogin(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spLogin", con);

                cmd.CommandType = CommandType.StoredProcedure;
                int count = 0;
                con.Open();
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Email = rdr["Email"].ToString();
                    Password = rdr["Password"].ToString();
                    count++;
                }
                con.Close();
                if (count >= 1)
                {
                    return "Login in done successfully.";
                }
                return "Please check your email and password";
            }
        }
    }
}