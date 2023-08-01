using Kashi_Seramic.Domain;
using Pr_Signal_ir.MVC.Models.Tag;

namespace Kashi_Seramic.MVC.Components.BlogPage
{
    public class BlogTagComponents : ViewComponent
    {
        private readonly IBlogService _BlogService;
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public BlogTagComponents(IBlogService BlogService,
            IMapper mapper,
            IProductService ProductService)
        {
            _BlogService = BlogService;

            _mapper = mapper;
            _ProductService = ProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new TagVM();

            if (ViewBag.type == "Blog")
            {
                var _blogid = ViewBag.blogid;
                var modelblog = await _BlogService.GetBlogsDetails(_blogid);
                model.TagToBlog = modelblog.TagToBlog;
            }
            else if (ViewBag.type == "Product")
            {
                var Productid = ViewBag.blogid;
                var ModelProduct = await _ProductService.GetProductsDetails(Productid);
               model.TagToProduct = ModelProduct.TagToProduct;
            }
            return View("/Views/Components/BlogPage/BlogTag.cshtml", model);

        }

    }
}
