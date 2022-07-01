using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Create;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Update;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetById;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    [Area("Maestro")]
    [Authorize]
    public class RCNinoPatrocinadoController : BaseController<RCNinoPatrocinadoController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CommonMethods _commonMethods;

        public RCNinoPatrocinadoController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _commonMethods = new CommonMethods();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadAll()
        {
            List<RcNinoPatrocinadoViewModel> viewModels = new List<RcNinoPatrocinadoViewModel>();
            var response = await _mediator.Send(new GetAllRCNinoPatrocinadoQuery { Include = true});
            if (response.Succeeded)
                viewModels = _mapper.Map<List<RcNinoPatrocinadoViewModel>>(response.Data);

            return PartialView("_ViewAll", viewModels);
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            try
            {               
                var entidadViewModel = new RcNinoPatrocinadoViewModel();
                if (id == 0)
                {
                    await SetDropDownList(entidadViewModel);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                else
                {
                    var response = await _mediator.Send(new GetRCNinoPatrocinadoByIdQuery() { Id = id});
                    if (response.Succeeded)
                    {
                        entidadViewModel = _mapper.Map<RcNinoPatrocinadoViewModel>(response.Data);
                        await SetDropDownList(entidadViewModel);
                        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                    }
                    return new JsonResult(new{isValid = false});
                }
            }
            catch (Exception ex)
            {
               return _commonMethods.SaveError($"OnGetCreateOrEdit Error al consultar RC Niño Patrocinado.", ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(RcNinoPatrocinadoViewModel rcNinoPatrocinadoViewModel)
        {
            _commonMethods.SetProperties(_notify, _logger);
            if (ModelState.IsValid)
            {
                if (rcNinoPatrocinadoViewModel.Id == 0)
                {
                    var createEntidadCommand = _mapper.Map<CreateRCNinoPatrocinadoCommand>(rcNinoPatrocinadoViewModel);
                    createEntidadCommand.IdEstado = CatalogoConstant.IdDetalleCatalogoEstadoActivo;
                    var result = await _mediator.Send(createEntidadCommand);
                    if (result.Succeeded)
                        _notify.Success($"RC Niño Patrocinado con Código {createEntidadCommand.Codigo} Creado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                else
                {
                    var updateEntidadCommand = _mapper.Map<UpdateRCNinoPatrocinadoCommand>(rcNinoPatrocinadoViewModel);
                    var result = await _mediator.Send(updateEntidadCommand);
                    if (result.Succeeded) _notify.Information($"RC Niño Patrocinado con Código {updateEntidadCommand.Codigo} Actualizado.");
                    else return _commonMethods.SaveError(result.Message);
                }
                var response = await _mediator.Send(new GetAllRCNinoPatrocinadoQuery { Include = true});
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<RcNinoPatrocinadoViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                   return _commonMethods.SaveError(response.Message);
            }
            else
            {
                var result = string.Join(',', ModelState.Values.SelectMany(v => v.Errors).Select(a => a.ErrorMessage));
                return _commonMethods.SaveError($"Error al insertar Rc Niño Patrocinado.", result);

            }
        }

        private async Task SetDropDownList(RcNinoPatrocinadoViewModel entidadViewModel)
        {
            bool isNew = true;
            if (entidadViewModel.Id != 0)
                isNew = false;
            var estado = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoEstado });           
            var genero = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoGenero });
            var grupoEtario = await _mediator.Send(new GetListByIdDetalleQuery() { Id = CatalogoConstant.IdCatalogoGrupoEtario });
            var programaAreas = await _mediator.Send(new GetAllProgramaAreaQuery());

            List<GetListByIdDetalleResponse> estados = estado.Data;
            List<GetListByIdDetalleResponse> generos = genero.Data;
            List<GetListByIdDetalleResponse> etarios = grupoEtario.Data;
            List<ProgramaAreaViewModel> programas = _mapper.Map<List<ProgramaAreaViewModel>>(programaAreas.Data);
            if (isNew)
            {
                estados = estados.Where(e=> e.Estado == CatalogoConstant.EstadoActivo).ToList();
                generos = generos.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                etarios = etarios.Where(e => e.Estado == CatalogoConstant.EstadoActivo).ToList();
                programas = programas.Where(e => e.IdEstado == CatalogoConstant.IdDetalleCatalogoEstadoActivo).ToList();
            }

            entidadViewModel.EstadoList = _commonMethods.SetGenericCatalogWithoutIdLabel(estados, CatalogoConstant.FieldEstado);
            entidadViewModel.GeneroList = _commonMethods.SetGenericCatalogWithoutIdLabel(generos, CatalogoConstant.FieldGenero);
            entidadViewModel.GrupoEtarioList = _commonMethods.SetGenericCatalogWithoutIdLabel(etarios, CatalogoConstant.FieldGrupoEtario);
            entidadViewModel.ProgramaAreaList = _commonMethods.SetGenericCatalog(programas, CatalogoConstant.FieldProgramaArea);
        }
    }
}
