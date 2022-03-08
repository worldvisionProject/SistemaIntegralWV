using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Delete;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ProductoObjetivoController : BaseController<ProductoObjetivoController>
    {
        public async Task<IActionResult> Index(int idObjetivo)
        {
            var model = new ObjetivoEstrategicoViewModel();
            model.Id = idObjetivo;
            //return View(model);
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("Index", model) });
        }
        public async Task<IActionResult> LoadAll(int idObjetivo)
        {
            var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = idObjetivo });
            if (response.Succeeded)
            {
                var entidadViewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = entidadViewModel.IdEstrategia });
                if (responseE.Succeeded)
                {

                    var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                    entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                }
                // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel) });
                return PartialView("_ViewAll", entidadViewModel);
            }

            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idObjetivo = 0,int idEstrategia=0)
        {

            if (id == 0)
            {
                var entidadViewModel = new ProductoObjetivoViewModel();
                entidadViewModel.IdObjetivoEstra = idObjetivo;
                var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
                if (responseE.Succeeded)
                {

                    var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                    entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetProductoObjetivoByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<ProductoObjetivoViewModel>(response.Data); 
                    var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = idEstrategia });
                    if (responseE.Succeeded)
                    {

                        var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                        entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                    }

                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ProductoObjetivoViewModel productoObjetivo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateProductoObjetivoCommand>(productoObjetivo);

                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Producto Objetivo Creado.");
                            return new JsonResult(new { isValid = true, solocerrar = true });
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateProductoObjetivoCommand>(productoObjetivo);
                        updateEntidadCommand.Id = id;
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Producto Objetivo Actualizado.");
                    }

                    var response = await _mediator.Send(new GetObjetivoEstrategicoByIdQuery() { Id = productoObjetivo.IdObjetivoEstra });
                    if (response.Succeeded)
                    {
                        var entidadViewModel = _mapper.Map<ObjetivoEstrategicoViewModel>(response.Data);
                        var responseE = await _mediator.Send(new GetListGestionByIdQuery() { Id = entidadViewModel.IdEstrategia });
                        if (responseE.Succeeded)
                        {

                            var gestionViewModel = _mapper.Map<List<GestionViewModel>>(responseE.Data);
                            entidadViewModel.AnioFiscalList = new SelectList(gestionViewModel, "Id", "Anio");
                        }
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", entidadViewModel);
                        return new JsonResult(new { isValid = true, hijo = 2, opcion = 1, page = "#viewAllProductoObjetivo", html = html1 });
                
                    }


                }

                return new JsonResult(new { isValid = false });

            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar IndicadorEstrategico");
            }
            return null;
        }

        public async Task<JsonResult> OnPostDelete(int id = 0)
        {
            var deleteCommand = await _mediator.Send(new DeleteProductoObjetivoCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Producto con Id {id} Eliminado.");
                return new JsonResult(new { isValid = true });

            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }


    }
}
