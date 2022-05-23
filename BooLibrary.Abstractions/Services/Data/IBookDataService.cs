using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Abstractions.Services.Data
{
    public interface IBookDataService
    {
        Task<List<Book>> Get();
        Task<Book> GetBook(int id);
        Task<bool> CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> CreateBooksCategory(List<BookCategory> bookCategories);
        Task<bool> BookCategoryExist(BookCategory bookCategory);
        Task<bool> CreateBookFavourites(List<Favourite> favourites);
        Task<Book> RemoveBookByID(int id);

    }
}
