using BookStoreModelLayer.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IBookStoreRepository
{
    /// <summary>
    /// This interface contains cart repository method.
    /// </summary>
    public interface ICartRepository
    {
        /// <summary>
        /// This is aading cart details method.
        /// </summary>
        /// <param name="cartModel"></param>
        /// <returns></returns>
        object AddCartDetails(Cart cartModel);

        /// <summary>
        /// This is deleting cart details method by taking cart id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        bool DeleteCartDetailsByCartId(int cartId);

        /// <summary>
        /// This is getting all  book details from cart method.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<CartBookJoinModel> GetAllBooksFromCart(string email);

       
    }
}
