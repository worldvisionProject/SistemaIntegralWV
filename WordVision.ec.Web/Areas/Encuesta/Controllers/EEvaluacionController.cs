using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    //[Authorize]
    public class EEvaluacionController : BaseController<EEvaluacionController>
    {
        private readonly CommonMethods _commonMethods;

        public EEvaluacionController()
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
            List<EEvaluacionViewModel> viewModels = new List<EEvaluacionViewModel>();
            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            var response = await _mediator.Send(new GetAllEEvaluacionesQuery { Include = true });
            if (response.Succeeded)
                viewModels = _mapper.Map<List<EEvaluacionViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {
                var entidadViewModel = new EEvaluacionViewModel();
                if (id == 0)
                {
                    entidadViewModel.OperacionEdicion = "I";

                    //Si estamos en modo Insercion, llenamos los ComboBox necesarios 
                    //await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    

                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEEvaluacionesByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EEvaluacionViewModel>(response.Data);
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EEvaluacion.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EEvaluacionViewModel EEvaluacionViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EEvaluacionViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEEvaluacionCommand>(EEvaluacionViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEEvaluacionCommand>(EEvaluacionViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro con ID {result.Data} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEEvaluacionesQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EEvaluacionViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EEvaluacion", result);
            }
        }

        private async Task SetDropDownList(EEvaluacionViewModel entidadViewModel)
        {
            //Para Poblar un comboBox con datos en el modelView,
            //Si hay mas de un combBoc que llenar con datos, se deben crear mas funciones como ésta.

            //bool isNew = true;
            //if (entidadViewModel.Id != 0) isNew = false;
            //var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });

            //List<GetListByIdDetalleResponse> estados = estado.Data;
            //if (isNew)  estados = estados.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();

            //entidadViewModel.EstadoList = _commonMethods.SetGenericCatalog(estados, CatalogoConstant.FieldEstado);
        }

        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEEvaluacionCommand { Id = id });
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
                _logger.LogError(ex, "OnPostDelete EEvaluacion");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }

    }
}
