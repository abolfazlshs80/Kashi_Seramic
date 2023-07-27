using Microsoft.AspNetCore.Mvc;

namespace Kashi_Seramic.MVC.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductService _productService;
        private readonly ISettingService _settingService;
        public ProductController1(IProductService productService, ISettingService settingService)
        {
            _productService = productService;
            _settingService = settingService;
        }
        [Route("/Product/{Id}/{Title}")]
        public async Task<IActionResult> Product(int Id, string Title)
        {
            var blog = await _productService.GetProductsDetails(Id);
            if (blog == null)
                return NotFound();
            //TODO Insert Contact Info
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;
            ViewBag.LocationBarOne = "محصول ها";
            ViewBag.Title = Title;
            blog.Setting= (await _settingService.GetSettings()).FirstOrDefault();
            return View(blog);
        }
    }
}
