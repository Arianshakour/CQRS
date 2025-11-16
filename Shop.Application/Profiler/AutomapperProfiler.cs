using AutoMapper;
using Shop.Application.Dto.Product;
using Shop.Application.Dto.User;
using Shop.Domain.Entities.Products;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Profiler
{
    public class AutomapperProfiler : Profile
    {
        public AutomapperProfiler()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
