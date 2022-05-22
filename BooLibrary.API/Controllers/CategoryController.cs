using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using BooLibrary.Abstractions.Services.Business;
using BooLibrary.API.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        
        [HttpGet("fetch-categories")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {  
                var categories = await categoryService.GetCategories();
                if (categories != null)
                    return Ok(StandardResponse.Ok("Successfully fetch loan history", categories));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
        }

       
        [HttpGet("GetCategoryById/{Id}")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            try
            {
                var category = await categoryService.GetCategory(Id);
                if (category != null)
                    return Ok(StandardResponse.Ok("Successfully fetch Category", category));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
        }


        // POST api/<CategoryController>
        [HttpPost("CreateCategory")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                var result = await categoryService.CreateCategory(categoryDto);
                if (result != null)
                    return Ok(StandardResponse.Ok("Category Added Successfully", result));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
            return null;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("UpdateCategory")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category )
        {
            try
            {
                var result = await categoryService.UpdateCategory(category);
                if (result != null)
                    return Ok(StandardResponse.Ok("Category Added Successfully", result));
                else
                    return BadRequest(StandardResponse.BadRequest("An error occured"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, StandardResponse.InternalServerError(ex.ToString(), null));
            }
            return null;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
