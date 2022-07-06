using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;
using WordVision.ec.Application.Features.Encuesta.ECantones;
using WordVision.ec.Application.Features.Encuesta.ERegiones;
using WordVision.ec.Application.Features.Encuesta.EProvincias;
using WordVision.ec.Application.Features.Encuesta.EComunidades;
using WordVision.ec.Application.Features.Encuesta.EParroquias;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    //[Authorize]
    public class EComunidadController : BaseController<EComunidadController>
    {
        private readonly CommonMethods _commonMethods;

        public EComunidadController()
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
            List<EComunidadViewModel> viewModels = new List<EComunidadViewModel>();

            //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
            //Traemos el listado de registro de la base de dartos
            var response = await _mediator.Send(new GetAllEComunidadesQuery { Include = true });

            //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
            if (response.Succeeded) viewModels = _mapper.Map<List<EComunidadViewModel>>(response.Data);

            //Enviamos los datos a la vista
            return PartialView("_ViewAll", viewModels);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(string id = "")
        {
            //Consultamos los datos del registro para poner en el formulario
            try
            {

                var entidadViewModel = new EComunidadViewModel();
                if (id == "")
                {

                    var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = true });
                    if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                    {
                        var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                        entidadViewModel.ERegionList = cmbRegiones;
                    }

                    //Seleccionamos el primer elemento del listado como default para el siguiente combo
                    var defaultERegionId = respuestaERegiones.Data.ToList().Select(m => m.Id).FirstOrDefault();


                    var respuestaEProvincias = await _mediator.Send(new GetAllEProvinciasQuery { Include = true, ERegionId = defaultERegionId });
                    if (respuestaEProvincias.Succeeded && respuestaEProvincias.Data != null)
                    {
                        var cmbProvincias = new SelectList(respuestaEProvincias.Data.ToList(), "Id", "pro_nombre");
                        entidadViewModel.EProvinciaList = cmbProvincias;
                    }

                    //Seleccionamos el primer elemento del listado como default para el siguiente combo
                    var defaultEProvinciaId = respuestaEProvincias.Data.ToList().Select(m => m.Id).FirstOrDefault();

                    var respuestaECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = defaultEProvinciaId });
                    if (respuestaECantones.Succeeded && respuestaECantones.Data != null)
                    {
                        var cmbCantones = new SelectList(respuestaECantones.Data.ToList(), "Id", "can_nombre");
                        entidadViewModel.ECantonList = cmbCantones;
                    }

                    //Seleccionamos el primer elemento del listado como default para el siguiente combo
                    var defaultECantonId = respuestaECantones.Data.ToList().Select(m => m.Id).FirstOrDefault();

                    var respuestaEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = defaultECantonId });
                    if (respuestaEParroquias.Succeeded && respuestaEParroquias.Data != null)
                    {
                        var cmbParroquias = new SelectList(respuestaEParroquias.Data.ToList(), "Id", "par_nombre");
                        entidadViewModel.EParroquiaList = cmbParroquias;
                    }


                    entidadViewModel.OperacionEdicion = "I";
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    //Si estamos en modo Modificacion, consultamos los datos de la base y llenamos los ComboBox necesarios
                    var response = await _mediator.Send(new GetEComunidadesByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<EComunidadViewModel>(response.Data);

                        var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = true });
                        if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                        {
                            var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                            entidadViewModel.ERegionList = cmbRegiones;
                        }


                        var respuestaEProvincias = await _mediator.Send(new GetAllEProvinciasQuery { Include = true, ERegionId = entidadViewModel.ERegionId });
                        if (respuestaEProvincias.Succeeded && respuestaEProvincias.Data != null)
                        {
                            var cmbProvincias = new SelectList(respuestaEProvincias.Data.ToList(), "Id", "pro_nombre");
                            entidadViewModel.EProvinciaList = cmbProvincias;
                        }


                        var respuestaECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = entidadViewModel.EProvinciaId });
                        if (respuestaECantones.Succeeded && respuestaECantones.Data != null)
                        {
                            var cmbCantones = new SelectList(respuestaECantones.Data.ToList(), "Id", "can_nombre");
                            entidadViewModel.ECantonList = cmbCantones;
                        }

                        var respuestaEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = entidadViewModel.ECantonId });
                        if (respuestaEParroquias.Succeeded && respuestaEParroquias.Data != null)
                        {
                            var cmbParroquias = new SelectList(respuestaEParroquias.Data.ToList(), "Id", "par_nombre");
                            entidadViewModel.EParroquiaList = cmbParroquias;
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
                return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar EComunidad.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(EComunidadViewModel EComunidadViewModel)
        {
            //Actualizamos la base de datos con la infomracion proveniente del formulario
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (EComunidadViewModel.OperacionEdicion == "I")
                {
                    //Modo Insercion

                    var createEntidadCommand = _mapper.Map<CreateEComunidadCommand>(EComunidadViewModel);
                    //createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded) _notify.Success($"Registro creado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    //Modo Modificacion

                    var updateEntidadCommand = _mapper.Map<UpdateEComunidadCommand>(EComunidadViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Registro actualizado exitosamente.");
                    else return _commonMethods.SaveError(result.Message);
                }

                //Una vez que se haya ejecutado la accion en la base, consultamos los registros para enviar el nuevo listado
                //y llamamos a la vista parcial _ViewAll
                //Include: le dice a la consulta que traiga las tablas relacionadas en la consulta
                var response = await _mediator.Send(new GetAllEComunidadesQuery { Include = true });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<EComunidadViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                    return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar EComunidad", result);
            }
        }

        public async Task<JsonResult> OnPostDelete(string id = "")
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteEComunidadCommand { Id = id });
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
                _logger.LogError(ex, "OnPostDelete EComunidad");
                _notify.Error("Error al Eliminar el Registro.");
            }


            return new JsonResult(new { isValid = false });
        }

        [HttpGet]
        public async Task<JsonResult> setDropDrownList(string tipoCombo, string valor, string id)
        {
            EComunidadViewModel entidadViewModel = new EComunidadViewModel();

            if (id == null)
            {
                //Insertar

                var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = true });
                if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                {
                    var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                    entidadViewModel.ERegionList = cmbRegiones;
                }

                switch (tipoCombo)
                {
                    case "cmbRegion":
                        //Si cambio el combo Region, debemos referescar los combos hijos en cascada (Provincia)

                        var respuestaEProvincias = await _mediator.Send(new GetAllEProvinciasQuery { Include = true, ERegionId = Convert.ToInt32(valor) });
                        if (respuestaEProvincias.Succeeded && respuestaEProvincias.Data != null)
                        {
                            var cmbProvincias = new SelectList(respuestaEProvincias.Data.ToList(), "Id", "pro_nombre");
                            entidadViewModel.EProvinciaList = cmbProvincias;
                        }

                        //Seleccionamos el primer elemento del listado como default para el siguiente combo
                        var defaultEProvinciaId = respuestaEProvincias.Data.ToList().Select(m => m.Id).FirstOrDefault();

                        var respuestaECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = defaultEProvinciaId });
                        if (respuestaECantones.Succeeded && respuestaECantones.Data != null)
                        {
                            var cmbCantones = new SelectList(respuestaECantones.Data.ToList(), "Id", "can_nombre");
                            entidadViewModel.ECantonList = cmbCantones;
                        }

                        //Seleccionamos el primer elemento del listado como default para el siguiente combo
                        var defaultECantonId = respuestaECantones.Data.ToList().Select(m => m.Id).FirstOrDefault();

                        var respuestaEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = defaultECantonId });
                        if (respuestaEParroquias.Succeeded && respuestaEParroquias.Data != null)
                        {
                            var cmbParroquias = new SelectList(respuestaEParroquias.Data.ToList(), "Id", "par_nombre");
                            entidadViewModel.EParroquiaList = cmbParroquias;
                        }


                        break;
                    case "cmbProvincia":

                        var respuestECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = valor });
                        if (respuestECantones.Succeeded && respuestECantones.Data != null)
                        {
                            var cmbCantones = new SelectList(respuestECantones.Data.ToList(), "Id", "can_nombre");
                            entidadViewModel.ECantonList = cmbCantones;
                        }

                        //Seleccionamos el primer elemento del listado como default para el siguiente combo
                        var defaulECantonId = respuestECantones.Data.ToList().Select(m => m.Id).FirstOrDefault();

                        var respuestEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = defaulECantonId });
                        if (respuestEParroquias.Succeeded && respuestEParroquias.Data != null)
                        {
                            var cmbParroquias = new SelectList(respuestEParroquias.Data.ToList(), "Id", "par_nombre");
                            entidadViewModel.EParroquiaList = cmbParroquias;
                        }

                        break;
                    case "cmbCanton":

                        var respuesEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = valor });
                        if (respuesEParroquias.Succeeded && respuesEParroquias.Data != null)
                        {
                            var cmbParroquias = new SelectList(respuesEParroquias.Data.ToList(), "Id", "par_nombre");
                            entidadViewModel.EParroquiaList = cmbParroquias;
                        }

                        break;
                }

                entidadViewModel.OperacionEdicion = "I";

                return Json(entidadViewModel);

            }
            else
            {
                //Modificar
                var response = await _mediator.Send(new GetEComunidadesByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    entidadViewModel = _mapper.Map<EComunidadViewModel>(response.Data);

                    var respuestaERegiones = await _mediator.Send(new GetAllERegionesQuery { Include = true });
                    if (respuestaERegiones.Succeeded && respuestaERegiones.Data != null)
                    {
                        var cmbRegiones = new SelectList(respuestaERegiones.Data.ToList(), "Id", "reg_nombre");
                        entidadViewModel.ERegionList = cmbRegiones;
                    }

                    switch (tipoCombo)
                    {
                        case "cmbRegion":
                            //Si cambio el combo Region, debemos referescar los combos hijos en cascada (Provincia)

                            var respuestaEProvincias = await _mediator.Send(new GetAllEProvinciasQuery { Include = true, ERegionId = Convert.ToInt32(valor) });
                            if (respuestaEProvincias.Succeeded && respuestaEProvincias.Data != null)
                            {
                                var cmbProvincias = new SelectList(respuestaEProvincias.Data.ToList(), "Id", "pro_nombre");
                                entidadViewModel.EProvinciaList = cmbProvincias;
                            }

                            //Seleccionamos el primer elemento del listado como default para el siguiente combo
                            var defaultEProvinciaId = respuestaEProvincias.Data.ToList().Select(m => m.Id).FirstOrDefault();

                            var respuestaECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = defaultEProvinciaId });
                            if (respuestaECantones.Succeeded && respuestaECantones.Data != null)
                            {
                                var cmbCantones = new SelectList(respuestaECantones.Data.ToList(), "Id", "can_nombre");
                                entidadViewModel.ECantonList = cmbCantones;
                            }

                            //Seleccionamos el primer elemento del listado como default para el siguiente combo
                            var defaulECantonId = respuestaECantones.Data.ToList().Select(m => m.Id).FirstOrDefault();

                            var respuestEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = defaulECantonId });
                            if (respuestEParroquias.Succeeded && respuestEParroquias.Data != null)
                            {
                                var cmbParroquias = new SelectList(respuestEParroquias.Data.ToList(), "Id", "par_nombre");
                                entidadViewModel.EParroquiaList = cmbParroquias;
                            }


                            break;
                        case "cmbProvincia":
                            var respuestECantones = await _mediator.Send(new GetAllECantonesQuery { Include = true, EProvinciaId = valor });
                            if (respuestECantones.Succeeded && respuestECantones.Data != null)
                            {
                                var cmbCantones = new SelectList(respuestECantones.Data.ToList(), "Id", "can_nombre");
                                entidadViewModel.ECantonList = cmbCantones;
                            }

                            //Seleccionamos el primer elemento del listado como default para el siguiente combo
                            var defaultECantonId = respuestECantones.Data.ToList().Select(m => m.Id).FirstOrDefault();

                            var respuestaEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = defaultECantonId });
                            if (respuestaEParroquias.Succeeded && respuestaEParroquias.Data != null)
                            {
                                var cmbParroquias = new SelectList(respuestaEParroquias.Data.ToList(), "Id", "par_nombre");
                                entidadViewModel.EParroquiaList = cmbParroquias;
                            }


                            break;

                        case "cmbCanton":

                            var respuesEParroquias = await _mediator.Send(new GetAllEParroquiasQuery { Include = true, ECantonId = valor });
                            if (respuesEParroquias.Succeeded && respuesEParroquias.Data != null)
                            {
                                var cmbParroquias = new SelectList(respuesEParroquias.Data.ToList(), "Id", "par_nombre");
                                entidadViewModel.EParroquiaList = cmbParroquias;
                            }

                            break;


                    }

                    entidadViewModel.OperacionEdicion = "M";
                    return Json(entidadViewModel);
                }
                return new JsonResult(new
                {
                    isValid = false
                });



            }


        }





    }
}
