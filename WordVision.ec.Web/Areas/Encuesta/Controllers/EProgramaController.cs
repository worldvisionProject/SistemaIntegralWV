using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EProgramaController : BaseController<EProgramaController>
    {
        private readonly CommonMethods _commonMethods;

        public EProgramaController()
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
            List<EProgramaViewModel> viewModels = new List<EProgramaViewModel>();

            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            //Traemos el listado de registro de la base de dartos
            var response = await _mediator.Send(new GetAllEProgramasQuery { Include = true });

            //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
            if (response.Succeeded) viewModels = _mapper.Map<List<EProgramaViewModel>>(response.Data);

            //Enviamos los datos a la vista
            return PartialView("_ViewAll", viewModels);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(string id = "")
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {

                var entidadViewModel = new EProgramaViewModel();
                if (id == "")
                {
                    entidadViewModel.OperacionEdicion = "I";
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEProgramasByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EProgramaViewModel>(response.Data);
                        entidadViewModel.OperacionEdicion = "M";
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EPrograma.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EProgramaViewModel eProgramaViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (eProgramaViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEProgramaCommand>(eProgramaViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEProgramaCommand>(eProgramaViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro actualizado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEProgramasQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EProgramaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EPrograma", result);
            }
        }

        public async Task<JsonResult> OnPostDelete(string id = "")
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEProgramaCommand { Id = id });
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
                _logger.LogError(ex, "OnPostDelete EPrograma");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }



    }
}
