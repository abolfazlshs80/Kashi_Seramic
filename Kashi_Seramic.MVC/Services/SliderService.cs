using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;

using Kashi_Seramic.Application.DTOs.Slider;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.MVC.Models.Slider;

namespace Pr_Signal_ir.MVC.Services
{
    public class SliderService : ISliderService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public SliderService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateSlider(CreateSliderVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateSliderCommand() { CreateSliderDto = (_mapper.Map<CreateSliderDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteSlider(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteSliderCommand() { Id = id });
            return model;
        }

        public async Task<List<SliderVM>> GetSliders()
        {
            try
            {
                var Slider = await _mediator.Send(new GetSliderListRequest());

                if (Slider == null)
                {
                    throw new NotImplementedException();
                }
               var a = _mapper.Map<ICollection<SliderVM>>(Slider);
                return _mapper.Map<List<SliderVM>>(Slider);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SliderVM>> GetSlidersActive()
        {
            try
            {
                var Slider = await _mediator.Send(new GetSliderListRequest());

                if (Slider == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<SliderVM>>(Slider);
                return _mapper.Map<List<SliderVM>>(Slider.Where(a=>a.Status).OrderByDescending(a=>a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SliderVM> GetSlidersDetails(int id)
        {
            try
            {
                var Slider = await _mediator.Send(new GetSliderDetailRequest() { Id = id });

                if (Slider == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<SliderVM>(Slider);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateSlider(int id, UpdateSliderVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateSliderDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateSliderCommand() { Id = id, SliderDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
