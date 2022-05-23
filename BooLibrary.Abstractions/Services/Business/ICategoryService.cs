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
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<StatusMessage> CreateCategory(CategoryDto categoryDto );
        Task<StatusMessage> UpdateCategory(int Id, CategoryDto categoryDto);
      
    }
}
