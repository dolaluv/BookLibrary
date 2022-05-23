using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.Abstractions.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Data.Mock
{
    public class MockBookDataService : IBookDataService
    {
        public Task<bool> BookCategoryExist(BookCategory bookCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateBooksCategory(List<BookCategory> bookCategories)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
