using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Application.Features.Encuesta.EIndicadores;
using WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Application.Features.Encuesta.EProgramas;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    //[Authorize]
    public class EProgramaIndicadorController : BaseController<EProgramaIndicadorController>
    {
        private readonly CommonMethods _commonMethods;

        public EProgramaIndicadorController()
        {
            _commonMethods = new CommonMethods();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadAll()
        {
            List<EProgramaIndicadorViewModel> viewModels = new List<EProgramaIndicadorViewModel>();

            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            //Traemos el listado de registro de la base de dartos
            var response = await _mediator.Send(new GetAllEProgramaIndicadoresQuery { Include = true });

            //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
            if (response.Succeeded) viewModels = _mapper.Map<List<EProgramaIndicadorViewModel>>(response.Data);

            //Enviamos los datos a la vista
            return PartialView("_ViewAll", viewModels);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {

                var entidadViewModel = new EProgramaIndicadorViewModel();
                if (id == 0)
                {
                    //Llenamos los atributos select con datos traidos de la base
                    //Ponemos en el SelectList para el combo
                    var respuestaEIndicadores = await _mediator.Send(new GetAllEIndicadoresQuery { Include = false });
                    if (respuestaEIndicadores.Succeeded && respuestaEIndicadores.Data != null)
                    {
                        var cmbIndicadores = new SelectList(respuestaEIndicadores.Data.ToList(), "Id", "NombreCompleto");
                        entidadViewModel.EIndicadorList = cmbIndicadores;
                    }

                    var respuestaEProgramas = await _mediator.Send(new GetAllEProgramasQuery { Include = false });
                    if (respuestaEProgramas.Succeeded && respuestaEProgramas.Data != null)
                    {
                        var cmbProgramas = new SelectList(respuestaEProgramas.Data.ToList(), "Id", "NombreCompleto");
                        entidadViewModel.EProgramaList = cmbProgramas;
                    }


                    entidadViewModel.OperacionEdicion = "I";
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEProgramaIndicadoresByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EProgramaIndicadorViewModel>(response.Data);


                        //Llenamos los atributos select con datos traidos de la base
                        //Ponemos en el SelectList para el combo

                        var respuestaEIndicadores = await _mediator.Send(new GetAllEIndicadoresQuery { Include = false });
                        if (respuestaEIndicadores.Succeeded && respuestaEIndicadores.Data != null)
                        {
                            var cmbIndicadores = new SelectList(respuestaEIndicadores.Data.ToList(), "Id", "NombreCompleto");
                            entidadViewModel.EIndicadorList = cmbIndicadores;
                        }

                        var respuestaEProgramas = await _mediator.Send(new GetAllEProgramasQuery { Include = false });
                        if (respuestaEProgramas.Succeeded && respuestaEProgramas.Data != null)
                        {
                            var cmbProgramas = new SelectList(respuestaEProgramas.Data.ToList(), "Id", "NombreCompleto");
                            entidadViewModel.EProgramaList = cmbProgramas;
                        }


                        entidadViewModel.OperacionEdicion = "M";
                        //await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new
                    {
                        isValid = false
                    });
                }
            }
            catch (Exception ex)
            {
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EProgramaIndicador.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EProgramaIndicadorViewModel EProgramaIndicadorViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EProgramaIndicadorViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEProgramaIndicadorCommand>(EProgramaIndicadorViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEProgramaIndicadorCommand>(EProgramaIndicadorViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro actualizado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEProgramaIndicadoresQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EProgramaIndicadorViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EProgramaIndicador", result);
            }
        }

        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEProgramaIndicadorCommand { Id = id });
                if (deleteCommand.Succeeded)
                {
                    _notify.Information($"Registro con Id {id} Eliminado.");
                }
                else
                {
                    _notify.Error(deleteCommand.Message);
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnPostDelete EProgramaIndicador");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }



    }
}
