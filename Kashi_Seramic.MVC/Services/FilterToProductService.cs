using AutoMapper;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.DTOs.FilterToProduct;

using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Commands;
using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;

using Pr_Signal_ir.MVC.Models.FilterToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class FilterToProductService : IFilterToProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
       

        public FilterToProductService(IMapper mapper, ILocalStorageService localStorageService, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> CreateFilterToProduct(CreateFilterToProductVM leaveType)
        {
            var response = new Response<int>();

    


   var Product= await _mediator.Send(new CreateFilterToProductCommand() { CreateFilterImageDto = (_mapper.Map<CreateFilterToProductDto>(leaveType)) });
            if (Product.Success)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> DeleteFilterToProduct(int id)
        {
            var response = new Response<int>();


            await _mediator.Send(new DeleteFilterToProductCommand() { Id = id });

            response.Success = true;
        
            return response;
        }

        public async Task<Response<int>> DeleteAnyFilterToProduct(int ProductId)
        {
            {
                var response = new Response<int>();


                await _mediator.Send(new DeleteAnyFilterToProductCommand() { Id = ProductId });

                response.Success = true;

                return response;
            }
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<bool>> ExistsFilterToProduct(int id)
        {
            var response = new Response<bool>();

    


            var category = await _mediator.Send(new GetFilterToProductDetailRequest() { Id = id });
            if (category != null)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<List<FilterToProductVM>> GetFilterToProduct()
        {
            var category = await _mediator.Send(new GetFilterToProductListRequest());
            return _mapper.Map<List<FilterToProductVM>>(category);
        }

        public async Task<FilterToProductVM> GetFilterToProductDWithImageId(int id)
        {


            var category = await _mediator.Send(new GetFilterToProductListRequest());
            return _mapper.Map<FilterToProductVM>(category.Where(a => a.FilterId == id).ToList());
        }

        public async Task<FilterToProductVM> GetFilterToProductWithProductId(int id)
        {
            var Product1 = new FilterToProductDto() { ProductId = 1, FilterId = 1 };

            var Product2 = _mapper.Map<FilterToProductVM>(Product1);
            var category = await _mediator.Send(new GetFilterToProductListRequest());
            return _mapper.Map<FilterToProductVM>(category.Where(a => a.ProductId == id).FirstOrDefault());
        }


    }

}
