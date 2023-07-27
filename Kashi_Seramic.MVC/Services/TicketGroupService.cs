using AutoMapper;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;
using Kashi_Seramic.Application.DTOs.TicketGroup;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class TicketGroupService : ITicketGroupService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public TicketGroupService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }
        public async Task<Response<int>> CreateTicketGroup(CreateTicketGroupVM cate)
        {
            var response = new Response<int>();
            var res = await _mediator.Send(new CreateTicketGroupCommand() { CreateTicketGroupDto = (_mapper.Map<CreateTicketGroupDto>(cate)) });
            if (res.Success)
            {
                response.Success = true;
                response.Data = res.Id;

            }
            else
                response.Success = false;
            return response;
        }



        public async Task<Response<int>> DeleteTicketGroup(int id)
        {
            var response = new Response<int>();
            await _mediator.Send(new DeleteTicketGroupCommand() { Id = id });

            response.Success = true;



            return response;



        }

        public async Task<Response<int>> ExistsTicketGroup(int id)
        {
            var res = await _mediator.Send(new GetTicketGroupDetailRequest() { Id = id });
            var model = new Response<int>() { };
            if (res != null)
            {

                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<IEnumerable<SearchVM>> GetBlogsTicketGroupBySearchVM(int cateid)
        {
            var model = await _mediator.Send(new GetTicketGroupDetailRequest() { Id = cateid });
            var list = new List<SearchVM>();

            //var newmodel = model.TicketGroupToBlog.Select(a => new SearchVM()
            //{
            //    Desc = a.Blog.LognName,
            //    Title = a.Blog.ShortName,
            //    Id = a.Blog.Id,
            //    Type = "Blog",
            //    Blog =_mapper.Map<BlogVM>( a.Blog),
            //    path = a.Blog.FileToBlog?.FirstOrDefault()?.FileImages.Path
            //});

            return new List<SearchVM>();
        }

        public async Task<List<TicketGroupVM>> GetTicketGroups()
        {


            var TicketGroup = await _mediator.Send(new GetTicketGroupListRequest());
            if (TicketGroup == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<TicketGroupVM>>(TicketGroup.OrderByDescending(a=>a.LastModifiedDate));


        }

        public async Task<List<TicketGroupVM>> GetTicketGroupsByUser(string userid)
        {
            return (await GetTicketGroups()).Where(a=>a.UserId== userid).ToList();
        }

        public async Task<TicketGroupVM> GetTicketGroupsDetails(int id)
        {
            try
            {
                var TicketGroup = await _mediator.Send(new GetTicketGroupDetailRequest() { Id = id });
                if (TicketGroup == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TicketGroupVM>(TicketGroup);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }

        public async Task<Response<int>> UpdateTicketGroup(int id, UpdateTicketGroupVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTicketGroupDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateTicketGroupCommand() { Id = id, TicketGroupDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
