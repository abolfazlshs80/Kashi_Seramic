using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class FilterProductService : IFilterProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public FilterProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateFilterProduct(CreateFilterProductVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateFilterProductCommand() { CreateFilterProductDto = (_mapper.Map<CreateFilterProductDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteFilterProduct(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteFilterProductCommand() { Id = id });
            return model;
        }

        public async Task<List<FilterProductVM>> GetFilterProducts()
        {
            try
            {
                var FilterProduct = await _mediator.Send(new GetFilterProductListRequest());

                if (FilterProduct == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<FilterProductVM>>(FilterProduct);
                return _mapper.Map<List<FilterProductVM>>(FilterProduct);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<FilterProductVM>> GetFilterProductsByCatId(int cateId)
        {
            try
            {
                var FilterProduct = await _mediator.Send(new GetFilterProductListRequest());

                if (FilterProduct == null)
                {
                    throw new NotImplementedException();
                }
                var model = _mapper.Map<ICollection<FilterProductVM>>(FilterProduct.Where(a=>a.CategoryId.Equals(cateId)));
             //   model.ToList();
                return model.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<FilterProductVM> GetFilterProductsDetails(int id)
        {
            try
            {
                var FilterProduct = await _mediator.Send(new GetFilterProductDetailRequest() { Id = id });

                if (FilterProduct == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<FilterProductVM>(FilterProduct);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Response<int>> UpdateFilterProduct(int id, UpdateFilterProductVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateFilterProductDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateFilterProductCommand() { Id = id, FilterProductDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
