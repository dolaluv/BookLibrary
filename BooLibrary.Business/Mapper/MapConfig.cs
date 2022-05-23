using AutoMapper;
using BooLibrary.Abstractions.Models;
using BooLibrary.Abstractions.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Business.Mapper
{
    public class MapConfig
    {

        public static MapperConfiguration RegristerMapper()
        {

            var mapConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryDto, Category>().ReverseMap();
                config.CreateMap<BookDto, Book>().ReverseMap();
                config.CreateMap<BookCategoryDto, BookCategory>().ReverseMap();
                config.CreateMap<FavouriteDto, Favourite>().ReverseMap();

            });

            return mapConfig;
        }

    }
}
