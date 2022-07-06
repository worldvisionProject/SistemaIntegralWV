using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class PaisController :  BaseController<PaisController>
    {
        public async Task<JsonResult> GetProvincia(int idRegion)
        {
            var entidadModel = await _mediator.Send(new GetProvinciaByIdRegionQuery() { IdRegion = idRegion });
            var lista = _mapper.Map<List<ProvinciaViewModel>>(entidadModel.Data);
            return Json(lista);

        }

        public async Task<JsonResult> GetCiudad(int idProvincia)
        {
            var entidadModel = await _mediator.Send(new GetCiudadByIdProvinciaQuery() { IdProvincia = idProvincia });
            var lista = _mapper.Map< List<CiudadViewModel>>(entidadModel.Data);
            return Json(lista);

        }
    }
}
