
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public InventoryService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateInventory(CreateInventoryVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateInventoryCommand() { CreateInventoryDto = (_mapper.Map<CreateInventoryDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteInventory(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteInventoryCommand() { Id = id });
            return model;
        }


        public async Task<List<InventoryVM>> GetInventorys()
        {
            try
            {
                var Inventory = await _mediator.Send(new GetInventoryListRequest());

                if (Inventory == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<InventoryVM>>(Inventory);
                return _mapper.Map<List<InventoryVM>>(Inventory);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<InventoryVM> GetInventorysDetails(int id)
        {
            try
            {
                var Inventory = await _mediator.Send(new GetInventoryDetailRequest() { Id = id });

                if (Inventory == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<InventoryVM>(Inventory);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateInventory(int id, UpdateInventoryVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateInventoryDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateInventoryCommand() { Id = id, InventoryDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
