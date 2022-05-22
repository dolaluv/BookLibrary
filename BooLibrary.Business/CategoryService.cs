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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDataService categoryDataService;

        public CategoryService(ICategoryDataService categoryDataService)
        {
            this.categoryDataService = categoryDataService;
        }

        public async Task<StatusMessage> CreateCategory(CategoryDto categoryDto)
        {
            StatusMessage statusMessage = new StatusMessage();
            try
            {
                statusMessage.Status = await this.categoryDataService.CreateCategory(categoryDto);
                statusMessage.Message = statusMessage.Status ? "Category Added" : "Unable to add Category";
            }
            catch (Exception ex)
            {
                throw;
            }
          
            return statusMessage;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = await this.categoryDataService.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = new Category();
            try
            {
                category = await this.categoryDataService.GetCategory(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return category;
        }

        public async Task<StatusMessage> UpdateCategory(Category category)
        {
            StatusMessage statusMessage  = new StatusMessage();
            try
            {
                statusMessage.Status = await this.categoryDataService.UpdateCategory(category);
                statusMessage.Message = statusMessage.Status ? "Category Added" : "Unable to update Category";
            }
            catch (Exception ex)
            {
                throw;
            }
          
            return statusMessage;
        }
    }
}
