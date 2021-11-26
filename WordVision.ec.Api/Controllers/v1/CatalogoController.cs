using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WordVision.ec.API.Controllers;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached;

namespace WordVision.ec.Api.Controllers.v1
{

    public class CatalogoController : BaseApiController<CatalogoController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
            return Ok(response);
        }

    }
}
