using AutoMapper;
using Pr_Signal_ir.Application.DTOs.FileToBlog;
using Kashi_Seramic.Application.Features.FileManager.Requests.Queries;
using Kashi_Seramic.Application.Features.FileToBlog.Requests.Commands;
using Kashi_Seramic.Application.Features.FileToBlog.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.FileToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class FileToBlogService : IFileToBlogService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
       

        public FileToBlogService(IMediator mediator, IHttpContextAccessor httpContextAccessor,IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> CreateFileToBlog(CreateFileToBlogVM leaveType)
        {
            var response = new Response<int>();

    


   var blog= await _mediator.Send(new CreateFileToBlogCommand() { CreateFileImageDto = (_mapper.Map<CreateFileToBlogDto>(leaveType)) });
            if (blog.Success)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> DeleteFileToBlog(int id)
        {
            var response = new Response<int>();


            await _mediator.Send(new DeleteFileToBlogCommand() { Id = id });
            response.Success = true;
        
            return response;
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<bool>> ExistsFileToBlog(int id)
        {
            var response = new Response<bool>();

    


            var category  = await _mediator.Send(new GetFileToBlogDetailRequest() { Id = id });
            if (category != null)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<List<FileToBlogVM>> GetFileToBlog()
        {
            var category = await _mediator.Send(new GetFileToBlogListRequest());
            return _mapper.Map<List<FileToBlogVM>>(category);
        }

        public async Task<FileToBlogVM> GetFileToBlogDWithImageId(int id)
        {


            var category = await _mediator.Send(new GetFileToBlogListRequest());
            return _mapper.Map<FileToBlogVM>(category.Where(a => a.ImageId == id).ToList());
        }

        public async Task<FileToBlogVM> GetFileToBlogWithBlogId(int id)
        {
            var blog1 = new FileToBlogDto() { BlogId = 1, ImageId = 1 };

            var blog2 = _mapper.Map<FileToBlogVM>(blog1);
            var category = await _mediator.Send(new GetFileToBlogListRequest());
            return _mapper.Map<FileToBlogVM>(category.Where(a => a.BlogId == id).FirstOrDefault());
        }

        public async Task<FileImagesVM> GetPathWithBlogId(int id)
        {
            var getimage = await _mediator.Send(new GetFileToBlogListRequest());
            var fileinfo = await _mediator.Send(new GetFileManagerListRequest());
            return _mapper.Map<FileImagesVM>(fileinfo);
        }



        //
    }

}
