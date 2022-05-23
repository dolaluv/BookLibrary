using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.Abstractions.Services.Business;
using BooLibrary.API.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("fetch-books")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await bookService.GetBooks();
                if (categories != null)
                    return Ok(StandardResponse.Ok("Successfully fetch Books", categories));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
        }


        [HttpGet("GetBookById/{Id}")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            try
            {
                var book = await bookService.GetBook(Id);
                if (book != null && !string.IsNullOrEmpty(book.BookName))
                    return Ok(StandardResponse.Ok("Successfully fetched Book", book));
                else if (book != null && string.IsNullOrEmpty(book.BookName))
                    return Ok(StandardResponse.Ok("Unable to Find Category"));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
        }


       
        [HttpPost("CreateBook")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> CreateCategory([FromBody] BookDto bookDto)
        {
            try
            {
                var result = await bookService.CreateBook(bookDto);
                if (result != null)
                    return Ok(StandardResponse.Ok("Added Successfully", result));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }

        }

    
        [HttpPut("UpdateBook/{Id}")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> UpdateCategory([FromBody] BookDto bookDto, int Id)
        {
            try
            {
                var result = await bookService.UpdateBook(Id, bookDto);
                if (result != null && result.Status)
                    return Ok(StandardResponse.Ok(" Updated Successfully", result));
                else if(!result.Status)
                    return Ok(StandardResponse.Ok(" Updated Failed", result)); 
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }

        }

        [HttpPost("AddBooksToCategory")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> BookMapCategory([FromBody] List<BookCategoryDto> bookCategoryDtos)
        {
            try
            { 
                try
                {
                    var result = await bookService.AddBooksCategory(bookCategoryDtos);
                    if (result != null && result.Status)
                        return Ok(StandardResponse.Ok(" Added Successfully", result));
                    else if (!result.Status)
                        return Ok(StandardResponse.Ok("Failed", result));
                    else
                        return BadRequest(StandardResponse.BadRequest("An error occured"));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }

        }
        [HttpPost("AddBooksToFavourite")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> BooksToFavourite([FromBody] List<FavouriteDto> favouriteDtos)
        {
            try
            {
                try
                {
                    var result = await bookService.AddBooksToFavourite(favouriteDtos);
                    if (result != null && result.Status)
                        return Ok(StandardResponse.Ok(" Added Successfully", result));
                    else if (!result.Status)
                        return Ok(StandardResponse.Ok("Failed", result));
                    else
                        return BadRequest(StandardResponse.BadRequest("An error occured"));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }

        }

        
    }
}
