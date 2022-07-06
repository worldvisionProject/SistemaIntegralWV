using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Encuesta.EProvincias;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;
using WordVision.ec.Application.Features.Encuesta.ERegiones;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    //[Authorize]
    public class EProvinciaController : BaseController<EProvinciaController>
    {
        private readonly CommonMethods _commonMethods;

        public EProvinciaController()
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
            List<EProvinciaViewModel> viewModels = new List<EProvinciaViewModel>();

            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            //Traemos el listado de registro de la base de dartos
            var response = await _mediator.Send(new GetAllEProvinciasQuery { Include = true });

            //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
            if (response.Succeeded) viewModels = _mapper.Map<List<EProvinciaViewModel>>(response.Data);

            //Enviamos los datos a la vista
            return PartialView("_ViewAll", viewModels);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(string id = "")
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {

                var entidadViewModel = new EProvinciaViewModel();
                if (id == "")
                {
                    //Llenamos los atributos select con datos traidos de la base
                    //Ponemos en el SelectList para el combo
                    var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = false });
                    if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                    {
                        var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                        entidadViewModel.ERegionList = cmbRegiones;
                    }

                    entidadViewModel.OperacionEdicion = "I";
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEProvinciasByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EProvinciaViewModel>(response.Data);


                        //Llenamos los atributos select con datos traidos de la base
                        //Ponemos en el SelectList para el combo
                        var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = false });
                        if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                        {
                            var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                            entidadViewModel.ERegionList = cmbRegiones;
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EProvincia.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EProvinciaViewModel EProvinciaViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EProvinciaViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEProvinciaCommand>(EProvinciaViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEProvinciaCommand>(EProvinciaViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro actualizado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEProvinciasQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EProvinciaViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EProvincia", result);
            }
        }

        public async Task<JsonResult> OnPostDelete(string id = "")
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEProvinciaCommand { Id = id });
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
                _logger.LogError(ex, "OnPostDelete EProvincia");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }



    }
}
