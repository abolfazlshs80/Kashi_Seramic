using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Kashi_Seramic.Application.DTOs.TagToBlog;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Models.TagToBlog;

namespace Pr_Signal_ir.MVC.Services
{
    public class TagToBlogService : ITagToBlogService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public TagToBlogService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateTagToBlog(CreateTagToBlogVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateTagToBlogCommand() { CreateTagToBlogDto = (_mapper.Map<CreateTagToBlogDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteTagToBlog(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteTagToBlogCommand() { Id = id });
            return model;
        }

        public async Task<Response<int>> DeleteAnyTagToBlog(int ProductId)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteAnyTagToBlogCommand() { Id = ProductId });
            return model;
        }

        public async Task<List<TagToBlogVM>> GetTagToBlogs()
        {
            try
            {
                var TagToBlog = await _mediator.Send(new GetTagToBlogListRequest());

                if (TagToBlog == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<TagToBlogVM>>(TagToBlog);
                return _mapper.Map<List<TagToBlogVM>>(TagToBlog);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TagToBlogVM> GetTagToBlogsDetails(int id)
        {
            try
            {
                var TagToBlog = await _mediator.Send(new GetTagToBlogDetailRequest() { Id = id });

                if (TagToBlog == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TagToBlogVM>(TagToBlog);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateTagToBlog(int id, UpdateTagToBlogVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTagToBlogDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
         //   await _mediator.Send(new UpdateTagToBlogCommand() { Id = id, TagToBlogDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
