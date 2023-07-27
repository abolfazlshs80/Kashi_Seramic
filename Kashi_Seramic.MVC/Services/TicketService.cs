using AutoMapper;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Ticket;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.DTOs.Ticket;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public TicketService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }
        public async Task<Response<int>> CreateTicket(CreateTicketVM cate)
        {
            var response = new Response<int>();
            var res = await _mediator.Send(new CreateTicketCommand() { CreateTicketDto = (_mapper.Map<CreateTicketDto>(cate)) });
            if (res.Success)
            {
                response.Success = true;
                response.Data = res.Id;

            }
            else
                response.Success = false;
            return response;
        }



        public async Task<Response<int>> DeleteTicket(int id)
        {
            var response = new Response<int>();
            await _mediator.Send(new DeleteTicketCommand() { Id = id });

            response.Success = true;



            return response;



        }

        public async Task<Response<int>> ExistsTicket(int id)
        {
            var res = await _mediator.Send(new GetTicketDetailRequest() { Id = id });
            var model = new Response<int>() { };
            if (res != null)
            {

                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<IEnumerable<SearchVM>> GetBlogsTicketBySearchVM(int cateid)
        {
            var model = await  _mediator.Send(new GetTicketDetailRequest() { Id = cateid });
            var list = new List<SearchVM>();

            //var newmodel = model.TicketToBlog.Select(a => new SearchVM()
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

        public async Task<List<TicketVM>> GetTickets()
        {


            var Ticket = await _mediator.Send(new GetTicketListRequest());
            if (Ticket == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<TicketVM>>(Ticket.OrderByDescending(a => a.LastModifiedDate));


        }

        public async Task<List<TicketVM>> GetTicketsByGroup(string id)
        {
            var Ticket = new List<TicketVM>();
            var group=(await _mediator.Send(new GetTicketGroupListRequest())).Where(a=>a.UserId==id).ToList();
            foreach (var item in group)
            {
                foreach (var ticket in (await _mediator.Send(new GetTicketListRequest())).Where(a => a.GroupId == item.Id).ToList())
                {
                    Ticket.Add(_mapper.Map<TicketVM>(ticket));
                }
                
            }
            if (Ticket == null)
            {
                throw new NotImplementedException();
            }
            return (Ticket.OrderByDescending(a => a.LastModifiedDate).ToList());
        }

        public async Task<List<TicketVM>> GetTicketsByGroupId(int id)
        {


            var Ticket = await _mediator.Send(new GetTicketListRequest());
            if (Ticket == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<TicketVM>>(Ticket.Where(a=>a.GroupId==id).OrderByDescending(a=>a.LastModifiedDate).ToList());


        }

        public async Task<List<TicketVM>> GetTicketsByUserId(string id)
        {


            var Ticket =  await _mediator.Send(new GetTicketListRequest());
            if (Ticket == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<TicketVM>>(Ticket.Where(a => a.UserId == id).OrderByDescending(a => a.LastModifiedDate).ToList());


        }
        public async Task<TicketVM> GetTicketsDetails(int id)
        {
            try
            {
                var Ticket = await _mediator.Send(new GetTicketDetailRequest() { Id = id });
                if (Ticket == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TicketVM>(Ticket);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }

        public async Task<Response<int>> UpdateTicket(int id, UpdateTicketVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTicketDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateTicketCommand() { Id = id, TicketDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
