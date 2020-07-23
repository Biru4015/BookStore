using BookStoreModelLayer;
using BookStoreModelLayer.CartModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.BookStoreRepository
{
    public class CartRepository : ICartRepository
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Trusted_Connection=True";
        private readonly IConfiguration configuration;
        public CartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object AddCartDetails(Cart cartModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    command.Parameters.AddWithValue("@SelectBookQuantity", cartModel.SelectBookQuantity);
                    command.Parameters.AddWithValue("@Email", cartModel.Email);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return "Cart details added successfully...";
                }
            }
            catch(CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        public bool DeleteCartDetailsByCartId(int cartId)
        {
           try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spSelectCartId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            SqlCommand command = new SqlCommand("spDeleteCartDetailsByCartId", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@CartId", cartId);
                            connection.Open();
                            int b = command.ExecuteNonQuery();
                            connection.Close();
                            return true;
                        }
                    }
                    connection.Close();
                    return false;
                }
            }
            catch(CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        public List<CartBookJoinModel> GetAllBooksFromCart(string email)
        {
            try
            {
                List<CartBookJoinModel> cartlist = new List<CartBookJoinModel>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spGetAllBookFromCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        var cart = new CartBookJoinModel();
                        cart.BookId = Convert.ToInt32(sqlreader["BookId"]);
                        cart.CartId = Convert.ToInt32(sqlreader["CartId"]);
                        cart.SelectBookQuantity = Convert.ToInt32(sqlreader["SelectBookQuantity"]);
                        cart.BookName = sqlreader["BookName"].ToString();
                        cart.AuthorName = sqlreader["AuthorName"].ToString();
                        cart.Price = Convert.ToDouble(sqlreader["Price"]);
                        //cart.Quantity = Convert.ToInt32(sqlreader["Quantity"]);
                        cart.Catagory = sqlreader["Catagory"].ToString();
                        cart.BookImage = sqlreader["BookImage"].ToString();
                        cart.Rating = Convert.ToDouble(sqlreader["Rating"]);
                        cartlist.Add(cart);
                    }
                    connection.Close();
                }
                return cartlist;
            }
            catch(CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }
    }
}