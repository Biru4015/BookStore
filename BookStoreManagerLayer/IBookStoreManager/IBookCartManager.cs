using BookStoreModelLayer.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    /// <summary>
    /// This is manager interface of book cart.
    /// </summary>
    public interface IBookCartManager
    {
        object AddCartDetails(Cart cartModel);

        bool DeleteCartDetailsByCartId(int cartId);
        
        List<CartBookJoinModel> GetAllBooksFromCart(string email);

        CartBookJoinModel WishListToCart(int UserId, int WishListId);
    }
}
