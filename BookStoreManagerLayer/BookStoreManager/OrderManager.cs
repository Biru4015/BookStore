using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer.OrderModel;
using BookStoreRepositoryLayer.BookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.BookStoreManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public OrderDetails PlaceOrder(int BookId, int CartId,int UserId) 
        {
            return this.orderRepository.PlaceOrder(BookId,CartId,UserId);
        }

        public OrderInformation PlaceOrderDiffrentAddress(int UserId,int BookId, int CartId, string Address, string City, int PinCode)
        {
            return this.orderRepository.PlaceOrderDiffrentAddress(UserId,BookId, CartId, Address, City, PinCode);
        }

        public List<OrderDetails> ViewOrderPlaced(int UserId)
        {
            return this.orderRepository.ViewOrderPlaced(UserId);
        }

        public bool CancelOrder(int UserId, int OrderId)
        {
            return this.orderRepository.CancelOrder(UserId,OrderId);
        }
    }
}
