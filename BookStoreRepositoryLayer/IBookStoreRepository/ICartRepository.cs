using BookStoreModelLayer.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IBookStoreRepository
{
    public interface ICartRepository
    {
        object AddCartDetails(Cart cartModel);
        bool DeleteCartDetailsByCartId(int cartId);
        List<CartBookJoinModel> GetAllBooksFromCart(string email);
    }
}
