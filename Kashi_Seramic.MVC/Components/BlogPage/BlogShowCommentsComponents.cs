using Pr_Signal_ir.MVC.Models;

namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogShowCommentsComponents : ViewComponent
    {
        private readonly IBlogService _BlogService;
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public BlogShowCommentsComponents(IBlogService BlogService,
            IMapper mapper,
            IProductService productService)
        {
            _BlogService = BlogService;

            _mapper = mapper;
            _ProductService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new CommentVM();
            if (ViewBag.type == "Blog")
            {
                var _blogid = ViewBag.blogid;
                var modelblog = await _BlogService.GetBlogsDetails(_blogid);
                model.CommentToBlogVM = modelblog.CommentToBlog;
            }
            else if (ViewBag.type == "Product")
            {
                var Productid = ViewBag.blogid;
                var ModelProduct = await _ProductService.GetProductsDetails(Productid);
                model.CommentToProductVM = ModelProduct.CommentToProduct;
            }

            return View("/Views/Components/BlogPage/BlogShowComments.cshtml", model);
        }

    }
}


