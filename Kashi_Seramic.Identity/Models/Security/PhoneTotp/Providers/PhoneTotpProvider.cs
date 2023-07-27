using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Identity.Models.Security.PhoneTotp;
using Microsoft.Extensions.Options;
using OtpNet;

namespace Kashi_Seramic.Identity.Models.Security.PhoneTotp.Providers
{
    public class PhoneTotpProvider : IPhoneTotpProvider
    {
        private Totp _totp;
        private readonly PhoneTotpOptions _options;

        public PhoneTotpProvider(IOptions<PhoneTotpOptions> options)
        {
            _options = options?.Value ?? new PhoneTotpOptions();
        }

        /// <inheritdoc/>
        public string GenerateTotp(byte[] secretKey)
        {
            CreateTotp(secretKey);

            return _totp.ComputeTotp();
        }

        /// <inheritdoc/>
        public PhoneTotpResult VerifyTotp(byte[] secretKey, string totpCode)
        {
            CreateTotp(secretKey);

            var isTotpCodeValid = _totp.VerifyTotp(totpCode, out _, VerificationWindow.RfcSpecifiedNetworkDelay);
            if (isTotpCodeValid)
            {
                return new PhoneTotpResult()
                {
                    Succeeded = true
                };
            }

            return new PhoneTotpResult()
            {
                Succeeded = false,
                ErrorMessage = "کد وارد شده معتبر نیست، لطفا کد جدیدی دریافت بکنید."
            };
        }

        private void CreateTotp(byte[] secretKey)
        {
            _totp = new Totp(secretKey, _options.StepInSeconds);
        }
    }
}
