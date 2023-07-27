using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;

namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogAddCommentsComponents : ViewComponent
    {
        private readonly IBlogService _BlogService;
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public BlogAddCommentsComponents(IBlogService BlogService,
            IMapper mapper,
            IProductService productService)
        {
            _BlogService = BlogService;

            _mapper = mapper;
            _ProductService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
     
            var blogid = ViewBag.blogid;
            return View("/Views/Components/BlogPage/BlogAddComments.cshtml", new CreateCommentToBlogVM(){BlogId = blogid});
        }

    }
}


