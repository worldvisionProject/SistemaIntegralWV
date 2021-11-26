using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Delete;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Update;
using WordVision.ec.Application.Features.Registro.Idiomas.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Controllers
{
    [Area("Registro")]
    [Authorize]
    public class IdiomaController : BaseController<IdiomaController>
    {
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idFormulario = 0)
        {
            var response = await _mediator.Send(new GetIdiomaByIdQuery() { Id = id });
            if (response.Succeeded)
            {
                var idiomaViewModel = new IdiomaViewModel();
                idiomaViewModel.IdFormulario = idFormulario;
                if (response.Data != null)
                    idiomaViewModel = _mapper.Map<IdiomaViewModel>(response.Data);

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", idiomaViewModel) });
            }
            return null;

        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, IdiomaViewModel idioma)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createIdiomaCommand = _mapper.Map<CreateIdiomaCommand>(idioma);
                    var result = await _mediator.Send(createIdiomaCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Idioma con ID {result.Data} Creado.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateBrandCommand = _mapper.Map<UpdateIdiomaCommand>(idioma);
                    var result = await _mediator.Send(updateBrandCommand);
                    if (result.Succeeded) _notify.Information($"Idioma con ID  {result.Data} Actualizado.");
                }
                //var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<FormularioViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("Formulario/_ViewAll", viewModel);
                //    return new JsonResult(new { isValid = true, html = html });
                //}
                //else
                //{
                //    _notify.Error(response.Message);
                //    return null;
                //}
            }
            else
            {
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", tercero);
                _notify.Error("No se pudo insertar el Idioma.");
                return new JsonResult(new { isValid = false });
            }

            return new JsonResult(new { isValid = true });
        }


        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteIdiomaCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Idioma con Id {id} Eliminado.");

            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
            return new JsonResult(new { isValid = true });
        }

    }
}
