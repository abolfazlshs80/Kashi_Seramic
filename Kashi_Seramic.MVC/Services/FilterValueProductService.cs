using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Models.FilterProduct;

namespace Pr_Signal_ir.MVC.Services
{
    public class FilterValueProductService : IFilterValueProductService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public FilterValueProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;

            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateFilterValueProduct(CreateFilterValueProductVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateFilterValueProductCommand() { CreateFilterValueProductDto = (_mapper.Map<CreateFilterValueProductDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteFilterValueProduct(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteFilterValueProductCommand() { Id = id });
            return model;
        }

        public async Task<List<FilterValueProductVM>> GetFilterValueProducts()
        {
            try
            {
                var FilterValueProduct = await _mediator.Send(new GetFilterValueProductListRequest());

                if (FilterValueProduct == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<FilterValueProductVM>>(FilterValueProduct);
                return _mapper.Map<List<FilterValueProductVM>>(FilterValueProduct);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<FilterValueProductVM>> GetFilterValueProductsByFilterId(int id)
        {
            try
            {
                var FilterValueProduct = await _mediator.Send(new GetFilterValueProductListRequest() );

                if (FilterValueProduct == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<List<FilterValueProductVM>>(FilterValueProduct.Where(a=>a.FilterId.Equals(id)).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<FilterValueProductVM> GetFilterValueProductsDetails(int id)
        {
            try
            {
                var FilterValueProduct = await _mediator.Send(new GetFilterValueProductDetailRequest() { Id = id });

                if (FilterValueProduct == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<FilterValueProductVM>(FilterValueProduct);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateFilterValueProduct(int id, UpdateFilterValueProductVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateFilterValueProductDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateFilterValueProductCommand() { Id = id, FilterValueProductDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
