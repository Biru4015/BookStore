using BookStoreManagerLayer.IBookStoreManager;
using BookStoreModelLayer.BooksModel;
using BookStoreRepositoryLayer.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.BookStoreManager
{
    public class BookStoreDetailsManager: IBookStoreDetailsManager
    {
        private readonly IBookStoreDetailsRepository detailsRepository;

        public BookStoreDetailsManager(IBookStoreDetailsRepository detailsRepository)
        {
            this.detailsRepository = detailsRepository;
        }

        public object AddBookDetails(BooksDetail booksDetail)
        {
            return this.detailsRepository.AddBookDetails(booksDetail);
        }

        public List<BooksDetail> GetAllBooksDetails()
        {
            return this.detailsRepository.GetAllBooksDetails();
        }

        public bool DeleteBookDetailsByBookId(int bookId)
        {
            return this.detailsRepository.DeleteBookDetailsByBookId(bookId);
        }

        public object GetBookDetailsByBookId(int bookId)
        {
            return this.detailsRepository.GetBookDetailsByBookId(bookId);
        }
    }
}
