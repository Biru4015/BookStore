using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    public interface IUserAccountManager
    {
        /// <summary>
        /// Registration for new User
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        object AddUserDetails(User user);

        /// <summary>
        /// Login for User
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Object UserLogin(string email,string password);

        /// <summary>
        /// Resetpassword for User
        /// </summary>
        /// <param name="userReset"></param>
        /// <returns></returns>
        object ResetPassword(string email);
    }
}
