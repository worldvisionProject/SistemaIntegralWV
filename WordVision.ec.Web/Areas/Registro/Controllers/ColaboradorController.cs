using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
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

            if (id == 0)
            {
                var colaboradorViewModel = new ColaboradorViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaboradorViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var colaboradorViewModel = _mapper.Map<ColaboradorViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaboradorViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ColaboradorViewModel colaborador)
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
                
                var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaborador);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }
}
