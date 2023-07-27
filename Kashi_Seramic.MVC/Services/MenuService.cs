using AutoMapper;
using Kashi_Seramic.Application.DTOs.Menu;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;

using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public MenuService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateMenu(CreateMenuVM leaveType)
        {
            leaveType.CreatedBy = "abolfzl";
            leaveType.DateCreated = DateTime.Now;
            leaveType.LastModifiedDate = DateTime.Now;
            leaveType.LastModifiedBy = "abolfazl";
            var response = new Response<int>();
            var res = await _mediator.Send(new CreateMenuCommand() { CreateMenuDto = (_mapper.Map<CreateMenuDto>(leaveType)) });
            if (res.Success)
            {
                response.Success = true;
                response.Data = res.Id;

            }
            else
                response.Success = false;
            return response;
        }

        public async Task<Response<int>> DeleteMenu(int id)
        {
            var response = new Response<int>();
            await _mediator.Send(new DeleteMenuCommand() { Id = id });

            response.Success = true;



            return response;





        }

        public async Task<List<MenuVM>> GetMenus()
        {
            try
            {
                var Menu = await _mediator.Send(new GetMenuListRequest());

                if (Menu == null)
                {
                    throw new NotImplementedException();
                }
               // var a = _mapper.Map<ICollection<MenuVM>>(Menu);
                return _mapper.Map<List<MenuVM>>(Menu.OrderByDescending(a=>a.Order));
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<MenuVM>> GetMenusActive()
        {
            try
            {
                var Menu = await _mediator.Send(new GetMenuListRequest());

                if (Menu == null)
                {
                    throw new NotImplementedException();
                }
                // var a = _mapper.Map<ICollection<MenuVM>>(Menu);
                return _mapper.Map<List<MenuVM>>(Menu.Where(a=>a.Status).OrderByDescending(a => a.Order));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<MenuVM>> GetMenusbyUserPanel()
        {
            var menus = await _mediator.Send(new GetMenuListRequest());
            return _mapper.Map<List<MenuVM>>(menus.Where(a=>a.StatusInUserMenu));

        }
        public async Task<List<MenuVM>> GetMenusbyAdminPanel()
        {
            var menus = await _mediator.Send(new GetMenuListRequest());
            return _mapper.Map<List<MenuVM>>(menus.Where(a=>a.StatusInAdminMenu));

        }
        public async Task<MenuVM> GetMenusDetails(int id)
        {
            try
            {
                var Menu = await _mediator.Send(new GetMenuDetailRequest() { Id = id });

                if (Menu == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<MenuVM>(Menu);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateMenu(int id, UpdateMenuVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateMenuDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateMenuCommand() { Id = id, MenuDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
