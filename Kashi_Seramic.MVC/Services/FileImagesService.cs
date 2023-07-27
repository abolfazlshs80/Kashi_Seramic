 using AutoMapper;
using Kashi_Seramic.Application.DTOs.FileManager;
using Kashi_Seramic.Application.Features.FileManager.Requests.Commands;
using Kashi_Seramic.Application.Features.FileManager.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class FileImagesService : IFileImagesService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public FileImagesService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }
        public async Task<Response<int>> CreateFileImages(CreateFileImagesVM FileImages)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateFileManagerCommand() { CreateFileImageDto = (_mapper.Map<CreateFileManagerDto>(FileImages)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }



        public async Task<Response<int>> DeleteFileImages(int id)
        {
            var response = new Response<int>();



            await _mediator.Send(new DeleteFileManagerCommand() { Id = id });
            return response;
        }

        public async Task<Response<bool>> ExistsFileImages(int id)
        {
            var res = await _mediator.Send(new GetFileManagerDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {

                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<List<FileImagesVM>> GetFileImages()
        {
         var file= await _mediator.Send(new GetFileManagerListRequest());
            return _mapper.Map<List<FileImagesVM>>(file);
        }

        public async Task<FileImagesVM> GetFileImagesDetails(int id)
        {
            var file = await _mediator.Send(new GetFileManagerDetailRequest() { Id = id });
            return _mapper.Map<FileImagesVM>(file);
        }





        public async Task<Response<int>> UpdateFileImages(int id, UpdateFileImagesVM FileImages)
        {
            var Nmodel = _mapper.Map<UpdateFileManagerDto>(FileImages);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateFileManagerCommand() { Id = id, FileImageDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }





        //
    }

}
