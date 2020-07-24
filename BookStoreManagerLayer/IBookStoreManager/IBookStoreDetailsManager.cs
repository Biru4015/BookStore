using BookStoreModelLayer.BooksModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IBookStoreManager
{
    /// <summary>
    /// This is manager interface of book store details.
    /// </summary>
    public interface IBookStoreDetailsManager
    {
        object AddBookDetails(BooksDetail booksDetail);

        List<BooksDetail> GetAllBooksDetails();

        bool DeleteBookDetailsByBookId(int bookId);

        object GetBookDetailsByBookId(int bookId);
    }
}
