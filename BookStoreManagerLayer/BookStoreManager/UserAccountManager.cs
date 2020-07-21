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

        public object AddUserDetails(UserRegistration user)
        {
            return this.userAccountRepository.AddUserDetails(user);
        }

        public object ResetPassword(string email)
        {
            return this.userAccountRepository.ResetPassword(email);
        }

        public UserLogin Login(UserLogin login)
        {
            return this.userAccountRepository.Login(login);
        }
    }
}
