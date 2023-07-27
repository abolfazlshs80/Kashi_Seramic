using AutoMapper;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.TicketToReply;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.TicketToReply.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TicketToReply;

namespace Pr_Signal_ir.MVC.Services
{
    public class TicketToReplyService : ITicketToReplyService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public TicketToReplyService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }
        public async Task<Response<int>> CreateTicketToReply(CreateTicketToReplyVM cate)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateTicketToReplyCommand() { CreateTicketToReplyDto = (_mapper.Map<CreateTicketToReplyDto>(cate)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }



        public async Task<Response<int>> DeleteTicketToReply(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteTicketToReplyCommand() { Id = id });
            return model;



        }

        public async Task<Response<int>> ExistsTicketToReply(int id)
        {
            var res = await _mediator.Send(new GetTicketToReplyDetailRequest() { Id = id });
            var model = new Response<int>() { };
            if (res != null)
            {

                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<IEnumerable<SearchVM>> GetBlogsTicketToReplyBySearchVM(int cateid)
        {
            var model = await _mediator.Send(new GetTicketToReplyDetailRequest() { Id = cateid });
            var list = new List<SearchVM>();

            //var newmodel = model.TicketToReplyToBlog.Select(a => new SearchVM()
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

        public async Task<List<TicketToReplyVM>> GetTicketToReplys()
        {

            try
            {
                var TicketToReply = await _mediator.Send(new GetTicketToReplyListRequest());

                if (TicketToReply == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<TicketToReplyVM>>(TicketToReply);
                return _mapper.Map<List<TicketToReplyVM>>(TicketToReply);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TicketToReplyVM> GetTicketToReplysDetails(int id)
        {
            try
            {
                var TicketToReply = await _mediator.Send(new GetTicketToReplyDetailRequest() { Id = id });

                if (TicketToReply == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TicketToReplyVM>(TicketToReply);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }
        public async Task<List<TicketToReplyVM>> GetTicketToReplysDetailsByTicket(int Ticketid)
        {
            try
            {
                var TicketToReply = await _mediator.Send(new GetTicketToReplyListRequest());

                if (TicketToReply == null)
                {
                    throw new NotImplementedException();
                }
                var model = TicketToReply.Where(a => a.TicketId == Ticketid).ToList();
                return _mapper.Map<List<TicketToReplyVM>>(model.OrderBy(a=>a.LastModifiedDate));
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }
        public async Task<Response<int>> UpdateTicketToReply(int id, UpdateTicketToReplyVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTicketToReplyDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateTicketToReplyCommand() { Id = id, TicketToReplyDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
