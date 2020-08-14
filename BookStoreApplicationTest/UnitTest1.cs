using BookStoreManagerLayer.BookStoreManager;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreRepositoryLayer.BookStoreRepository;
using BookStoreRepositoryLayer.IBookStoreRepository;
using BookStoresApplication.Controllers;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;
using System;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Moq;
using Xunit.Sdk;
using BookStoreModelLayer.AccountModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplicationTest
{
    public class TestCases
    {


        //UserController userController;
        //CartController cartController;
        //BookStoreController bookStoreController;
        //WishListController wishListController;

        //private readonly IUserAccountManager userAccountManager;
        //private readonly IBookCartManager bookCartManager;
        //private readonly IBookStoreDetailsManager bookStoreDetailsManager;
        //private readonly IWishListManager wishListManager;

        //private readonly IUserAccountRepository userAccountRepository;
        //private readonly ICartRepository cartRepository;
        //private readonly IBookStoreDetailsRepository bookStoreDetailsRepository;
        //private readonly IWishListRepository wishListRepository;

        //public readonly IConfiguration configuration;

        //public TestCases()
        //{
        //    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        //   // configurationBuilder.AddJsonFile("appsettings.json");
        //    this.configuration = configurationBuilder.Build();
        //    userAccountRepository = new UserAccountRepository(configuration);
        //    userAccountManager = new UserAccountManager(userAccountRepository);
        //    userController = new UserController(userAccountManager, configuration);
        //    bookStoreDetailsRepository = new BookStoreDetailsRepository(configuration);
        //    bookStoreDetailsManager = new BookStoreDetailsManager(bookStoreDetailsRepository);
        //    bookStoreController = new BookStoreController(bookStoreDetailsManager);
        //    cartRepository = new CartRepository(configuration);
        //    bookCartManager = new BookCartManager(cartRepository);
        //    cartController = new CartController(bookCartManager);
        //}

        ////variable declared
        //bool SuccessTrue = true;
        //bool SuccessFalse = false;

        //[Fact]

        //public void UserRegistration_Returns_BadRequest()
        //{
        //    UserRegistration details = new UserRegistration()
        //    {
        //        FirstName = "",
        //        LastName = "",
        //        Email = "",
        //        Password = "",
        //        Address = "",
        //        City = "",
        //        PinCode =12,
        //        PhoneNumber = ""
        //    };
        //    //Act
        //    var result = userController.AddUserDetails(details) as BadRequestObjectResult;
        //   var dataResponse = JToken.Parse(JsonConvert.SerializeObject(result.Value));
        //    var responseSuccess = dataResponse["success"].ToObject<bool>();
        //    var responseMessage = dataResponse["message"].ToString();
        //    string message = "It cannot be Empty";
        //    //Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //    Assert.Equal(SuccessFalse, responseSuccess);
        //    Assert.Equal(message, responseMessage);
        //}
    }
}
