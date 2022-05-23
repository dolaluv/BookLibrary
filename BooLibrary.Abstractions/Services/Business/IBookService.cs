using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Abstractions.Services.Business
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<StatusMessage> CreateBook(BookDto bookDto);
        Task<StatusMessage> UpdateBook(int Id, BookDto bookDto);
        Task<StatusMessage> AddBooksCategory(List<BookCategoryDto> bookCategoryDtos);
        Task<StatusMessage> AddBooksToFavourite(List<FavouriteDto> favouriteDtos);
        Task<bool> DeleteBookByID(int id);
    }
}
