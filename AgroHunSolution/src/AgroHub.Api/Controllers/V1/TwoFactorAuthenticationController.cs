using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgroHub.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Authentication")]
    public class TwoFactorAuthenticationController : MainController
    {
        private readonly TwoFactorAuthenticator _twoFactorAuthenticator;
        private readonly ILogger<TwoFactorAuthenticationController> _logger;


        public TwoFactorAuthenticationController(ILogger<TwoFactorAuthenticationController> logger)
        {
            _twoFactorAuthenticator = new TwoFactorAuthenticator();
            _logger = logger;
        }

        /// <summary>
        /// Generate QR code for Authetication.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A response QR Code by authetication.</returns>
        /// <response code="200">Returns the updated product.</response>
        [HttpGet("generate-qrcode")]
        [SwaggerResponse(200, "Returns url by qrcode.")]
        public ActionResult<string> GenerateQR(string email)
        {
            string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            SetupCode setupInfo = _twoFactorAuthenticator.GenerateSetupCode("Agro Hub (2FA)", email, key, false, 3);

            //~~> This information save in database.
            _logger.LogInformation($"Key: {key}");

            return StatusCode(200, setupInfo.QrCodeSetupImageUrl);
        }


        /// <summary>
        /// Validate QR code generate.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="kay"></param>
        /// <returns>Response if the Qr code is valid.</returns>
        /// <response code="200">Returns the updated product.</response>
        [HttpPost("validate-qrcode")]
        [SwaggerResponse(200, "Validate if QR Code is valid.")]
        public ActionResult<bool> ValidateCode(string code, string key)
        {
            //~~> get key in database
            return StatusCode(200, _twoFactorAuthenticator.ValidateTwoFactorPIN(key, code));
        }
    }
}
