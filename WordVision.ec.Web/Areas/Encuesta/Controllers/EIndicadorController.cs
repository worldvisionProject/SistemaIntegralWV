using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Encuesta.EIndicadores;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    //[Authorize]
    public class EIndicadorController : BaseController<EIndicadorController>
    {
        private readonly CommonMethods _commonMethods;

        public EIndicadorController()
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
            List<EIndicadorViewModel> viewModels = new List<EIndicadorViewModel>();
            
            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            //Traemos el listado de registro de la base de dartos
            var response = await _mediator.Send(new GetAllEIndicadoresQuery { Include = true  });
            
            //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
            if (response.Succeeded) viewModels = _mapper.Map<List<EIndicadorViewModel>>(response.Data);
            
            //Enviamos los datos a la vista
            return PartialView("_ViewAll", viewModels);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(string id = "")
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {

                var entidadViewModel = new EIndicadorViewModel();
                if (id == "")
                {
                    //Llenamos los atributos select con datos traidos de la base
                    //Ponemos en el SelectList para el combo
                    var respuestaEObjetivos = await _mediator.Send(new GetAllEObjetivosQuery { Include = false });
                    if (respuestaEObjetivos.Succeeded && respuestaEObjetivos.Data != null)
                    {
                        var cmbObjetivos = new SelectList(respuestaEObjetivos.Data.ToList(), "Id", "NombreCompleto");
                        entidadViewModel.ObjetivoList = cmbObjetivos;
                    }


                    //---- Combo con llenado manual -------
                    List<SelectListItem> itemsFrencuencia = new()
                    {
                      new SelectListItem{Value = "1", Text = "Mensual"},
                      new SelectListItem{Value = "2", Text = "Bimensual"},
                      new SelectListItem{Value = "3", Text = "Trimestral"},
                      new SelectListItem{Value = "4", Text = "Cuatrimestral"},
                      new SelectListItem{Value = "6", Text = "Semestral"},
                      new SelectListItem{Value = "12", Text = "Anual"}
                    };
                    var cmbFrecuencia = new SelectList(itemsFrencuencia, "Value", "Text");
                    entidadViewModel.ind_FrecuenciaList = cmbFrecuencia;


                    //---- Combo con llenado manual -------
                    List<SelectListItem> itemsTipo = new()
                    {
                      new SelectListItem{Value = "Porcentaje", Text = "Porcentaje"},
                      new SelectListItem{Value = "Proporción", Text = "Proporción"},
                      new SelectListItem{Value = "Cobertura", Text = "Cobertura"},
                      new SelectListItem{Value = "Puntaje", Text = "Puntaje"}
                    };
                    var cmbTipo = new SelectList(itemsTipo, "Value", "Text");
                    entidadViewModel.ind_tipoList = cmbTipo;



                    //---- Combo con llenado manual -------
                    List<SelectListItem> itemsOperacion = new()
                    {
                      new SelectListItem{Value = "S", Text = "Sumar"},
                      new SelectListItem{Value = "P", Text = "Promedio"},
                      new SelectListItem{Value = "U", Text = "Último Periodo"},
                    };
                    var cmbOperacion = new SelectList(itemsOperacion, "Value", "Text");
                    entidadViewModel.ind_OperacionList = cmbOperacion;




                    entidadViewModel.OperacionEdicion = "I";
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEIndicadoresByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EIndicadorViewModel>(response.Data);


                        //Llenamos los atributos select con datos traidos de la base
                        //Ponemos en el SelectList para el combo
                        var respuestaEObjetivos = await _mediator.Send(new GetAllEObjetivosQuery { Include = false });
                        if (respuestaEObjetivos.Succeeded && respuestaEObjetivos.Data != null)
                        {
                            var cmbObjetivos = new SelectList(respuestaEObjetivos.Data.ToList(), "Id", "NombreCompleto");
                            entidadViewModel.ObjetivoList = cmbObjetivos;
                        }


                        //---- Combo con llenado manual -------
                        List<SelectListItem> itemsFrencuencia = new()
                        {
                          new SelectListItem{Value = "1", Text = "Mensual"},
                          new SelectListItem{Value = "2", Text = "Bimensual"},
                          new SelectListItem{Value = "3", Text = "Trimestral"},
                          new SelectListItem{Value = "4", Text = "Cuatrimestral"},
                          new SelectListItem{Value = "6", Text = "Semestral"},
                          new SelectListItem{Value = "12", Text = "Anual"}
                        };
                        var cmbFrecuencia = new SelectList(itemsFrencuencia, "Value", "Text");
                        entidadViewModel.ind_FrecuenciaList = cmbFrecuencia;


                        //---- Combo con llenado manual -------
                        List<SelectListItem> itemsTipo = new()
                        {
                          new SelectListItem{Value = "Porcentaje", Text = "Porcentaje"},
                          new SelectListItem{Value = "Proporción", Text = "Proporción"},
                          new SelectListItem{Value = "Cobertura", Text = "Cobertura"},
                          new SelectListItem{Value = "Puntaje", Text = "Puntaje"}
                        };
                        var cmbTipo = new SelectList(itemsTipo, "Value", "Text");
                        entidadViewModel.ind_tipoList = cmbTipo;



                        //---- Combo con llenado manual -------
                        List<SelectListItem> itemsOperacion = new()
                        {
                      new SelectListItem{Value = "S", Text = "Sumar"},
                      new SelectListItem{Value = "P", Text = "Promedio"},
                      new SelectListItem{Value = "U", Text = "Último Periodo"},
                        };
                        var cmbOperacion = new SelectList(itemsOperacion, "Value", "Text");
                        entidadViewModel.ind_OperacionList = cmbOperacion;


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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EIndicador.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EIndicadorViewModel EIndicadorViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EIndicadorViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEIndicadorCommand>(EIndicadorViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEIndicadorCommand>(EIndicadorViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro actualizado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEIndicadoresQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EIndicadorViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EIndicador", result);
            }
        }

        public async Task<JsonResult> OnPostDelete(string id = "")
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEIndicadorCommand { Id = id });
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
                _logger.LogError(ex, "OnPostDelete EIndicador");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }



    }
}
