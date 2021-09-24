using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Controllers
{
    [Area("Soporte")]
    [Authorize]//Sirve para dar permiso cuando esta logeado
    public class DonanteController : BaseController<DonanteController>
    {
        // ejecuta una accion
        public IActionResult Index()
        {
            return View();// dirije a la carpeta Views
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllDonantesQuery());
            if (response.Succeeded)
            {

                var viewModel = _mapper.Map<List<DonanteViewModel>>(response.Data);


                return PartialView("_ViewAll", viewModel);
            }

            return null;

        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
           
            

            if (id == 0)
            {
                var entidadViewModel = new DonanteViewModel();
                
               
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetDonantesByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var entidadViewModel = _mapper.Map<DonanteViewModel>(response.Data);
                   
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, DonanteViewModel entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        var createEntidadCommand = _mapper.Map<CreateDonanteCommand>(entidad);
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Donante con ID {result.Data} Creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateEntidadCommand = _mapper.Map<UpdateDonanteCommand>(entidad);
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"Donate con ID {result.Data} Actualizado.");
                    }

                    var response = await _mediator.Send(new GetAllDonantesQuery());
                    if (response.Succeeded)
                    {

                        var viewModel = _mapper.Map<List<DonanteViewModel>>(response.Data);
                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                        return new JsonResult(new { isValid = true, html = html1 });


                    }


                }
                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el Donante");
            }
            return null;
        }



    }
}

