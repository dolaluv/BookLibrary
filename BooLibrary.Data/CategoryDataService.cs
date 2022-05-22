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
    public class CategoryDataService : ICategoryDataService
    {
        private readonly ApplicationDbContext _db;

        public CategoryDataService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateCategory(CategoryDto categoryDto )
        {
            var result = false;
            try
            {
              //  _db.Categories.Add(category);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<List<Category>> Get()
        {
            List<Category> categories = new List<Category>();
           try
            {
                categories = _db.Categories.ToList();
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
                category = _db.Categories.FirstOrDefault(f=> f.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return category;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var result = false;
            try
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
