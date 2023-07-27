using Kashi_Seramic.Application.Models.Identity;
using Pr_Signal_ir.Application.Extentions;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Users;

namespace Kashi_Seramic.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly IUserService _UserService;
        private readonly IAuthenticationService _AuthService;
        public UserController(IBlogService blogService, IMapper mapper, IUserService userService, IAuthenticationService authService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _UserService = userService;
            _AuthService = authService;
        }
        public async Task<IActionResult> LogOut()
        {
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user != null)
            {
                await _AuthService.Logout(userId);
            }
            return Redirect("/");
        }
        public async Task<IActionResult> GoMainSite()
        {
            return Redirect("/");
        }
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(User.GetUserId()))
            {
                return RedirectToAction("Logout", "Users");
            }
            string userId = User.GetUserId();

            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");
            return View(user);

        }
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EmployeeVM model)
        {
            var userState = await _UserService.IS_EXS_USERNAME(model.Username);
            if (userState.Success)
            {
                ModelState.AddModelError("", "نام کاربری تکراری است");
                return View(model);
            }
            var emailState = await _UserService.IS_EXS_EMAIL(model.Email);
            if (emailState.Success)
            {
                ModelState.AddModelError("", "ایمیل تکراری است");
                return View(model);
            }
            var user = await _UserService.GetEmployee(model.Id);
            if (user == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var res = await _UserService.UpdateEmployee(model);
                if (res.Status)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteAccount()
        {
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");
            await _UserService.DeleteEmployee(user);
            return RedirectToAction("/Home/Index");

        }
        [HttpPost]
        public async Task<IActionResult> ChnagePassword(string confirmPassword, string OldPassword, string newPassword)
        {
            //if (model.password == null)
            //{   model.password = new ChangePasswordModel();
            //    return RedirectToAction("EditUser", model);

            //}
            string userId = User.GetUserId();
            var user = await _UserService.GetEmployee(userId);
            if (user == null)
                return View("/Home/Error");
            var model = new UpdateUserVM();
            model.User = user;

            if (string.IsNullOrEmpty(newPassword))
            {

                TempData["Error"] = "اطلاعات به درستی وارد نشده است";
                model.Error = "adksjlwndsanasd";
                return RedirectToAction("EditUser", model);
            }
            await _UserService.ResetPassword(new ChangePasswordDto { UserId = userId, Password = newPassword });
            TempData["Error"] = "رمز عبور تغییر یافت";

            return RedirectToAction("EditUser");
        }



    }
}
