using BookStoreModelLayer;
using BookStoreModelLayer.CartModel;
using BookStoreModelLayer.WishListModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.BookStoreRepository
{
    public class WishListRepository: IWishListRepository
    {
        /// <summary>
        /// Configuration initialized
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="configuration"></param>
        public WishListRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method is created for adding book details in wishlist.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BookId"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        public AddToWishListDetails AddToWishList(int UserId, int BookId, int Quantity)
        {
            AddToWishListDetails WishList = new AddToWishListDetails();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spAddTowishList", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    connection.Open();

                    SqlDataReader sqlreader = cmd.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        WishList.WishListId = Convert.ToInt32(sqlreader["WishListId"].ToString());
                        WishList.UserId = Convert.ToInt32(sqlreader["UserId"].ToString());
                        WishList.BookId = Convert.ToInt32(sqlreader["BookId"].ToString());
                        WishList.BookName = sqlreader["BookName"].ToString();
                        WishList.Catagory = sqlreader["Catagory"].ToString();
                        WishList.AuthorName = sqlreader["AuthorName"].ToString();
                        WishList.Price = Convert.ToDouble(sqlreader["Price"].ToString());
                        WishList.Quantity = Convert.ToInt32(sqlreader["Quantity"].ToString());
                    }
                    connection.Close();
                }
                return WishList;
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method  is  created for viewing wishlist.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<CustomerWishListDetails> ViewWishListDetails(int UserId)
        {
            List<CustomerWishListDetails> list = new List<CustomerWishListDetails>();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spViewWishListById", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerWishListDetails WishList = new CustomerWishListDetails();
                        WishList.WishListId = Convert.ToInt32(reader["WishListId"].ToString());
                        WishList.BookId = Convert.ToInt32(reader["BookId"].ToString());
                        WishList.BookName = reader["BookName"].ToString();
                        WishList.AuthorName = reader["AuthorName"].ToString();
                        WishList.Price = Convert.ToDouble(reader["Price"].ToString());
                        WishList.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                        WishList.IsMoved = Convert.ToBoolean(reader["IsMoved"]);
                        WishList.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        WishList.DateCreated = Convert.ToDateTime(reader["DateCreatedWL"].ToString());
                        WishList.DateModified = Convert.ToDateTime(reader["DateModifiedWL"].ToString());
                        WishList.BookImage = reader["BookImage"].ToString();
                        list.Add(WishList);
                    }
                    connection.Close();
                }
                return list;
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method  is ctreated for deleting wish list.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="WishListId"></param>
        /// <returns></returns>
        public bool DeleteFromWishList(int UserId, int WishListId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spSelectUserIdWhishListId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@WishListId", WishListId);
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            SqlCommand command = new SqlCommand("spDeleteFromWishListByTWishListId", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@UserId", UserId);
                            command.Parameters.AddWithValue("@WishList", WishListId);
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
            catch (CustomException exception)
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