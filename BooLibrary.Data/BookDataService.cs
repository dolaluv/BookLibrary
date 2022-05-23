using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.Abstractions.Services.Data;
using BooLibrary.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Data
{
    public class BookDataService : IBookDataService
    {
        private readonly ApplicationDbContext _db;

        public BookDataService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> BookCategoryExist(BookCategory bookCategory)
        {
            BookCategory book = new BookCategory();
            try
            {
                book = _db.BooksCategory.FirstOrDefault(f => f.BookId == bookCategory.BookId && f.CategoryId == bookCategory.CategoryId);
            }
            catch (Exception ex)
            {
                throw;
            }
            return book == null? false : true;
        }

        public async Task<bool> CreateBook(Book book)
        {
            var result = 0;
            try
            {
                _db.Books.Add(book);
              result =  _db.SaveChanges();
              
            }
            catch (Exception ex)
            {
                throw;
            }
            return result > 0;
        }

        public async Task<bool> CreateBooksCategory(List<BookCategory> bookCategories)
        {
            var result = 0;
            try
            {
                 _db.BooksCategory.AddRangeAsync(bookCategories);
                result =   _db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return result > 0;
        }

        public async Task<List<Book>> Get()
        {
            List<Book> books = new List<Book>();
            try
            {
                books = _db.Books.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return books;
        }

        public async Task<Book> GetBook(int id)
        {
            Book book = new Book();
            try
            {
                book = _db.Books.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return book;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var result = 0;
            try
            {
                _db.Books.Update(book);
                result = _db.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw;
            }
            return result > 0;
        }
    }

}
