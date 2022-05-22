using BooLibrary.Abstractions.Models;
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
    }
}
