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
    public class MockCategoryDataService : ICategoryDataService
    {
        public Task<bool> CreateCategory(Category category )
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoryFromBookCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCategoryID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
