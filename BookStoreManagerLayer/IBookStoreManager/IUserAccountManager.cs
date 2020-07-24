using BookStoreModelLayer.AccountModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    /// <summary>
    /// This is manager interface for user account.
    /// </summary>
    public interface IUserAccountManager
    {
        /// <summary>
        /// Registration for new User
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        object AddUserDetails(UserRegistration user);

        /// <summary>
        /// Login for User
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        UserLogin Login(UserLogin login);

        /// <summary>
        /// Resetpassword for User
        /// </summary>
        /// <param name="userReset"></param>
        /// <returns></returns>
        object ResetPassword(string email,string password);
    }
}
