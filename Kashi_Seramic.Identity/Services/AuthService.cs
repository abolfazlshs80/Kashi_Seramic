
using Pr_Signal_ir.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Kashi_Seramic.Identity.Models;
using Kashi_Seramic.Identity.Models.Security.PhoneTotp.Providers;
using Kashi_Seramic.Application.Contracts.Identity;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Constants;

namespace Pr_Signal_ir.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IPhoneTotpProvider _phoneTotpProvider;
        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager, IPhoneTotpProvider phoneTotpProvider)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _phoneTotpProvider = phoneTotpProvider;
        }

        public Task<bool> ConfirmEmail(ConfirmEmailDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ForgotPassWord(FrogotPasswordDto request)
        {
            request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                 request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            else
            {

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                return resetPasswordToken;
            }
            //var resetPasswordUrl = Url.Action("ResetPassword", "Account",
            //    new { email = user.Email, token = resetPasswordToken }, Request.Scheme);
            //await sender.SendEmail("بازنشانی رمز عبور ", resetPasswordUrl, email, "پنل مدیریت سایت");
            return "null";
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            var claims = new List<Claim>()
            {
             new Claim("Email",user.Email),
             new Claim("UserName",user.UserName),
             new Claim("Id",user.Id),
             new Claim("FullName",user.FirstName +" "+user.LastName),
             new Claim("Id",user.Id),
            };
      await _signInManager.SignInWithClaimsAsync(user,true,claims);
     
            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = "new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)",
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<bool> Logout(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            request.UserName = request.Email;
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = "noset",
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }
        }

        public async Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return new ResetPasswordDto();
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (result.Succeeded)
            {
                request.Message = "رمزعبور شما با موفقیت تغییر یافت";
                request.Status = true;
            }

            request.Message = "";
            foreach (var error in result.Errors)
            {
                request.Message += error.Description + " , ";
            }

            request.Status = false;

            return request;
        }

        public async Task<ResponseDto> SendTotpCodeStatus(SendTotpCodeDto request)
        {
            var model = new ResponseDto();

            var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(request.PTC!);
            if (totpTempDataModel.ExpirationTime >= DateTime.Now)
            {
                var differenceInSeconds = (int)(totpTempDataModel.ExpirationTime - DateTime.Now).TotalSeconds;
                model.Message = $"برای ارسال دوباره کد، لطفا {differenceInSeconds} ثانیه صبر کنید.";
                model.Status = false;

            }
            model.Status = true;

            return model;
        }
        public async Task<SendTotpCodeDto> SendTotpCode(SendTotpCodeDto request)
        {
            try
            {
                byte[] secretKey;
                var key = Guid.NewGuid().ToByteArray();
              //  var key = (new Random().Next(1000,2000).ToString()).to;
                secretKey = key;
                //using (var rng = new RSACryptoServiceProvider())
                //{
                //    secretKey = new byte[32];
                //    rng.GetBytes(secretKey);
                //}

                request.Code = _phoneTotpProvider.GenerateTotp(key);


                var userExists = await _userManager.Users.AnyAsync(user => user.PhoneNumber == request.PhoneNumber);
                if (userExists)
                {
                  
                }
               

                request.PTC = JsonSerializer.Serialize(new PhoneTotpTempDataModel()
                {
                    SecretKey = secretKey,
                    PhoneNumber = request.PhoneNumber,
                    ExpirationTime = DateTime.Now.AddSeconds(60)
                });
                request.Status = true;
            }
            catch (Exception)
            {

                request.Status = false;
            }


            return request;
        }


        public async Task<VerifyTotpCodeDto> VeryfiyTotpCode(VerifyTotpCodeDto request)
        {


            var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(request.PTC.ToString()!);
            if (totpTempDataModel.ExpirationTime <= DateTime.Now)
            {
                request.Message = "کد ارسال شده منقضی شده، لطفا کد جدیدی دریافت کنید.";
                return request;
            }

            var user = await _userManager.Users
                .Where(u => u.PhoneNumber == totpTempDataModel.PhoneNumber)
                .FirstOrDefaultAsync();

            var result = _phoneTotpProvider.VerifyTotp(totpTempDataModel.SecretKey, request.TotpCode);
            if (result.Succeeded)
            {
                if (user == null)
                {
                    request.Message = "کاربری با شماره موبایل وارد شده یافت نشد.";
                    request.Status = false;
                    return request;

                }

                if (!user.PhoneNumberConfirmed)
                {
                    request.Status = false;
                    request.Message = "شماره موبایل شما تایید نشده است.";
                    return request;
                }

                if (!await _userManager.IsLockedOutAsync(user))
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _signInManager.SignInWithClaimsAsync(user, false, new List<Claim>());

                    request.Status = true;
                    request.Message = "شماره موبایل شما تایید شد است.";
                    return request;
                }

                request.Message = "اکانت شما به دلیل ورود ناموفق تا مدت زمان معینی قفل شده است.";
                return request;
            }

            if (user != null && user.PhoneNumberConfirmed && !await _userManager.IsLockedOutAsync(user))
            {
                await _userManager.AccessFailedAsync(user);
            }

            request.Message= "کد ارسال شده معتبر نمی باشد، لطفا کد جدیدی دریافت کنید.";
            return request;
        }

        public async Task<VerifyTotpCodeDto> VeryfiyTotpCodeStatus(VerifyTotpCodeDto request)
        {


            var totpTempDataModel = JsonSerializer.Deserialize<PhoneTotpTempDataModel>(request.PTC.ToString()!);
            if (totpTempDataModel.ExpirationTime <= DateTime.Now)
            {
                request.Message = "کد ارسال شده منقضی شده، لطفا کد جدیدی دریافت کنید.";
                request.Status = false;

            }
            request.Status = true;
            return request;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
