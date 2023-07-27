using AutoMapper;
using Pr_Signal_ir.MVC.Contracts;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pr_Signal_ir.MVC.Models.Search;

using System.Reflection.Metadata;
using AutoMapper.Execution;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Kashi_Seramic.Application.Features.Blog.Requests.Queries;
using Kashi_Seramic.Application.Features.Blog.Requests.Commands;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Pr_Signal_ir.MVC.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;


        public BlogService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper, ILocalStorageService localStorageService)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
            this._localStorageService = localStorageService;
            this._mapper = mapper;

        }
        public async Task<Response<int>> CreateBlog(CreateBlogVM blog)
        {
            var model = new Response<int>() { };
         //   blog.
            var res = await _mediator.Send(new CreateBlogCommand() { CreateBlogDto = (_mapper.Map<CreateBlogDto>(blog)) });
            if (res.Success)
            {
                model.Data = res.Id;
                model.Success = res.Success;
                return model;
            }
            else
                return model;
        }



        public async Task<Response<int>> DeleteBlog(int id)
        {
            var model = new Response<int>() { };
            await _mediator.Send(new DeleteBlogCommand() { Id = id });
            return model;
        }

        public async Task<Response<bool>> ExistsBlog(int id)
        {
            var res = await _mediator.Send(new GetBlogDetailRequest() { Id = id });
            var model = new Response<bool>() { };
            if (res != null)
            {
                
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }

        public async Task<List<BlogVM>> GetBlogs()
        {

            try
            {
                var blog = await _mediator.Send(new GetBlogListRequest());

                if (blog == null)
                {
                    throw new NotImplementedException();
                }
         //       var a = _mapper.Map<ICollection<BlogVM>>(blog);
                return _mapper.Map<List<BlogVM>>(blog.OrderByDescending(a=>a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<BlogVM>> GetBlogsActive()
        {
            try
            {
                var blog = await _mediator.Send(new GetBlogListRequest());

                if (blog == null)
                {
                    throw new NotImplementedException();
                }
                //       var a = _mapper.Map<ICollection<BlogVM>>(blog);
                return _mapper.Map<List<BlogVM>>(blog.Where(a=>a.Status).OrderByDescending(a => a.Id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SearchVM>> GetBlogsBySearchVM(string text)
        {
            var model = await _mediator.Send(new GetBlogListRequest());

            var newmodel = model.Where(a => a.Text.Contains(text) ||
            a.ShortTitle.Contains(text) ||
            a.LongTitle.Contains(text) ||
            a.Tag.Contains(text) ||
            a.TitleBrowser.Contains(text)).Select(a => new SearchVM()
            {
                Desc = a.ShortTitle,
                Title = a.LongTitle,
                Id = a.Id,
                Type = "Blog",
                Blog = _mapper.Map<BlogVM>(a),
                path = a.FileToBlog?.FirstOrDefault()?.FileManager.Path
            });
            if (string.IsNullOrEmpty(text))
            {
                return model.Select(a => new SearchVM()
                {
                    Desc = a.ShortTitle,
                    Title = a.LongTitle,
                    Id = a.Id,
                    Type = "Blog",
                    Blog = _mapper.Map<BlogVM>(a),
                    path = a.FileToBlog?.FirstOrDefault()?.FileManager.Path
                });
            }

            return (newmodel);
        }

        public async Task<List<BlogVM>> GetBlogsByUserId(string UserId)
        {
            try
            {
                var blog = await _mediator.Send(new GetBlogListRequest());
                if (blog == null)
                {
                    throw new NotImplementedException();
                }
                var a = _mapper.Map<ICollection<BlogVM>>(blog);
                return _mapper.Map<List<BlogVM>>(blog.Where(a => a.Owner.Equals(UserId)).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

  public async  Task   <List<SearchVM>> GetBlogsCategoryBySearchVM(int cateid)
        {
            throw new NotImplementedException();
        }

  public async Task<List<SearchVM>> GetBlogsCategoryBySearchVM()
  {
      var model = await _mediator.Send(new GetBlogListRequest() );
      var list = new List<SearchVM>();

      list.AddRange(model.Select(a => new SearchVM()
      {
          Desc = a.ShortTitle,
          Title = a.LongTitle,
          Id = a.Id,
          Type = "Blog",
          Blog = _mapper.Map<BlogVM>(a),
          path = a?.FileToBlog?.FirstOrDefault()?.FileManager?.Path?.SetForBlogUrl(),
          Url = $"/Blog/{a.Id}/{a.TitleBrowser.SetForUrl()}",
          Date = a.DateCreated,
          Owener = a.Owner
      }));
      return list;
  }

  public async Task<BlogVM> GetBlogsDetails(int id)
        {
            try
            {
                var blog =  await _mediator.Send(new GetBlogDetailRequest() { Id=id});

                if (blog == null)
                {
                    throw new NotImplementedException();
                }
                return _mapper.Map<BlogVM>(blog);
            }
            catch (Exception)
            {
                return null;
            }

            // 
        }

        public async Task<Response<int>> UpdateBlog(int id, UpdateBlogVM leaveType)
        {
            var Nmodel = _mapper.Map<UpdateBlogDto>(leaveType);
            Nmodel.LastModifiedBy = "Abolfazl";
            Nmodel.LastModifiedDate = DateTime.Now;
            await _mediator.Send(new UpdateBlogCommand() { Id=id,blogDto=Nmodel});
            var model = new Response<int>() { };
            model.Success = true;
            model.Data = Nmodel.Id;

            return model;
        }

        public async Task<Response<bool>> UserInOwner(string UserId, int id)
        {
            var res = await _mediator.Send(new GetBlogListRequest());

            var model = new Response<bool>() { };
            if (res.Any(a => a.Owner.Equals(UserId) && a.Id.Equals(id)))
            {
                model.Success = true;
            }
            else
                model.Success = false;

            return model;
        }
    }
}
