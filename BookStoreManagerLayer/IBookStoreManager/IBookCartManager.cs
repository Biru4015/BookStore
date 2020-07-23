using BookStoreModelLayer.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    public interface IBookCartManager
    {
        object AddCartDetails(Cart cartModel);
        bool DeleteCartDetailsByCartId(int cartId);
        List<CartBookJoinModel> GetAllBooksFromCart(string email);
    }
}
