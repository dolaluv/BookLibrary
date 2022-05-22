using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Services.Business;
using BooLibrary.Abstractions.Services.Data;
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
    }
}
