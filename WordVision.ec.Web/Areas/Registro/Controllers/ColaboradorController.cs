using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{
    [Area("Registro")]
    [Authorize]
    public class ColaboradorController : BaseController<ColaboradorController>
    {
        public IActionResult Index()
        {
            var model = new ColaboradorViewModel();
            return View(model);

        }
        //[Route("Colaborador/Detalle")]
        public IActionResult Colaborador()
        {
            var model = new ColaboradorViewModel();
            return View(model);

        }

        public async Task<IActionResult> LoadColaborador(int id = 0)
        {
          
            var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                var documentoViewModel = _mapper.Map<ColaboradorViewModel>(response.Data);
                
                return PartialView("_ViewColaborador", documentoViewModel);
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            }
            return null;

        }
        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }


        //[Authorize(Policy = Permissions.Users.View)]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            // var colaboradoresResponse = await _mediator.Send(new GetAllColaboradoresCachedQuery());
            var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 6 });
            var CargoList = new SelectList(cat1.Data, "Secuencia", "Nombre");
            var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 7 });
            var DireccionList = new SelectList(cat2.Data, "Secuencia", "Nombre");
            var cat3 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 8 });
            var DepartamentoList = new SelectList(cat3.Data, "Secuencia", "Nombre");

            if (id == 0)
            {
                var colaboradorViewModel = new ColaboradorViewModel();
                colaboradorViewModel.CargoList = CargoList;
                colaboradorViewModel.AreaList = DepartamentoList;
                colaboradorViewModel.LugarTrabajoList = DireccionList;
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaboradorViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var colaboradorViewModel = _mapper.Map<ColaboradorViewModel>(response.Data);
                    if (colaboradorViewModel==null)
                    {
                        _notify.Information($"Colaborador con ID {id} no tiene datos para mostrar. Llene los datos.");
                        return new JsonResult(new { isValid = true, solocerrar = true });
                                           
                    }

                    var responseT = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                    if (responseT.Succeeded)
                    {
                        var formularioViewModel = _mapper.Map<FormularioViewModel>(responseT.Data);
                        if (formularioViewModel!=null)
                        colaboradorViewModel.FormularioTerceros = formularioViewModel.FormularioTerceros;
                        else
                        {
                             formularioViewModel = new FormularioViewModel();
                            colaboradorViewModel.FormularioTerceros = formularioViewModel.FormularioTerceros;
                        }
                    }

                    colaboradorViewModel.CargoList = CargoList;
                    colaboradorViewModel.AreaList = DepartamentoList;
                    colaboradorViewModel.LugarTrabajoList = DireccionList;
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaboradorViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ColaboradorViewModel colaborador)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (id == 0)
                    {
                        var createBrandCommand = _mapper.Map<CreateColaboradorCommand>(colaborador);
                        var result = await _mediator.Send(createBrandCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Colaborador con ID {result.Data} creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateBrandCommand = _mapper.Map<UpdateColaboradorCommand>(colaborador);
                        var result = await _mediator.Send(updateBrandCommand);
                        if (result.Succeeded) _notify.Information($"Colaborador con ID {result.Data} actualizado.");
                        else _notify.Error(result.Message);
                    }

                    //var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                    //if (response.Succeeded)
                    //{
                    //    var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                    //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    //    return new JsonResult(new { isValid = true, html = html });
                    //}
                    //else
                    //{
                    //    _notify.Error(response.Message);
                    //    return null;
                    //}

                    return new JsonResult(new { isValid = true,  solocerrar = true });
                }
                else
                {
                    var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaborador);
                    return new JsonResult(new { isValid = false, html = html });
                }
            }
            catch (Exception ex)
            {
                //_notify.Error($"Error en actualizar los datos del colabrador.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                _logger.LogError(ex,$"Error en actualizar los datos del colabrador.");
              
                return new JsonResult(new { isValid = false });
            }
            
        }
    }
}
