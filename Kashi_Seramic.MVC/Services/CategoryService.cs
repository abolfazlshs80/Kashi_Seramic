using AutoMapper;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Domain;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Category;
using Kashi_Seramic.Application.Features.Blog.Requests.Commands;
using Kashi_Seramic.Application.Features.Blog.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserService _UserService;
        public CategoryService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService, IUserService UserService) 
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            _UserService = UserService;
        }

        public async Task<IEnumerable<SearchVM>> GetCategoryBySearchVM(string name)
        {
            var model =( await _mediator.Send(new GetCategoryListRequest() )).Where(a=>a.Name.Contains(name));
            var list = new List<SearchVM>();

            foreach (var item in model)
            {
                list.AddRange(item.CategoryToBlog.Select(a => new SearchVM()
                {
                    Desc = a.Blog.ShortTitle,
                    Title = a.Blog.LongTitle,
                    Id = a.Blog.Id,
                    Type = "Blog",
                    Blog = _mapper.Map<BlogVM>(a.Blog),
                    path = a.Blog?.FileToBlog?.FirstOrDefault()?.FileManager?.Path?.SetForBlogUrl(),
                    Url = $"/Blog/{a.Blog.Id}/{a.Blog.TitleBrowser.SetForUrl()}",
                    Date = a.Blog.DateCreated,
                    Owener = (_UserService.GetEmployee(a.Blog.Owner)).Result.Firstname + " " + (_UserService.GetEmployee(a.Blog.Owner)).Result.Firstname
                }));
                list.AddRange(item.CategoryToProduct.Select(a => new SearchVM()
                {
                    Desc = a.Product.TitleInBrowser,
                    Title = a.Product.Title,
                    Id = a.Product.Id,
                    Type = "Product",
                    Product = _mapper.Map<ProductVM>(a.Product),
                    path = a.Product?.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl(),
                    Url = $"/Product/{a.Product.Id}/{a.Product.TitleInBrowser.SetForUrl()}",
                    Date = a.Product.LastModifiedDate.Value,
                    Owener =( _UserService.GetEmployee(a.Product.Owner)).Result.Firstname+" "+ (_UserService.GetEmployee(a.Product.Owner)).Result.Firstname
                }));
        
            }
            return list;
        }

        public async Task<Response<int>> CreateCategory(CreateCategoryVM cate)
        {
            var response = new Response<int>();
            var res = await _mediator.Send(new CreateCategoryCommand() {CreateCategoryDto  = (_mapper.Map<CreateCategoryDto>(cate)) });
            if (res.Success)
            {
                response.Success = true;
                response.Data = res.Id;

            }
            else
                response.Success = false;
            return response;
        }



        public async Task<Response<int>> DeleteCategory(int id)
        {
            var response = new Response<int>();
            await _mediator.Send(new DeleteCategoryCommand() { Id = id });

            response.Success = true;



            return response;



        }

        public async Task<Response<int>> ExistsCategory(int id)
        {
          
                var response = new Response<int>();

        
                var apiResponse = await _mediator.Send(new GetCategoryDetailRequest() { Id = id });
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

        public async Task<IEnumerable<SearchVM>> GetBlogsCategoryBySearchVM(int cateid)
        {
            var model = await _mediator.Send(new GetCategoryDetailRequest() { Id = cateid });
            var list = new List<SearchVM>();
         
           list.AddRange( model.CategoryToBlog.Select(a => new SearchVM()
            {
               Desc = a.Blog.ShortTitle,
               Title = a.Blog.LongTitle,
               Id = a.Blog.Id,
               Type = "Blog",
               Blog = _mapper.Map<BlogVM>(a.Blog),
               path = a.Blog?.FileToBlog?.FirstOrDefault()?.FileManager?.Path?.SetForBlogUrl(),
               Url = $"/Blog/{a.Blog.Id}/{a.Blog.TitleBrowser.SetForUrl()}",
               Date = a.Blog.DateCreated,
               Owener = (_UserService.GetEmployee(a.Blog.Owner)).Result.Firstname + " " + (_UserService.GetEmployee(a.Blog.Owner)).Result.Firstname
           }));
            list.AddRange(model.CategoryToProduct.Select(a => new SearchVM()
            {
                Desc = a.Product.TitleInBrowser,
                Title = a.Product.Title,
                Id = a.Product.Id,
                Type = "Product",
                Product = _mapper.Map<ProductVM>(a.Product),
                path = a.Product?.FileToProduct?.FirstOrDefault()?.FileManager?.Path?.SetForProductUrl(),
                Url = $"/Product/{a.Product.Id}/{a.Product.TitleInBrowser.SetForUrl()}",
                Date = a.Product.LastModifiedDate.Value,
                Owener = (_UserService.GetEmployee(a.Product.Owner)).Result.Firstname + " " + (_UserService.GetEmployee(a.Product.Owner)).Result.Firstname
            }));
            return list;
        }

        public async Task<List<CategoryVM>> GetCategorys()
        {


            var Category = await _mediator.Send(new GetCategoryListRequest());
            if (Category == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<CategoryVM>>(Category);


        }

        public async Task<List<CategoryVM>> GetCategorysActive()
        {
            var Category = await _mediator.Send(new GetCategoryListRequest());
            if (Category == null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<List<CategoryVM>>(Category.Where(a=>a.Status).OrderByDescending(a=>a.Id));
        }

        public async Task<CategoryVM> GetCategorysDetails(int id)
        {
            try
            {
                var Category = await _mediator.Send(new GetCategoryDetailRequest() { Id = id });
                if (Category == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<CategoryVM>(Category);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }

        public async Task<Response<int>> UpdateCategory(int id, UpdateCategoryVM leaveType)
        {
            var response = new Response<int>();
            await _mediator.Send(new UpdateCategoryCommand() { Id = id,CategoryDto=_mapper.Map<UpdateCategoryDto>(leaveType) });

            response.Success = true;

            return response;
        }
    }

}
