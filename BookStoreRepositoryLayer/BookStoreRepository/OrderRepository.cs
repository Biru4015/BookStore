using BookStoreModelLayer;
using BookStoreModelLayer.OrderModel;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStoreRepositoryLayer.BookStoreRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration configuration;
        public OrderRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method is created for place the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <returns></returns>
        public OrderDetails PlaceOrder(int BookId, int CartId,int UserId)
        {
            OrderDetails details = new OrderDetails();
            try
            {

                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spPlaceOrder", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        details.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                        details.CartId = Convert.ToInt32(reader["CartId"].ToString());
                        details.UserId = Convert.ToInt32(reader["UserId"].ToString());
                        details.BookId = Convert.ToInt32(reader["BookId"].ToString());
                        details.BookName = reader["BookName"].ToString();
                        details.AuthorName = reader["AuthorName"].ToString();
                        details.Address = reader["Address"].ToString();
                        details.City = reader["City"].ToString();
                        details.PhoneNumber = reader["PhoneNumber"].ToString();
                        details.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                        details.OrderPlaced = Convert.ToBoolean(reader["OrderPlaced"].ToString());
                        details.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                        details.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"].ToString());
                        details.BookImage = reader["BookImage"].ToString();
                    }
                    connection.Close();
                    return details;
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method is created for veiw the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OrderDetails> ViewOrderPlaced(int UserId)
        {
            List<OrderDetails> list = new List<OrderDetails>();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spViewOrder", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDetails details = new OrderDetails();
                        details.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                        details.CartId = Convert.ToInt32(reader["CartId"].ToString());
                        details.UserId = Convert.ToInt32(reader["UserId"].ToString());
                        details.BookId = Convert.ToInt32(reader["BookId"].ToString());
                        details.BookName = reader["BookName"].ToString();
                        details.AuthorName = reader["AuthorName"].ToString();
                        details.Address = reader["Address"].ToString();
                        details.City = reader["City"].ToString();
                        details.PinCode = Convert.ToInt32(reader["PinCode"].ToString());
                        details.PhoneNumber = reader["PhoneNumber"].ToString();
                        details.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                        details.OrderPlaced = Convert.ToBoolean(reader["OrderPlaced"].ToString());
                        details.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                        details.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"].ToString());
                        details.BookImage = reader["BookImage"].ToString();
                        list.Add(details);
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
        /// This method is created for cancel the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public bool CancelOrder(int UserId, int OrderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spSelectUserIdOrderId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            SqlCommand command = new SqlCommand("spCancelOrder", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@UserId", UserId);
                            command.Parameters.AddWithValue("@OrderId", OrderId);
                            connection.Open();
                            int b = command.ExecuteNonQuery();
                            connection.Close();
                            return false;
                        }
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method is created for differents address for order place.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BookId"></param>
        /// <param name="CartId"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="PinCode"></param>
        /// <returns></returns>
        public OrderInformation PlaceOrderDiffrentAddress(int UserId,int BookId, int CartId, string Address, string City, int PinCode)
        {
            OrderInformation details = new OrderInformation();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spPlaceOrderByAddress", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@City", City);
                    cmd.Parameters.AddWithValue("@PinCode", PinCode);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        details.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                        details.CartId = Convert.ToInt32(reader["CartId"].ToString());
                        details.UserId = Convert.ToInt32(reader["UserId"].ToString());
                        details.BookId = Convert.ToInt32(reader["BookId"].ToString());
                        details.BookName = reader["BookName"].ToString();
                        details.AuthorName = reader["AuthorName"].ToString();
                        details.Address = reader["Address"].ToString();
                        details.City = reader["City"].ToString();
                        details.PinCode = Convert.ToInt32(reader["PinCode"].ToString());
                        details.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                        details.OrderPlaced = Convert.ToBoolean(reader["OrderPlaced"].ToString());
                        details.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                        details.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"].ToString());
                        details.BookImage = reader["BookImage"].ToString();
                    }
                    connection.Close();
                    return details;
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }
        }

        /// <summary>
        /// This method is created for Sendind mail to user.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public bool EmailOrderNumber(int UserId, int ordernumber)
        {
            string Email = GetEmailId(UserId);
            string messagecontent = "your order has been placed.Thanks for shopping with us your order number is  " + ordernumber + " keep it for future reference";

            //// for sending message in MSMQ
            MessageQueue msgqueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msgqueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msgqueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();

            message.Formatter = new BinaryMessageFormatter();
            message.Body = messagecontent;
            msgqueue.Label = "your order number";
            msgqueue.Send(message);

            //// for reading message from MSMQ
            var receivequeue = new MessageQueue(@".\Private$\MyQueue");
            var receivemsg = receivequeue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();

            string linktobesend = receivemsg.Body.ToString();
            if (Sendmail(Email, linktobesend))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method is created for send mail
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool Sendmail(string email, string message)
        {

            MailMessage mailmessage = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mailmessage.From = new MailAddress("rambirendra12@gmail.com");
            mailmessage.To.Add(new MailAddress(email));
            mailmessage.Subject = "Order Confirmation";
            mailmessage.IsBodyHtml = true;
            mailmessage.Body = message;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("rambirendra12@gmail.com", "Rama@123");
            smtp.EnableSsl = true;
            smtp.Send(mailmessage);
            return true;
        }

        /// <summary>
        /// This method is created for fetching email from database using userid.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        private string GetEmailId(int UserId)
        {
            string email = string.Empty;
            try
            {

                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("GetEmail", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    { 
                        email = reader["Email"].ToString();
                    }
                    connection.Close();
                    return email;
                }
            }
            catch (CustomException exception)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, exception.Message);
            }

        }
    }
}