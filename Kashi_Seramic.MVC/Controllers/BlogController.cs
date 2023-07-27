using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Kashi_Seramic.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ISettingService _settingService;
        public BlogController(IBlogService blogService, ISettingService settingService)
        {
            _blogService = blogService;
            _settingService = settingService;
        }
        [Route("/Blog/{Id}/{Title}")]
        public async Task<IActionResult> Blog(int Id, string Title)
        {
            var blog =await _blogService.GetBlogsDetails(Id);
            if (blog == null)
                return NotFound();
            //TODO Insert Contact Info
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;
            ViewBag.LocationBarOne = "مقاله ها";
            ViewBag.Title = Title;
            blog.Setting = (await _settingService.GetSettings()).FirstOrDefault();
            return View(blog);
        }
    }
}
