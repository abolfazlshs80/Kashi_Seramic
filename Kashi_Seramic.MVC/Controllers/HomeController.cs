using Kashi_Seramic.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Menu;
using System.Diagnostics;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.FaqUser;

namespace Kashi_Seramic.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IFaqUserService _faqUserService;
        public HomeController(ILogger<HomeController> logger,  IUserService userService, ISettingService settingService, IFaqUserService faqUserService)
        {
            _logger = logger;
            _settingService = settingService;
            _userService = userService;
            _faqUserService = faqUserService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "صفحه اصلی ما";
            // User.GetUserId();
            return View((await _settingService.GetSettings()).FirstOrDefault());
        }

        [Route("About")]
        [Route("AboutUs")]
        public async Task<IActionResult>  About()
        {
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;

            ViewBag.Title = "درباره ما";
            return View((await _settingService.GetSettings()).FirstOrDefault());
   
        }
        [Route("Contact")]
        [Route("ContactUs")]
        public async Task<IActionResult> Contact()
        {
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;

            ViewBag.Title = "ارتباط با ما ";
            return View((await _settingService.GetSettings()).FirstOrDefault());
        }
        [Route("Faq")]
        public async Task< IActionResult> Faq()
        {
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;
            ViewBag.LocationBarOne = " ";
            ViewBag.Title = "سوال های متداول";
            ViewBag.setting=( await _settingService.GetSettings()).FirstOrDefault();
            return View(await _faqUserService.GetFaqUsersByNumber(6));
        }

        [HttpPost()]
        public IActionResult InsertFaq(string name, string email, string msg_subject,string message)
        {
            //TODO Insert Contact Info
            ViewBag.StatusLocationBarOne = false;
            ViewBag.StatusLocationBar = true;
            ViewBag.LocationBarOne = " ";
            ViewBag.Title = "سوال های متداول";

            _faqUserService.CreateFaqUser(new CreateFaqUserVM()
            {
                Email = email,
                Owner = name,
                LastModifiedDate = DateTime.Now,
                DateCreated = DateTime.Now,
                CreatedBy = name,
                FullName = name,
                Text = message,
                Status = false,
                LastModifiedBy = name,
                
            });
            return  RedirectToAction("Faq");
        }
        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
         
                return View(new CreateMenuVM());
      
        }
        [HttpPost]
        public async Task < IActionResult> Privacy(CreateMenuVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return Content((await _userService.GetEmployees()).FirstOrDefault().Email);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        [Route("{*url}", Order = 999)]
        public IActionResult Error()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}