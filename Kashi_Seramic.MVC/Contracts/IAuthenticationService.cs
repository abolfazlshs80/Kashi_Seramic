
using Kashi_Seramic.Application.Models.Identity;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM registration);
        Task<string> ForgotPassWord(FrogotPasswordDto request);
        Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request);
        Task<bool> ConfirmEmail(ConfirmEmailDto request);
        Task<ResponseDto> SendTotpCodeStatus(SendTotpCodeDto request);
        Task<SendTotpCodeDto> SendTotpCode(SendTotpCodeDto request);
        Task<VerifyTotpCodeDto> VeryfiyTotpCodeStatus(VerifyTotpCodeDto request);
        Task<VerifyTotpCodeDto> VeryfiyTotpCode(VerifyTotpCodeDto request);
        Task<bool> Logout(string id);
        Task Logout();
    }
}
