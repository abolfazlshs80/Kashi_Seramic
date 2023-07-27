using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.DTOs.SiteSetting;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.DTOs.Setting;

namespace Pr_Signal_ir.MVC.Services
{
    public class SettingService : ISettingService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public SettingService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateSetting(CreateSettingVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateSiteSettingCommand() { CreateSiteSettingDto = (_mapper.Map<CreateSiteSettingDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteSetting(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteSiteSettingCommand() { Id = id });
            return model;
        }

        public async Task<List<Models.Pr_Signal_ir.MVC.Models.Setting.SettingVM>> GetSettings()
        {
            try
            {
                var Setting = await _mediator.Send(new GetSiteSettingListRequest());

                if (Setting == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<SettingVM>>(Setting);
                return _mapper.Map<List<SettingVM>>(Setting);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Models.Pr_Signal_ir.MVC.Models.Setting.SettingVM> GetSettingsDetails(int id)
        {
            try
            {
                var Setting = await _mediator.Send(new GetSiteSettingDetailRequest() { Id = id });

                if (Setting == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<SettingVM>(Setting);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateSetting(int id, UpdateSettingVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateSiteSettingDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateSiteSettingCommand() { Id = id, SiteSettingDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
