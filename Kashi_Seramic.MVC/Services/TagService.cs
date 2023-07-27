using AutoMapper;


using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;

using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using Pr_Signal_ir.MVC.Models.Tag;
using Kashi_Seramic.Application.DTOs.Tag;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.MVC.Models.Search;

namespace Pr_Signal_ir.MVC.Services
{
    public class TagService : ITagService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
  

        public TagService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            
        }

        public async Task<Response<int>> CreateTag(CreateTagVM leaveType)
        {
            var model = new Response<int>() { };
            var res = await _mediator.Send(new CreateTagCommand() { CreateTagDto = (_mapper.Map<CreateTagDto>(leaveType)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }

        public async Task<Response<int>> DeleteTag(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteTagCommand() { Id = id });
            return model;
        }

        public async Task<IEnumerable<SearchVM>> GetTagBySearchVM(int id)
        {
            var model = await _mediator.Send(new GetTagDetailRequest() { Id = id });
            var list = new List<SearchVM>();

            list.AddRange(model.TagToBlog.Select(a => new SearchVM()
            {
                Desc = a.Blog.ShortTitle,
                Title = a.Blog.LongTitle,
                Id = a.Blog.Id,
                Type = "Blog",
                Blog = _mapper.Map<BlogVM>(a.Blog),
                path = a.Blog.FileToBlog?.FirstOrDefault()?.FileManager.Path
            }));
            list.AddRange(model.TagToProduct.Select(a => new SearchVM()
            {
                Desc = a.Product.TitleInBrowser,
                Title = a.Product.Title,
                Id = a.Product.Id,
                Type = "Product",
                Product = _mapper.Map<ProductVM>(a.Product),
                path = a.Product.FileToProduct?.FirstOrDefault()?.FileManager.Path
            }));
            return list;
        }

        public async Task<IEnumerable<SearchVM>> GetTagByTextSearchVM(string  text)
        {
            var model = await _mediator.Send(new GetTagListRequest() );
            var list = new List<SearchVM>();

            foreach (var item in model)
            {
                list.AddRange(item.TagToBlog.Select(a => new SearchVM()
                {
                    Desc = a.Blog.ShortTitle,
                    Title = a.Blog.LongTitle,
                    Id = a.Blog.Id,
                    Type = "Blog",
                    Blog = _mapper.Map<BlogVM>(a.Blog),
                    path = a.Blog.FileToBlog?.FirstOrDefault()?.FileManager.Path
                }));
                list.AddRange(item.TagToProduct.Select(a => new SearchVM()
                {
                    Desc = a.Product.TitleInBrowser,
                    Title = a.Product.Title,
                    Id = a.Product.Id,
                    Type = "Product",
                    Product = _mapper.Map<ProductVM>(a.Product),
                    path = a.Product.FileToProduct?.FirstOrDefault()?.FileManager.Path
                }));
            }
   
            return list.Distinct();
        }

        public async Task<List<TagVM>> GetTags()
        {
            try
            {
                var Tag = await _mediator.Send(new GetTagListRequest());

                if (Tag == null)
                {
                    throw new NotImplementedException();
                }
               var a = _mapper.Map<ICollection<TagVM>>(Tag);
                return _mapper.Map<List<TagVM>>(Tag);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TagVM>> GetTagsActive()
        {
            try
            {
                var Tag = await _mediator.Send(new GetTagListRequest());

                if (Tag == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<TagVM>>(Tag);
                return _mapper.Map<List<TagVM>>(Tag.Where(a=>a.Status).OrderByDescending(a=>a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TagVM>> GetTagsFindByText(string text)
        {
            try
            {
                var Tag = await _mediator.Send(new GetTagListRequest());

                if (Tag == null)
                {
                    throw new NotImplementedException();
                }
         
                return _mapper.Map<List<TagVM>>(Tag.Where(a=>a.Name.Contains(text)));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TagVM> GetTagsDetails(int id)
        {
            try
            {
                var Tag = await _mediator.Send(new GetTagDetailRequest() { Id = id });

                if (Tag == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<TagVM>(Tag);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response<int>> UpdateTag(int id, UpdateTagVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateTagDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateTagCommand() { Id = id, TagDto = Nmodel });
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }
    }

}
