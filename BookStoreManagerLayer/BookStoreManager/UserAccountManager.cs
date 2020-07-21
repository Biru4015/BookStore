using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer.AccountModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.BookStoreManager
{
    public class UserAccountManager: IUserAccountManager
    {
        private readonly IUserAccountRepository userAccountRepository;

        public UserAccountManager(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public object AddUserDetails(User user)
        {
            return this.userAccountRepository.AddUserDetails(user);
        }

        public object ResetPassword(string email)
        {
            return this.userAccountRepository.ResetPassword(email);
        }

        public object UserLogin(string email,string password)
        {
            return this.userAccountRepository.UserLogin(email,password);
        }
    }
}
