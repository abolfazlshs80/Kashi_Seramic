using AutoMapper;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Category;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class BlogToCommentService :  ICommentToBlogService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public BlogToCommentService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService) 
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;

        }

        public async Task<Response<int>> CreateCommentToBlog(CreateCommentToBlogVM model)
        {
      
                var response = new Response<int>();
                var newmodel = _mapper.Map<CreateCommentToBlogDto>(model);
      
                var apiResponse = await _mediator.Send(new CreateCommentToBlogCommand() { CreateCommentToBlogDto=newmodel });
                if (apiResponse != null)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
                return response;
           


        }

        public async Task<Response<int>> DeleteCommentToBlog(int id)
        {
            var response = new Response<int>();

    
            await _mediator.Send(new DeleteCommentToBlogCommand() { Id = id });

            response.Success = true;

            return response;
        }

        public async Task<Response<bool>> ExistsCommentToBlog(int id)
        {
            var response = new Response<bool>();

    
            var apiResponse = await _mediator.Send(new GetCommentToBlogDetailRequest() { Id = id });
            if (apiResponse != null)
            {

                response.Success = true;
            }
            else
            {
                response.Success = false;
            }
            return response;
        }

        public async Task<List<CommentToBlogVM>> GetCommentToBlogs()
        {
            var response = new Response<int>();

    
            var apiResponse = await  _mediator.Send(new GetCommentToBlogListRequest() );

            return _mapper.Map<List<CommentToBlogVM>>(apiResponse.OrderByDescending(a=>a.Id));
        }

        public async Task<List<CommentToBlogVM>> GetCommentToBlogsByUserId(string id)
        {

            var blogs=(await _mediator.Send(new GetCommentToBlogListRequest())).Where(a=>a.Owner==id).ToList();
            var CommentOfVideoBlog = await _mediator.Send(new GetCommentToBlogListRequest());
            var lstModel=new List<CommentToBlogVM>();
            foreach (var blog in blogs)
            {
                foreach (var com in CommentOfVideoBlog)
                {
                    if (com.BlogId == blog.Id)
                        lstModel.Add(_mapper.Map<CommentToBlogVM>(com));
                }

            }
            return lstModel;
           
        }

        public async Task<CommentToBlogVM> GetCommentToBlogsDetails(int id)
        {
            var response = new Response<int>();
            try
            {
             

                //AddBearerToken();
                var apiResponse = await _mediator.Send(new GetCommentToBlogDetailRequest() { Id = id });
                return _mapper.Map<CommentToBlogVM>(apiResponse);
            }
            catch (Exception)
            {
        
                var apiResponse = await _mediator.Send(new GetCommentToBlogDetailRequest() { Id = id });
                return _mapper.Map<CommentToBlogVM>(apiResponse);

            }
           

            
        }

        public async Task<List<CommentToBlogVM>> GetCommentToBlogsGetByBlogId(int id)
        {
            var response = new Response<int>();

    
            var apiResponse =  await _mediator.Send(new GetCommentToBlogListRequest());

            return _mapper.Map<List<CommentToBlogVM>>(apiResponse.OrderByDescending(a => a.Id).Where(a=>a.BlogId==id).ToList());
        }

        public async Task<Response<int>> UpdateCommentToBlog(int id, UpdateCommentToBlogVM leaveType)
        {
            var response = new Response<int>();

    
            await _mediator.Send(new UpdateCommentToBlogCommand() {Id= id,CommentToBlogDto= _mapper.Map<UpdateCommentToBlogDto>(leaveType) });

            return response;
        }
    }

}
