using AutoMapper;
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Commands;
using Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.CategoryToProduct;
using Pr_Signal_ir.MVC.Models.FileToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class CategoryToProductService : ICategoryToProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public CategoryToProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateCategoryToProduct(CreateCategoryToProductVM cate)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateCategoryToProductCommand() { CreateCategoryToProductDto = (_mapper.Map<CreateCategoryToProductDto>(cate)) });
            if (res.Success)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<Response<int>> DeleteCategoryToProduct(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteCategoryToProductCommand() { Id = id });


            return model;
        }

        public async Task<Response<int>> DeleteAnyCategoryToProduct(int id)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new GetCategoryToProductListRequest() {  });
            foreach (var item in res.Where(a=>a.ProductId.Equals(id)))
            {
                await _mediator.Send(new DeleteCategoryToProductCommand() { Id = id });
                model.Success = true;
            }
            return model;
        }

        public async Task<Response<int>> ExistsCategoryToProduct(int id)
        {        var model = new Response<int>() { };
        var res = await _mediator.Send(new GetCategoryToProductDetailRequest() { Id = id });
            if (res!=null)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<CategoryToProductVM> GetCategoryToProductDWithCateId(int id)
        {
            var category = await _mediator.Send(new GetCategoryToProductListRequest());
            return _mapper.Map<CategoryToProductVM>(category.Where(a => a.CategoryId == id).ToList());

        }

        public async Task<List<CategoryToProductVM>> GetCategoryToProducts()
        {
            var category = await _mediator.Send(new GetCategoryToProductListRequest());
            return _mapper.Map<List<CategoryToProductVM>>(category);
        }

        public async Task<CategoryToProductVM> GetCategoryToProductWithProductId(int id)
        {
            var category = await _mediator.Send(new GetCategoryToProductListRequest());
            return _mapper.Map<CategoryToProductVM>(category.Where(a => a.ProductId == id).ToList());
        }
    }

}
