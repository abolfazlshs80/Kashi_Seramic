using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;


    public class RemoteValidationController : Controller
    {
        private readonly IUserService _userService;
        public RemoteValidationController(IUserService userService)
        {
            _userService = userService;
        }
    [HttpPost, ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> IS_EMAIL_USE(string email)
        {
            var user = await _userService.IS_EXS_EMAIL(email);
            if (!user.Success) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IS_USERNAME_USE(string username)
        {
            var user = await _userService.IS_EXS_USERNAME(username);
            if (!user.Success) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> IS_PHONE_USE(string phone)
        {
            var user = await _userService.IS_EXS_PHONE(phone);
            if (!user.Success) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }
    }

