using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Encuesta.ETabulados;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    // [Authorize]  //Para aplicar política de autorizaciones
    public class ETabuladoController : BaseController<ETabuladoController>
    {
        public async Task<IActionResult> Index(int evaluacionID, int regionID, string provinciaID, string cantonID, string parroquiaID, string comunidadID, string programaID, string indicadorID)
        {
            if (provinciaID == null) provinciaID = "";
            if (cantonID == null) cantonID = "";
            if (parroquiaID == null) parroquiaID = "";
            if (comunidadID == null) comunidadID = "";
            if (programaID == null) programaID = "";
            if (indicadorID == null) indicadorID = "";

            //Ejecuta el Select que trae todos los registros de la base
            var response = await _mediator.Send(new GetAllETabuladosQuery() { EvaluacionId=evaluacionID, RegionId=regionID, ProvinciaId=provinciaID, CantonId=cantonID, ParroquiaId=parroquiaID, ComunidadId=comunidadID, ProgramaId=programaID, IndicadorId=indicadorID});
            if (response.Succeeded && response.Data != null)
            {
                //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                var viewModel = _mapper.Map<List<ETabuladoViewModel>>(response.Data);

                //return PartialView("_ViewAll", viewModel);
                return View(viewModel);
            }

            return View(new ETabuladoViewModel());
        }



    }
}
