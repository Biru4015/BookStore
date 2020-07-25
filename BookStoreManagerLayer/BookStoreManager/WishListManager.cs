using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer.WishListModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.BookStoreManager
{
    public class WishListManager: IWishListManager
    {
        private readonly IWishListRepository wishListRepository ;

        public WishListManager(IWishListRepository wishListRepository)
        {
            this.wishListRepository = wishListRepository;
        }

        public AddToWishListDetails AddToWishList(int UserId, int BookId, int Quantity)
        {
            return this.wishListRepository.AddToWishList(UserId,BookId,Quantity);
        }

        public List<CustomerWishListDetails> ViewWishListDetails(int UserId)
        {
            return this.wishListRepository.ViewWishListDetails(UserId);
        }

        public bool DeleteFromWishList(int UserId, int WishListId)
        {
            return this.wishListRepository.DeleteFromWishList(UserId, WishListId);
        }
    }
}
