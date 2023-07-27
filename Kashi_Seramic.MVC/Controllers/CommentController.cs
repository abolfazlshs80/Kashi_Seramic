using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;

namespace Kashi_Seramic.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentToBlogService _commentToBlogService;
        private readonly IBlogService _BlogService;
        private readonly ICommentToProductService _commentToProductService;
        private readonly IProductService _ProductService;
        public CommentController(ICommentToBlogService commentToBlogService,ICommentToProductService commentToProductService,IBlogService blogService,IProductService productService)
        {
            _commentToBlogService = commentToBlogService;
            _commentToProductService= commentToProductService;
            _BlogService= blogService;
            _ProductService= productService;
        }
        [HttpPost]
        public async Task<IActionResult>  AddCommentBlog(CreateCommentToBlogVM model)
        {
      
            var Get_BLOG = await _BlogService.GetBlogsDetails(model.BlogId);
            if (Get_BLOG!=null)
            {
                await _commentToBlogService.CreateCommentToBlog(model);
            }
            
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentProduct(CreateCommentToProductVM model)
        {

            var Get_BLOG = await _ProductService.GetProductsDetails(model.ProductId);
            if (Get_BLOG != null)
            {
                await _commentToProductService.CreateCommentToProduct(model);
            }
            var Get_BLOG_VIDEO = await _ProductService.GetProductsDetails(model.Id);
           return RedirectToAction("Index", "Home");
 
        }
    }
}
