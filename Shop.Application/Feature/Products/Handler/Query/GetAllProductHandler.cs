using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Dto.Product;
using Shop.Application.Feature.Products.Request.Query;
using Shop.Common.ResultPattern;
using Shop.Common.SortExtension;
using Shop.Domain.Entities.Products;
using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Handler.Query
{
    public class GetAllProductHandler : IRequestHandler<GetAllProudctRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(GetAllProudctRequest request, CancellationToken cancellationToken)
        {
            var Products = _productRepository.GetAll();
            Products = Products.Include(x => x.Category);//baraye andakhtan name category va foreach nazadan
            //to automapper ham bayad set koni
            if (!string.IsNullOrEmpty(request.filter.Search))
            {
                Products = Products.Where(p => p.Name.Contains(request.filter.Search));
            }
            if (request.filter.MinPrice.HasValue)
            {
                Products = Products.Where(x => x.Price >= request.filter.MinPrice.Value);
            }
            if (request.filter.MaxPrice.HasValue)
            {
                Products = Products.Where(x => x.Price <= request.filter.MaxPrice.Value);
            }
            if (request.filter.CategoryId != null)
            {
                Products = Products.Where(x => x.CategoryId == request.filter.CategoryId);
            }

            // impelement dynamic sort
            if (!string.IsNullOrEmpty(request.filter.SortBy))
            {
                //in if paein check mikone ke property ke dare bahash sort mikone baraye Product hast ya na
                //masalan Price baraye Product hast
                if (typeof(Product).GetProperty(request.filter.SortBy) != null)
                {
                    Products = Products.OrderByCustom(request.filter.SortBy, request.filter.SortOrder);
                }
            }

            var skip = (request.filter.PageId - 1) * request.filter.PageSize;
            Products = Products.Skip(skip).Take(request.filter.PageSize);
            //return products.ToList();
            //return Task.FromResult(Result.Success(_mapper.Map<List<ProductDto>>(Products)));//Hatman Task bezan ke khata nade

            var dtoList = _mapper.Map<List<ProductDto>>(Products);
            //inam ravesh dasti bdone automapper
            //var dtoList = Products.Select(p => new ProductDto
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Description = p.Description,
            //    Price = p.Price,
            //    CategoryId = p.CategoryId,
            //    Categoryname = p.Category != null ? p.Category.Name : null
            //}).ToList();

            //Andakhtan Name Category ham injoori mishe ham ravesh dg ke alan hast to profile auto mapper zadam
            //foreach (var item in dtoList)
            //{
            //    item.Categoryname = _categoryRepository.GetCategoryname(item.CategoryId);
            //}
            return Task.FromResult(Result.Success(dtoList));
        }
    }
}
