using BooLibrary.Abstractions.Models;
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
    }
}
