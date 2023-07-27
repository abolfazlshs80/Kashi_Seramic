using AutoMapper;
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Pr_Signal_ir.Application.DTOs.Category;
using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands;
using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Queries;
using Kashi_Seramic.Application.Features.Product.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class CommentToProductService : ICommentToProductService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public CommentToProductService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateCommentToProduct(CreateCommentToProductVM newmodel)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateCommentToProductCommand() { CreateCommentToProductDto = (_mapper.Map<CreateCommentToProductDto>(newmodel)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;

        }

        public async Task<Response<int>> DeleteCommentToProduct(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteCommentToProductCommand() { Id = id });
            return model;
        }

        public async Task<Response<bool>> ExistsCommentToProduct(int id)
        {
            var res = await _mediator.Send(new GetCommentToProductDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {

                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<List<CommentToProductVM>> GetCommentToBlogsGetByProductId(int id)
        {
            var response = new Response<int>();

    
            var apiResponse = await _mediator.Send(new GetCommentToProductListRequest());

            return _mapper.Map<List<CommentToProductVM>>(apiResponse.OrderByDescending(a => a.Id).Where(a => a.ProductId == id).ToList());
        }

        public async Task<List<CommentToProductVM>> GetCommentToProducts()
        {
            try
            {
                var CommentToProduct = await _mediator.Send(new GetCommentToProductListRequest());

                if (CommentToProduct == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<CommentToProductVM>>(CommentToProduct);
                return _mapper.Map<List<CommentToProductVM>>(CommentToProduct);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<CommentToProductVM>> GetCommentToProductsByUserId(string id)
        {
            var blogs =( await _mediator.Send(new GetProductListRequest())).Where(a => a.Owner == id).ToList();
            var CommentOfVideoBlog = (await _mediator.Send(new GetCommentToProductListRequest()));
            var lstModel = new List<CommentToProductVM>();
            foreach (var blog in blogs)
            {
                foreach (var com in CommentOfVideoBlog)
                {
                    if (com.ProductId == blog.Id)
                        lstModel.Add(_mapper.Map<CommentToProductVM>(com));
                }

            }
            return lstModel;
        }

        public async Task<CommentToProductVM> GetCommentToProductsDetails(int id)
        {
            var response = new Response<int>();

    
            var apiResponse = await _mediator.Send(new GetCommentToProductDetailRequest() { Id = id });

            return _mapper.Map<CommentToProductVM>(apiResponse);
        }

        public async Task<Response<int>> UpdateCommentToProduct(int id, UpdateCommentToProductVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateCommentToProductDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateCommentToProductCommand() { Id = id, CommentToProductDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
