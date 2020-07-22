using BookStoreModelLayer.BooksModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IBookStoreRepository
{
    public interface IBookStoreDetailsRepository
    {
        object AddBookDetails(BooksDetail booksDetail);

        List<BooksDetail> GetAllBooksDetails();

        object DeleteBookDetailsByBookId(int bookId);

        object GetBookDetailsByBookId(int bookId);
    }
}
