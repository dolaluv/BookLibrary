using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Abstractions.Services.Data
{
    public interface ICategoryDataService
    {
        Task<List<Category>> Get();
        Task<Category> GetCategory(int id);
        Task<bool> CreateCategory(CategoryDto categoryDto);
        Task<bool> UpdateCategory(Category category);
    }
}
