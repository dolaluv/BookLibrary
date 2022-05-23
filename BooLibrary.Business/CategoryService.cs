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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDataService categoryDataService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryDataService categoryDataService, IMapper mapper)
        {
            this.categoryDataService = categoryDataService;
            _mapper = mapper;
        }

        public async Task<StatusMessage> CreateCategory(CategoryDto categoryDto)
        {
            StatusMessage statusMessage = new StatusMessage();
            try
            {
                var category = _mapper.Map<CategoryDto, Category>(categoryDto);

                statusMessage.Status = await this.categoryDataService.CreateCategory(category);
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
            return category == null? new Category() : category;
        }

        public async Task<StatusMessage> UpdateCategory(int Id, CategoryDto categoryDto)
        {
            StatusMessage statusMessage  = new StatusMessage();
            try
            {
               var  Findcategory = await this.categoryDataService.GetCategory(Id);
                if (Findcategory == null)
                {
                    statusMessage.Message = "Unable to find Category";
                    return statusMessage;
                }
                Findcategory.CategoryName = categoryDto.CategoryName;
                Findcategory.CategoryDescription = categoryDto.CategoryDescription;
                statusMessage.Status = await this.categoryDataService.UpdateCategory(Findcategory);
                statusMessage.Message = statusMessage.Status ? "Category Updated" : "Unable to update Category";
            }
            catch (Exception ex)
            {
                throw;
            }
          
            return statusMessage;
        }
    }
}
