﻿using BookStoreModelLayer.CartModel;
using BookStoreModelLayer.WishListModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IBookStoreRepository
{
    public interface IWishListRepository
    {
        /// <summary>
        /// This method is created for adding wish list details.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BookId"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        AddToWishListDetails AddToWishList(int UserId, int BookId, int Quantity);

        /// <summary>
        /// This method is created for getting wishlist
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<CustomerWishListDetails> ViewWishListDetails(int UserId);

        /// <summary>
        /// This method is  created for deleting wish list.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="WishListId"></param>
        /// <returns></returns>
        bool DeleteFromWishList(int UserId, int WishListId);

        /// <summary>
        /// This method is created for move wishlist to cart.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="WishListId"></param>
        /// <returns></returns>
        CartBookJoinModel WishListToCart(int UserId, int WishListId);
    }
}
