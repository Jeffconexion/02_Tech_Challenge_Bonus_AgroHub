using Microsoft.AspNetCore.Mvc;

namespace AgroHub.Api.Controllers.V2
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        [HttpGet]
        public IActionResult GetTeste()
        {
            return Ok("This is version 2.0");
        }
    }
}
