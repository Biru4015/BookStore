using BookStoreModelLayer;
using BookStoreModelLayer.BooksModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.BookStoreRepository
{
    public class BookStoreDetailsRepository : IBookStoreDetailsRepository
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Trusted_Connection=True";
        private readonly IConfiguration configuration;
        public BookStoreDetailsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public object AddBookDetails(BooksDetail booksDetail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddBooksDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", booksDetail.BookId);
                    cmd.Parameters.AddWithValue("@BookName", booksDetail.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", booksDetail.AuthorName);
                    cmd.Parameters.AddWithValue("@Price", booksDetail.Price);
                    cmd.Parameters.AddWithValue("@Quantity", booksDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Catagory", booksDetail.Catagory);
                    cmd.Parameters.AddWithValue("@BookImage", booksDetail.BookImage);
                    cmd.Parameters.AddWithValue("@Rating", booksDetail.Rating);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return "successfully added book details.";
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        public List<BooksDetail> GetAllBooksDetails()
        {
           try
            {
                List<BooksDetail> bookstorelist = new List<BooksDetail>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spGetAllBookDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        BooksDetail book = new BooksDetail();
                        book.BookId = Convert.ToInt32(sqlreader["BookId"]);
                        book.BookName = sqlreader["BookName"].ToString();
                        book.AuthorName = sqlreader["AuthorName"].ToString();
                        book.Price = Convert.ToDouble(sqlreader["Price"]);
                        book.Quantity = Convert.ToInt32(sqlreader["Quantity"]);
                        book.Catagory = sqlreader["Catagory"].ToString();
                        book.BookImage = sqlreader["BookImage"].ToString();
                        book.Rating = Convert.ToDouble(sqlreader["Rating"]);
                        bookstorelist.Add(book);
                    }
                    connection.Close();
                }
                return bookstorelist;
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        public object GetBookDetailsByBookId(int bookId)
        {
            try
            {
                List<BooksDetail> bookstorelist = new List<BooksDetail>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spGetBookDetailsByBookId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", bookId);
                    connection.Open();
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        BooksDetail book = new BooksDetail();
                        book.BookId = Convert.ToInt32(sqlreader["BookId"]);
                        book.BookName = sqlreader["BookName"].ToString();
                        book.AuthorName = sqlreader["AuthorName"].ToString();
                        book.Price = Convert.ToDouble(sqlreader["Price"]);
                        book.Quantity = Convert.ToInt32(sqlreader["Quantity"]);
                        book.Catagory = sqlreader["Catagory"].ToString();
                        book.BookImage = sqlreader["BookImage"].ToString();
                        book.Rating = Convert.ToDouble(sqlreader["Rating"]);
                        bookstorelist.Add(book);
                    }
                    connection.Close();
                }
                if (bookstorelist.Capacity >= 1)
                    return bookstorelist;
                return null;
            }
            catch(CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION,exception.Message);
            }
        }

        public bool DeleteBookDetailsByBookId(int bookId)
        {
           try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spSelectBookId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", bookId);
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            SqlCommand command = new SqlCommand("spDeleteBookDetails", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@BookId", bookId);
                            connection.Open();
                            command.ExecuteNonQuery();
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
    }
}