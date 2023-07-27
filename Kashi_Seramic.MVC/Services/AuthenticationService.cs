using AutoMapper;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Pr_Signal_ir.MVC.Services;

using MediatR;
using Kashi_Seramic.Application.Contracts.Identity;
using Kashi_Seramic.Application.Contracts.Infrastructure;
using Kashi_Seramic.Application.Models.Identity;
using System.Security.Policy;

namespace Pr_Signal_ir.MVC.Contracts.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        ILocalStorageService _localStorage;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private JwtSecurityTokenHandler _tokenHandler;
        private readonly IAuthService _authenticationService;
        private readonly IEmailSender _EmailSender;

        public AuthenticationService( ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor,
            IMapper mapper, IAuthService authenticationService, IEmailSender EmailSender)
            
        {
            _localStorage = localStorage;
            _EmailSender = EmailSender;
            _authenticationService = authenticationService;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new() { Email = email, Password = password };
                var authenticationResponse = await _authenticationService.Login(authenticationRequest);




                if (authenticationResponse.Token != string.Empty)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("Email",authenticationResponse.Email),
                        new Claim("UserName",authenticationResponse.UserName),
                        new Claim("Id",authenticationResponse.Id),
                       
                        
                    };
//    Get Claims from token and Build auth user object
                    //     var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
                    //   var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorage.SetStorageValue("token", authenticationResponse.Token);

                    return true;
                }
                return false;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Register(RegisterVM registration)
        {

            var registrationRequest = _mapper.Map<RegistrationRequest>(registration);
            var response = await  _authenticationService.Register(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                await Authenticate(registration.Email, registration.Password);
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //_authenticationService.Logout()
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        public async Task<string> ForgotPassWord(FrogotPasswordDto request)
        {
            //var Token = await _authenticationService.ForgotPassWord(request);
            //var body = Url.Action("ResetPassword", "Users",
            //    new { email = request.Email, token = Token }, Request.Scheme);
            //await _EmailSender.SendEmail(new Application.Models.Email { Body = body, Subject = "لینک فراموشی", To = request.Email });
            //return Ok(true);
            return "";
        }

       public async Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request)
        {
            return await _authenticationService.RessetPassword(request);
          
        }

       public async Task<bool> ConfirmEmail(ConfirmEmailDto request)
        {
            return await _authenticationService.ConfirmEmail(request);
        }

       public async Task<ResponseDto> SendTotpCodeStatus(SendTotpCodeDto request)
        {
            return await _authenticationService.SendTotpCodeStatus(request);
        }

       public async Task<SendTotpCodeDto> SendTotpCode(SendTotpCodeDto request)
        {
            return await _authenticationService.SendTotpCode(request);
        }

       public async Task<VerifyTotpCodeDto> VeryfiyTotpCodeStatus(VerifyTotpCodeDto request)
        {
            return await _authenticationService.VeryfiyTotpCodeStatus(request);
        }

       public async Task<VerifyTotpCodeDto> VeryfiyTotpCode(VerifyTotpCodeDto request)
        {
            return await _authenticationService.VeryfiyTotpCode(request);
        }

       public async Task<bool> Logout(string id)
        {
            return await _authenticationService.Logout(id);
        }
    }
}
