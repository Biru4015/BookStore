using BookStoreModelLayer;
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
    /// <summary>
    /// This class contains repository part of user account details and login
    /// </summary>
    public class UserAccountRepository : IUserAccountRepository
    {
        
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Trusted_Connection=True";
        private readonly IConfiguration configuration;
        public UserAccountRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method is created for adding user details.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public object AddUserDetails(UserRegistration user)
        {
            try
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
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method is created for reset pasword of users.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public object ResetPassword(string email,string password)
        {
           try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return "reset password done successfully.";
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method is created for login user.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UserLogin Login(UserLogin login)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {

                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            con.Close();
                            return login;
                        }
                    }
                    con.Close();
                    return null;
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }
    }
}