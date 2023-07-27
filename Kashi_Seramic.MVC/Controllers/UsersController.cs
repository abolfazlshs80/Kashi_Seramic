using Kashi_Seramic.Application.Contracts.Infrastructure;
using Kashi_Seramic.Application.Models.Identity;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Models.Users;
using Pr_Signal_ir.MVC.Services;

namespace Kashi_Seramic.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly IHubContext<NotifyHub> _notifyHub;
        private readonly IUserService _UserService;
        private readonly IEmailSender _Email;

        public int Take { get; set; } = 5;
        private readonly IMapper _mapper;
        public UsersController(IAuthenticationService authService, IMapper mapper, IUserService userService, IHubContext<NotifyHub> notifyHub)
        {

            this._authService = authService;
            _mapper = mapper;
            _notifyHub = notifyHub;
            _UserService = userService;

        }
        [HttpGet("/login")]
        [HttpGet("/Users/login")]
        [HttpGet("/Account/login")]
        public async Task<IActionResult> Login(string email, string password, string ReturnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            ViewBag.ReturnUrl = ReturnUrl;


            var isLoggedIn = await _authService.Authenticate(email, password);
            if (isLoggedIn)
            {
                await _notifyHub.Clients.All.SendAsync("Send", "ورود", "با موفقیت  وارد حساب کاربری خود شدید");
                return LocalRedirect(ReturnUrl ?? "/");
            }
            ViewBag.Error = "کلمه عبور با نام کاربری مطابقت ندارد";
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        [HttpPost("/Users/Register")]
        public async Task<IActionResult> Register(string RePassword, string Password, string Email, string FirstName, string ReturnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            if (!Password.Equals(RePassword)||Password.Length<=6)
            {
                ViewBag.Error = "رمز باید حداقل 6 حرف باشد";
               
                return View();
            }

            var userState = await _UserService.IS_EXS_USERNAME(Email);
            if (userState.Success)
            {
                ViewBag.Error = "نام کاربری تکراری است";

                return View();
            }
            var emailState = await _UserService.IS_EXS_EMAIL(Email);
            if (emailState.Success)
            {
           
                ViewBag.Error =  "ایمیل تکراری است";
        
                return View();
            }

          //  var returnUrl = ReturnUrl ?? "/";
            var isCreated = await _authService.Register(new RegisterVM() { Email = Email, Password = Password, FirstName = FirstName });
            if (isCreated)
                return LocalRedirect(ReturnUrl ?? "/");

            ViewBag.Error =  "با خطا مواجه شد";
            return View();
        }

        [HttpGet("/Logout")]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var user = User;
            var id = User.FindFirst("id")?.ToString().Replace("id: ", "");
            var ID = User.FindFirstValue("id");
            await _authService.Logout(ID);
          await  _authService.Logout();
          string KoockiesName = ".AspNetCore.Identity.Application";
          if
              (Request.Cookies.ContainsKey(KoockiesName))
          {
              Response.Cookies.Delete(KoockiesName);
            }
 

            return LocalRedirect(returnUrl);
        }









        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var result = await _authService.ConfirmEmail(new ConfirmEmailDto { Email = userName, Token = token });

            return Content(result ? "Email Confirmed" : "Email Not Confirmed");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {

            var message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            var resetPasswordToken = await _authService.ForgotPassWord(new FrogotPasswordDto { Email = model.Email });
            var resetPasswordUrl = Url.Action("ResetPassword", "Users",
                new { email = model.Email, token = resetPasswordToken }, Request.Scheme);
            //    await _Email.SendEmail(new Application.Models.Email { To = model.Email, Subject = "بازنشانی رمز عبور", Body = resetPasswordUrl });
            //   await sender.SendEmail("بازنشانی رمز عبور ", resetPasswordUrl, m, "پنل مدیریت سایت");
            return RedirectToAction("Index", "Home", new { ErrorMessage = message });
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
                return Redirect("/");

            var model = new ResetPasswordVM()
            {
                Email = email,
                Token = token

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RessetPassword(_mapper.Map<ResetPasswordDto>(model));
                if (result.Status.Value)
                {
                    ViewData["ErrorMessage"] = "رمزعبور شما با موفقیت تغییر یافت";
                    return View("Login");
                }


                ModelState.AddModelError("", result.Message);

            }

            return View(model);
        }











        [HttpGet]
        public async Task<IActionResult> SendTotpCode()
        {
            var model = new SendTotpCodeDto();

            //      if (_signInManager.IsSignedIn(User)) return Redirect("/");
            if (TempData.ContainsKey("PTC"))
            {
                model.PTC = TempData["PTC"].ToString();
                await _authService.SendTotpCodeStatus(model);
                if (!model.Status.Value)
                {

                    ModelState.AddModelError("", model.Message);
                    TempData.Keep("PTC");
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendTotpCode(SendTotpCodeVM newmodel)

        {
            SendTotpCodeDto model = new SendTotpCodeDto();
            model.PhoneNumber = newmodel.PhoneNumber;
            //    if (_signInManager.IsSignedIn(User)) return Redirect("/");
            if (TempData.ContainsKey("PTC"))
            {
                model.PTC = TempData["PTC"].ToString()!;
                await _authService.SendTotpCodeStatus(model);

                if (!(model.Status.Value))
                {

                    ModelState.AddModelError("", model.Message == null ? "" : model.Message);
                    TempData.Keep("PTC");
                    return View();
                }

            }

            var m = await _authService.SendTotpCode(model);
            TempData["PTC"] = m.PTC;
            return Content(m.Code.ToString());


            return View(newmodel);
        }



        [HttpGet]
        public async Task<IActionResult> VerifyTotpCode()
        {
            //     ClaimsPrincipal User1=User;

            // if (_signInManager.IsSignedIn(User1)) return Redirect("/");
            if (!TempData.ContainsKey("PTC"))
                return NotFound();
            var model = new VerifyTotpCodeDto();
            model.PTC = TempData["PTC"].ToString()!;
            var newmodel = await _authService.VeryfiyTotpCodeStatus(model);
            if (!newmodel.Status.Value)
            {
                TempData["SendTotpCodeErrorMessage"] = newmodel.Message;
                return RedirectToAction("SendTotpCode");
            }

            TempData.Keep("PTC");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyTotpCode(VerifyTotpCodeVM model)
        {
            var newmodel = new VerifyTotpCodeDto();
            newmodel.PTC = TempData["PTC"].ToString()!;
            //   if (_signInManager.IsSignedIn(User)) return Redirect("/");
            if (!TempData.ContainsKey("PTC")) return NotFound();
            if (ModelState.IsValid)
            {
                newmodel = await _authService.VeryfiyTotpCode(newmodel);

                if (!newmodel.Status.Value)
                {
                    TempData["SendTotpCodeErrorMessage"] = newmodel.Message;
                    return RedirectToAction("SendTotpCode");
                }

                else if (newmodel.Status.Value)
                {
                    TempData.Remove("PTC");
                    return Redirect("/");
                }

                TempData["SendTotpCodeErrorMessage"] = newmodel.Message;


            }

            return RedirectToAction("SendTotpCode");
        }



    }
}
