using AutoMapper;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.Features.FileManager.Requests.Queries;
using Kashi_Seramic.Application.Features.FileToProduct.Requests.Commands;
using Kashi_Seramic.Application.Features.FileToProduct.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.FileToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class FileToProductService : IFileToProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
       

        public FileToProductService(IMapper mapper, ILocalStorageService localStorageService, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> CreateFileToProduct(CreateFileToProductVM leaveType)
        {
            var response = new Response<int>();

    


   var Product= await _mediator.Send(new CreateFileToProductCommand() { CreateFileImageDto = (_mapper.Map<CreateFileToProductDto>(leaveType)) });
            if (Product.Success)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<int>> DeleteFileToProduct(int id)
        {
            var response = new Response<int>();


            await _mediator.Send(new DeleteFileToProductCommand() { Id = id });

            response.Success = true;
        
            return response;
        }

        public async Task<Pr_Signal_ir.MVC.Services.Base.Response<bool>> ExistsFileToProduct(int id)
        {
            var response = new Response<bool>();

    


            var category = await _mediator.Send(new GetFileToProductDetailRequest() { Id = id });
            if (category != null)
                response.Success = true;
            else response.Success = false;
            return response;
        }

        public async Task<List<FileToProductVM>> GetFileToProduct()
        {
            var category = await _mediator.Send(new GetFileToProductListRequest());
            return _mapper.Map<List<FileToProductVM>>(category);
        }

        public async Task<FileToProductVM> GetFileToProductDWithImageId(int id)
        {


            var category = await _mediator.Send(new GetFileToProductListRequest());
            return _mapper.Map<FileToProductVM>(category.Where(a => a.ImageId == id).ToList());
        }

        public async Task<FileToProductVM> GetFileToProductWithProductId(int id)
        {
            var Product1 = new FileToProductDto() { ProductId = 1, ImageId = 1 };

            var Product2 = _mapper.Map<FileToProductVM>(Product1);
            var category = await _mediator.Send(new GetFileToProductListRequest());
            return _mapper.Map<FileToProductVM>(category.Where(a => a.ProductId == id).FirstOrDefault());
        }

        public async Task<FileImagesVM> GetPathWithProductId(int id)
        {
            var getimage = await  _mediator.Send(new GetFileToProductDetailRequest() { Id = id });
            var fileinfo = await  _mediator.Send(new GetFileManagerDetailRequest() { Id = id });
            return _mapper.Map<FileImagesVM>(fileinfo);
        }



        //
    }

}
