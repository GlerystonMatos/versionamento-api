using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;
using Versionamento.Domain.Dto;
using Versionamento.Domain.Exception;
using Versionamento.Domain.Interfaces.Services;

namespace Versionamento.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
            => _animalService = animalService;

        /// <summary>
        /// Consulta
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        [HttpGet]
        [EnableQuery()]
        [ApiVersion("2.0")]
        [ApiVersion("1.1", Deprecated = true)]
        [ApiVersion("1.0", Deprecated = true)]
        [ProducesResponseType(typeof(IQueryable<AnimalDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_animalService.ObterTodos());
    }
}