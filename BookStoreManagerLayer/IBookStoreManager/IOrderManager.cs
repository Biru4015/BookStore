using BookStoreModelLayer.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    public interface IOrderManager
    {
        /// <summary>
        ///This method  is created for place the order.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <returns></returns>
        OrderDetails PlaceOrder(int BookId, int CartId,int UserId);

        /// <summary>
        /// This method is created for placed the order from diffrents addresss
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CartId"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="PinCode"></param>
        /// <returns></returns>
        OrderInformation PlaceOrderDiffrentAddress(int UserId,int BookId, int CartId, string Address, string City, int PinCode);

        /// <summary>
        /// This method is created for veiwing the order.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<OrderDetails> ViewOrderPlaced(int UserId);

        /// <summary>
        /// This method is created for cancel the order
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        bool CancelOrder(int UserId, int OrderId);

        bool EmailOrderNumber(int UserId, int ordernumber);
    }
}
