using Microsoft.AspNetCore.Mvc;

namespace Versionamento.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Verifica a saúde da API.
        /// </summary>
        /// <response code="200">API saudável</response>
        [HttpGet]
        [Route("Check")]
        [ApiVersion("1.1", Deprecated = true)]
        public IActionResult Check_v1_1()
            => Ok(new { Message = "Aplicacao Funcionando! v1.1" });

        /// <summary>
        /// Verifica a saúde da API.
        /// </summary>
        /// <response code="200">API saudável</response>
        [HttpGet, MapToApiVersion("1.0")]
        [HttpGet, MapToApiVersion("2.0")]
        [Route("Check")]
        public IActionResult Check_v2_0()
            => Ok(new { Message = "Aplicacao Funcionando! v1.0 and 2.0" });
    }
}