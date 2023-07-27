using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;

namespace Kashi_Seramic.MVC.Components.ProductPage
{
    public class ProductAddCommentsComponents : ViewComponent
    {


        private readonly IMapper _mapper;

        public ProductAddCommentsComponents(IProductService ProductService,
            IMapper mapper,
            IProductService productService)
        {
          

            _mapper = mapper;
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
     
            var Productid = ViewBag.blogid;
            return View("/Views/Components/ProductPage/ProductAddComments.cshtml", new CreateCommentToProductVM(){ProductId = Productid});
        }

    }
}


