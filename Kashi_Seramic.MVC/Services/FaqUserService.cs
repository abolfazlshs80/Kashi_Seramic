using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.FaqUser;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class FaqUserService : IFaqUserService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public FaqUserService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateFaqUser(CreateFaqUserVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateFaqUserCommand() { CreateFaqUserDto = (_mapper.Map<CreateFaqUserDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteFaqUser(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteFaqUserCommand() { Id = id });
            return model;
        }

        public async Task<List<Models.Pr_Signal_ir.MVC.Models.FaqUser.FaqUserVM>> GetFaqUsers()
        {
            var FaqUser = await _mediator.Send(new GetFaqUserListRequest());

            return _mapper.Map<List<Models.Pr_Signal_ir.MVC.Models.FaqUser.FaqUserVM>>(FaqUser);
        }

        public async Task<List<FaqUserVM>> GetFaqUsersByNumber(int number)
        {
            var FaqUser = await _mediator.Send(new GetFaqUserListRequest());

            return _mapper.Map<List<Models.Pr_Signal_ir.MVC.Models.FaqUser.FaqUserVM>>(FaqUser.Take(number));
        }

        public async Task<Models.Pr_Signal_ir.MVC.Models.FaqUser.FaqUserVM> GetFaqUsersDetails(int id)
        {
            var FaqUser = await _mediator.Send(new GetFaqUserDetailRequest() { Id = id });


            return _mapper.Map<Models.Pr_Signal_ir.MVC.Models.FaqUser.FaqUserVM>(FaqUser);
        }

        public async Task<Response<int>> UpdateFaqUser(int id, UpdateFaqUserVM leaveType)
        {
            var response = new Response<int>();



            await _mediator.Send(new UpdateFaqUserCommand() { Id = id, FaqUserDto =_mapper.Map<UpdateFaqUserDto>( leaveType )});

            response.Success = true;

            return response;
        }
    }

}
