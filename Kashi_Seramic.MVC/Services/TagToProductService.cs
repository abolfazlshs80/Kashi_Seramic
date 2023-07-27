using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Models.TagToProduct;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.TagToProduct.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.TagToProduct.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class TagToProductService : ITagToProductService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TagToProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateTagToProduct(CreateTagToProductVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateTagToProductCommand() { CreateTagToProductDto = (_mapper.Map<CreateTagToProductDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteTagToProduct(int id)
        {  var model = new Response<int>() { };
            await _mediator.Send(new DeleteTagToProductCommand() { Id = id });
            return model;
           
        }

        public async Task<Response<int>> DeleteAnyTagToProduct(int productId)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteAnyTagToProductCommand() { Id = productId });
            return model;
        }

        public async Task<List<TagToProductVM>> GetTagToProducts()
        {
            try
            {
                var TagToProduct = await _mediator.Send(new GetTagToProductListRequest());

                if (TagToProduct == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<TagToProductVM>>(TagToProduct);
                return _mapper.Map<List<TagToProductVM>>(TagToProduct);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TagToProductVM> GetTagToProductsDetails(int id)
        {
            try
            {
                var TagToProduct = await _mediator.Send(new GetTagToProductDetailRequest() { Id = id });

                if (TagToProduct == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TagToProductVM>(TagToProduct);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<Response<int>> UpdateTagToProduct(int id, UpdateTagToProductVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTagToProductDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
        //    await _mediator.Send(new UpdateTagToProductCommand() { Id = id, TagToProductDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
