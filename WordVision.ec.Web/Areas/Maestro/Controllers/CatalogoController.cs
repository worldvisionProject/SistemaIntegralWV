using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Create;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Update;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    public class CatalogoController : BaseController<CatalogoController>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CatalogoController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var model = new CatalogoViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll(string idRol = "")
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name.ToUpper());
            IList<string> userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);


            List<CatalogoViewModel> viewModel = new List<CatalogoViewModel>();
            for (int i = 0; i <= userRoles.Count - 1; i++)
            {
                idRol = userRoles[i].ToUpper();
                if (userRoles[i].ToUpper().Contains("SUPERADMIN") || userRoles[i].ToUpper().Contains("ADMIN"))
                {
                    idRol = "";
                    i = userRoles.Count;
                }
                var response = await _mediator.Send(new GetAllCatalogosCachedQuery() { IdRol = idRol });
                if (response.Succeeded)
                {
                    if (response.Data != null)
                    {
                        if (response.Data.Count > 0)
                        {
                            var uno = _mapper.Map<List<CatalogoViewModel>>(response.Data);
                            viewModel.AddRange(uno);


                        }

                    }

                }
            }

            //var viewModelR = _mapper.Map<List<CatalogoViewModel>>(viewModel);

            return PartialView("_ViewAll", viewModel);

        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());
            try
            {
                if (id == 0)
                {
                    var entidadViewModel = new CatalogoViewModel();
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetCatalogoByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        var entidadViewModel = _mapper.Map<CatalogoViewModel>(response.Data);
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
                _logger.LogError("OnGetCreateOrEdit", ex);
                _notify.Error("Error al consultar el Catalogo");
                return new JsonResult(new
                {
                    isValid = false
                });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, CatalogoViewModel entidad)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateCatalogoCommand>(entidad);
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Catalogo con ID {result.Data} Creado.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateCatalogoCommand>(entidad);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"Catalogo con ID {result.Data} Actualizado.");
                }
                var response = await _mediator.Send(new GetAllCatalogosCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CatalogoViewModel>>(response.Data);
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
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidad);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        //[HttpPost]
        //public async Task<JsonResult> OnPostDelete(int id)
        //{
        //    var deleteCommand = await _mediator.Send(new DeleteBrandCommand { Id = id });
        //    if (deleteCommand.Succeeded)
        //    {
        //        _notify.Information($"Brand with Id {id} Deleted.");
        //        var response = await _mediator.Send(new GetAllBrandsCachedQuery());
        //        if (response.Succeeded)
        //        {
        //            var viewModel = _mapper.Map<List<BrandViewModel>>(response.Data);
        //            var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
        //            return new JsonResult(new { isValid = true, html = html });
        //        }
        //        else
        //        {
        //            _notify.Error(response.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        _notify.Error(deleteCommand.Message);
        //        return null;
        //    }
        //}
    }

}
