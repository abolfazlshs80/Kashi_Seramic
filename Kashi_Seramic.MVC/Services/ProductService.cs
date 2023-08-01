using AutoMapper;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pr_Signal_ir.MVC.Models.Search;

using System.Reflection.Metadata;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.Product.Requests.Commands;
using Kashi_Seramic.Application.Features.Product.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Product;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public ProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService) 
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }
        public async Task<Response<int>> CreateProduct(CreateProductVM Product)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateProductCommand() { CreateProductDto = (_mapper.Map<CreateProductDto>(Product)) });
            if (res.Success)
            {
                model.Success = true;
                model.Data = res.Id;

            }
            else
                model.Data = 0;

            return model;
        }



        public async Task<Response<int>> DeleteProduct(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteProductCommand() { Id = id });
            return model;
        }

        public async Task<Response<bool>> ExistsProduct(int id)
        {
            var res = await _mediator.Send(new GetProductDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts()
        {

            try
            {
                var Product = await _mediator.Send(new GetProductListRequest());
                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<ProductVM>>(Product);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductVM>> GetProductsActive()
        {
            try
            {
                var Product = await _mediator.Send(new GetProductListRequest());
                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<ProductVM>>(Product.Where(a=>a.Status).OrderByDescending(a=>a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductVM>> GetProductsTopByNumber(int number)
        {
            try
            {
                var Product = await _mediator.Send(new GetProductListRequest());
                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<ProductVM>>(Product.OrderByDescending(a=>a.Seen).Take(number));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductVM>> GetProductsToLasted()
        {
            try
            {
                var Product = await _mediator.Send(new GetProductListRequest());
                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<ProductVM>>(Product.OrderByDescending(a=>a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SearchVM>> GetProductsBySearchVM(string text)
        {
            var model = await _mediator.Send(new GetProductListRequest());

            var newmodel = model.Where(a => a.Text.Contains(text) ||
            a.Title.Contains(text) ||
            a.TitleInBrowser.Contains(text) 
           
          ).Select(a => new SearchVM()
            {
                Desc = a.Title,
                Title = a.TitleInBrowser,
                Id = a.Id,
                Type = "Product",
                Product = _mapper.Map<ProductVM>(a),
                path = a.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl(),
                Url = $"/Product/{a.Id}/{a.TitleInBrowser.SetForUrl()}",

          });
            if (string.IsNullOrEmpty(text))
            {
                return model.Select(a => new SearchVM()
                {
                    Desc = a.Title,
                    Title = a.TitleInBrowser,
                    Id = a.Id,
                    Type = "Product",
                    Product = _mapper.Map<ProductVM>(a),
        
                    path = a.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl(),
                    Url = $"/Product/{a.Id}/{a.TitleInBrowser.SetForUrl()}",
                });
            }
            return (newmodel);
        }

        public async Task<IEnumerable<ProductVM>> GetProductsByUserId(string UserId)
        {
            try
            {
                var Product = await _mediator.Send(new GetProductListRequest());
                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<ProductVM>>(Product.Where(a=>a.Owner.Equals(UserId)));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SearchVM>> GetProductsCategoryBySearchVM(int cateid)
        {
            throw new NotImplementedException();
        }
        public async Task<List<SearchVM>> GetProductsCategoryBySearchVM()
        {
            var model = await _mediator.Send(new GetProductListRequest());

         
                return model.Select(a => new SearchVM()
                {
                    Desc = a.Title,
                    Title = a.TitleInBrowser,
                    Id = a.Id,
                    Type = "Product",
                    Product = _mapper.Map<ProductVM>(a),
                    path = a.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl()
                }).ToList();
          
        
        }

        public async Task<List<SearchVM>> GetProductsCategoryByTag(string name)
        {
            var model = await _mediator.Send(new GetTagListRequest());


            return model.Where(a => a.Name.Contains(name)).Select(a => new SearchVM()
            {
                Desc = a?.TagToProduct?.FirstOrDefault()?.Product.Title,
                Title = a?.TagToProduct?.FirstOrDefault()?.Product.TitleInBrowser,
                Id = a.TagToProduct.FirstOrDefault().Product.Id,
                Type = "Product",
                Product = _mapper.Map<ProductVM>(a),
                path = a?.TagToProduct?.FirstOrDefault()?.Product.FileToProduct?.FirstOrDefault()?.FileManager?.Path
                    ?.SetForProductUrl()
            }).ToList();
        }

        public async Task<List<SearchVM>> GetProductsCategoryByFilter(string name)
        {
            var model = await _mediator.Send(new GetFilterValueProductListRequest());

            var newmodel = (model.Where(a => a.Value.Contains(name)));
            List<SearchVM> search = new List<SearchVM>();
            foreach (var item in newmodel.ToList())
            {
                foreach (var product in item.FilterToProduct)
                {
                    search.Add(new SearchVM()
                    {
                        Desc = product.Product.Title,
                        Title = product.Product.TitleInBrowser,
                        Id = product.Product.Id,
                        Type = "Product",
                        Product = _mapper.Map<ProductVM>(product.Product),
                        path = product.Product.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl(),
                        Url = $"/Product/{product.Product.Id}/{product.Product.TitleInBrowser.SetForUrl()}",
                    });
                }
            }


            return (search.DistinctBy(a=>a.Id).ToList());
        }

        public async Task<List<SearchVM>> GetProductsCategoryByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVM> GetProductsDetails(int id)
        {
            try
            {
                var Product = await _mediator.Send(new GetProductDetailRequest() { Id = id });

                if (Product == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<ProductVM>(Product);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }

        public async Task<Response<int>> UpdateProduct(int id, UpdateProductVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateProductDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateProductCommand() { Id = id, ProductDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
        public async Task<Response<int>> UpdateProduct(int id)
        {
           
            var Product= await _mediator.Send(new GetProductDetailRequest() { Id = id });
            var Nmodel = _mapper.Map<UpdateProductDto>(Product);
            Product.Status =! Product.Status;
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Product.Id;
            await _mediator.Send(new UpdateProductCommand() { Id = id, ProductDto = Nmodel });
            return model;
        }

        public async Task<Response<bool>> UserIsOwner(string UserId, int id)
        {
            var res = await _mediator.Send(new GetProductListRequest());
            var model = new Response<bool>() { };
            if (res.Any(a=>a.Owner.Equals(UserId)&&a.Id.Equals(id)) )
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }
    }
}
