using AutoMapper;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.CategoryToBlog;
using Pr_Signal_ir.MVC.Models.FileToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class CategoryToBlogService : ICategoryToBlogService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryToBlogService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;

        }

        public async Task<Response<int>> CreateCategoryToBlog(CreateCategoryToBlogVM cate)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateCategoryToBlogCommand() { CreateCategoryToBlogDto = (_mapper.Map<CreateCategoryToBlogDto>(cate)) });
            if (res.Success)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<Response<int>> DeleteCategoryToBlog(int id)
        {
            var model = new Response<int>() { };

            await _mediator.Send(new DeleteCategoryToBlogCommand() { Id = id });


            return model;
        }

        public async Task<Response<int>> DeleteCategoryToAnyBlog(int id)
        {
          var categories=  await _mediator.Send(new GetCategoryToBlogListRequest() { });
            var model = new Response<int>() { };
            foreach (var item in categories.Where(a=>a.BlogId==id))
            {
                await _mediator.Send(new DeleteCategoryToBlogCommand() {Id = item.BlogId});
            }

            model.Success = true;
            return model;
        }

        public async Task<Response<int>> ExistsCategoryToBlog(int id)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new GetCategoryToBlogDetailRequest() { Id = id });
            if (res != null)
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<CategoryToBlogVM> GetCategoryToBlogDWithCateId(int id)
        {
            var category = await _mediator.Send(new GetCategoryToBlogListRequest());
            return _mapper.Map<CategoryToBlogVM>(category.Where(a => a.CategoryId == id).ToList());

        }

        public async Task<List<CategoryToBlogVM>> GetCategoryToBlogs()
        {
            var category = await _mediator.Send(new GetCategoryToBlogListRequest());
            return _mapper.Map<List<CategoryToBlogVM>>(category);
        }

        public async Task<CategoryToBlogVM> GetCategoryToBlogWithBlogId(int id)
        {
            var category = await _mediator.Send(new GetCategoryToBlogListRequest());
            return _mapper.Map<CategoryToBlogVM>(category.Where(a => a.BlogId == id).ToList());
        }
    }

}
