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
    /// <summary>
    /// This  class contains the code for repository part of cart.
    /// </summary>
    public class CartRepository : ICartRepository
    {
        private readonly IConfiguration configuration;
        public CartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method  is created for adding cart details .
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        public object AddCartDetails(Cart cartModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
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

        /// <summary>
        /// This method is created for deleting cart details by cart Id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public bool DeleteCartDetailsByCartId(int cartId)
        {
           try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
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

        /// <summary>
        /// This method is created for getting all book details from cart.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<CartBookJoinModel> GetAllBooksFromCart(string email)
        {
            try
            {
                List<CartBookJoinModel> cartlist = new List<CartBookJoinModel>();
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
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

        /// <summary>
        /// This method is created for moving wishlist to cart.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="WishListId"></param>
        /// <returns></returns>
        public CartBookJoinModel WishListToCart(int UserId, int WishListId)
        {
            CartBookJoinModel cart = new CartBookJoinModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand command = new SqlCommand("spWishListToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@WishListId", WishListId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cart.CartId = Convert.ToInt32(reader["CartId"].ToString());
                        cart.BookId = Convert.ToInt32(reader["BookId"].ToString());
                        cart.BookName = reader["BookName"].ToString();
                        cart.Catagory = reader["Catagory"].ToString();
                        cart.AuthorName = reader["AuthorName"].ToString();
                        cart.BookImage = reader["BookImage"].ToString();
                        cart.Price = Convert.ToDouble(reader["Price"].ToString());
                        cart.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        cart.Rating = Convert.ToDouble(reader["Rating"].ToString());
                    }
                }
                return cart;
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }
    }
}