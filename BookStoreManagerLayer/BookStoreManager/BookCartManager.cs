using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer.CartModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.BookStoreManager
{
    public class BookCartManager: IBookCartManager
    {
        private readonly ICartRepository cartRepository;

        public BookCartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public object AddCartDetails(Cart cart)
        {
            return this.cartRepository.AddCartDetails(cart);
        }

        public bool DeleteCartDetailsByCartId(int cartId)
        {
            return this.cartRepository.DeleteCartDetailsByCartId(cartId);
        }

        public List<CartBookJoinModel> GetAllBooksFromCart(string Email)
        {
            return this.cartRepository.GetAllBooksFromCart(Email);
        }

        public CartBookJoinModel WishListToCart(int UserId, int WishListId)
        {
            return this.cartRepository.WishListToCart(UserId,WishListId);
        }
    }
}
