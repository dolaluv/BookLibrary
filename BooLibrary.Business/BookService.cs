using AutoMapper;
using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.Abstractions.Services.Business;
using BooLibrary.Abstractions.Services.Data;
using BooLibrary.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Business
{
    public class BookService : IBookService
    {
        private readonly IBookDataService bookDataService;
        private readonly ICategoryDataService categoryDataService;
        private readonly IMapper _mapper;

        public BookService(IBookDataService bookDataService, IMapper mapper, ICategoryDataService categoryDataService)
        {
            this.bookDataService = bookDataService;
            _mapper = mapper;
            this.categoryDataService = categoryDataService;
        }

        public async Task<StatusMessage> AddBooksCategory(List<BookCategoryDto> bookCategoryDtos)
        {
            StatusMessage statusMessage = new StatusMessage();
            List<BookCategory> _bookCategories = new List<BookCategory>();
            try
            {
                var bookCategories = _mapper.Map<List<BookCategoryDto>, List<BookCategory>>(bookCategoryDtos);
                foreach (var bookCategory in bookCategories)
                {
                    var CategoryExist = await this.categoryDataService.GetCategory(bookCategory.CategoryId);
                    var BookExist =  await this.bookDataService.GetBook(bookCategory.BookId);
                    if (CategoryExist == null || BookExist == null)
                        continue;

                    var BookCategoryExist = await this.bookDataService.BookCategoryExist(bookCategory);
                    if (BookCategoryExist)
                        continue;
                    _bookCategories.Add(bookCategory);
                }
                if(_bookCategories.Count <= 0)
                {
                    statusMessage.Message = "No Linking Book to Update";
                    statusMessage.Status = false;
                    return statusMessage;
                }
                statusMessage.Status = await this.bookDataService.CreateBooksCategory(_bookCategories);
                statusMessage.Message = statusMessage.Status ? "Books Added to Category" : "Unable to add Book to category";
            }
            catch (Exception ex)
            {
                throw;
            }

            return statusMessage;
        }

        public async Task<StatusMessage> AddBooksToFavourite(List<FavouriteDto> favouriteDtos)
        {
            StatusMessage statusMessage = new StatusMessage();
            List<Favourite> _favourites = new List<Favourite>();
            try
            {
                var favourites = _mapper.Map<List<FavouriteDto>, List<Favourite>>(favouriteDtos);
                foreach (var favourite in favourites)
                { 
                    var BookExist = await this.bookDataService.GetBook(favourite.BookId);
                    if ( BookExist == null)
                        continue;

                    _favourites.Add(favourite);
                }
                if (_favourites.Count <= 0)
                {
                    statusMessage.Message = "No Linking Book to add to favourites";
                    statusMessage.Status = false;
                    return statusMessage;
                }
                statusMessage.Status = await this.bookDataService.CreateBookFavourites(_favourites);
                statusMessage.Message = statusMessage.Status ? "Books Added to Favourites" : "Unable to add Book to Favourite";
            }
            catch (Exception ex)
            {
                throw;
            }

            return statusMessage;
        }

        public async Task<StatusMessage> CreateBook(BookDto bookDto)
        {
            StatusMessage statusMessage = new StatusMessage();
            try
            {
                var book = _mapper.Map<BookDto, Book>(bookDto);

                statusMessage.Status = await this.bookDataService.CreateBook(book);
                statusMessage.Message = statusMessage.Status ? "Book Added" : "Unable to add Book";
            }
            catch (Exception ex)
            {
                throw;
            }

            return statusMessage;
        }

        public Task<bool> DeleteBookByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBook(int id)
        {
            Book book = new Book();
            try
            {
                book = await this.bookDataService.GetBook(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return book==null ? new Book(): book;
        }

        public async Task<List<Book>> GetBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                books = await this.bookDataService.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
            return books;
        }

        public async Task<StatusMessage> UpdateBook(int Id, BookDto bookDto)
        {
            StatusMessage statusMessage = new StatusMessage();
            try
            {
                var FindBook = await this.bookDataService.GetBook(Id);
                if (FindBook == null)
                {
                    statusMessage.Message = "Unable to find Book";
                    return statusMessage;
                }
                FindBook.BookName = bookDto.BookName;
                FindBook.BookDescription = bookDto.BookDescription;
                statusMessage.Status = await this.bookDataService.UpdateBook(FindBook);
                statusMessage.Message = statusMessage.Status ? "Book  Updated" : "Unable to update Book";
            }
            catch (Exception ex)
            {
                throw;
            }

            return statusMessage;
        }
    }
}
