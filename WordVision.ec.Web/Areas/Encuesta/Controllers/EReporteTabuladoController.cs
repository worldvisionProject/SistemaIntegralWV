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
using WordVision.ec.Application.Features.Encuesta.EReporteTabulados;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    // [Authorize]  //Para aplicar política de autorizaciones
    public class EReporteTabuladoController : BaseController<EReporteTabuladoController>
    {
        public async Task<IActionResult> Index(int evaluacionID, int regionID, string provinciaID, string cantonID, string programaID, string indicadorID)
        {
            if (provinciaID == null) provinciaID = "";
            if (cantonID == null) cantonID = "";
            if (programaID == null) programaID = "";
            if (indicadorID == null) indicadorID = "";

            ViewData["EvaluacionFilter"] = evaluacionID;

            //Traemos las evaluaciones de la base de datos y lo ponemos en el SelectList para el combo
            //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
            var respuestaEEvaluaciones = await _mediator.Send(new GetAllEEvaluacionesQuery());
            if (respuestaEEvaluaciones.Succeeded && respuestaEEvaluaciones.Data != null)
            {
                var fromDatabaseEF = new SelectList(respuestaEEvaluaciones.Data.ToList(), "Id", "NombreCompleto");
                ViewData["EEvaluacionesList"] = fromDatabaseEF;

                //Ejecuta la consulta que trae todos los registros de la base
                var response = await _mediator.Send(new GetAllEReporteTabuladosQuery() { EvaluacionId = evaluacionID, RegionId = regionID, ProvinciaId = provinciaID, CantonId = cantonID, ProgramaId = programaID, IndicadorId = indicadorID });
                if (response.Succeeded && response.Data != null)
                {
                    //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                    var viewModel = _mapper.Map<List<EReporteTabuladoViewModel>>(response.Data);

                    //return PartialView("_ViewAll", viewModel);
                    return View(viewModel);
                }
            }

            return View(new EReporteTabuladoViewModel());
        }


    }
}
