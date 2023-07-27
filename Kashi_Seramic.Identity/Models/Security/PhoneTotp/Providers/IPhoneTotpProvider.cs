using Kashi_Seramic.Identity.Models.Security.PhoneTotp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kashi_Seramic.Identity.Models.Security.PhoneTotp.Providers
{
    public interface IPhoneTotpProvider
    {
        /// <summary>
        /// Will generate a phone friendly TOTP.
        /// </summary>
        /// <param name="secretKey">A secret key that should be unique.</param>
        /// <returns>Phone friendly TOTP.</returns>
        string GenerateTotp(byte[] secretKey);

        /// <summary>
        /// Will validate the TOTP code based on the secret key.
        /// </summary>
        /// <param name="secretKey">The secret key that was used to create the TOTP.</param>
        /// <param name="totpCode">The TOTP code.</param>
        /// <returns><see cref="PhoneTotpResult"/></returns>
        PhoneTotpResult VerifyTotp(byte[] secretKey, string totpCode);
    }
}
