//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Pr_Signal_ir.MVC.Contracts;
//using Pr_Signal_ir.MVC.Services;

//namespace Pr_Signal_ir.MVC.Components
//{
//    public class BlogLinkComponents : ViewComponent
//    {
//        private readonly IBlogService _BlogService;
//        private readonly IBlogVideoService _BlogVideoService;

//        private readonly IMapper _mapper;

//        public BlogLinkComponents(IBlogService BlogService,
//            IMapper mapper,
//            IBlogVideoService blogVideoService)
//        {
//            this._BlogService = BlogService;

//            this._mapper = mapper;
//            _BlogVideoService = blogVideoService;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            if (ViewBag.type == "Blog")
//            {
//                var _blogid = ViewBag.blogid;
//                var modelblog = await _BlogService.GetBlogsDetails(_blogid);
               
//                return View("/Views/Components/BlogLink.cshtml", modelblog.linkKey);
//            }
//            else if (ViewBag.type == "BlogVideo")
//            {
//                var BlogVideoid = ViewBag.blogid;
//                var ModelBlogVideo = await _BlogVideoService.GetBlogVideosDetails(BlogVideoid);
//                return View("/Views/Components/BlogLink.cshtml", ModelBlogVideo.LinkKey);
//            }
            
          
//            return View("/Views/Components/BlogLink.cshtml", "لینک ندارد");
//        }
    
//    }
//}
