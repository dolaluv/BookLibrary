using BooLibrary.Abstractions.Models;
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
        public Task<List<Category>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
