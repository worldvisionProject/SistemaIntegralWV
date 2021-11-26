using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Update;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Queries.GetAllCached;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Controllers
{
    [Area("Presupuesto")]
    [Authorize]
    public class PresupuestoController : BaseController<DatosLDRController>
    {
        public IActionResult Index(int id)
        {
            var model = new PresupuestoViewModel();
            model.Id = id;
            return View(model);

        }

        public async Task<IActionResult> LoadPresupuesto(int id = 0)
        {
            try
            {
                var response = await _mediator.Send(new GetAllPresupuestosCachedQuery());
                if (response.Succeeded)
                {
                    //DatosLDRViewModel r = new DatosLDRViewModel();
                    //foreach (var l in response.Data)
                    //{
                    //    r.Identificacion=
                    //}

                    var viewModel = _mapper.Map<List<PresupuestoViewModel>>(response.Data);
                    return PartialView("_ViewAll", viewModel);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { isValid = false });
            }
            return null;
        }

        public IActionResult Presupuesto()
        {
            var model = new AsignarViewModel();
            return View(model);

        }
        public async Task<IActionResult> LoadAsignar()
        {
            var response = await _mediator.Send(new GetAllDatosLDRsCachedQuery());
            if (response.Succeeded)
            {
                var models = new AsignarViewModel();

                var viewModel = _mapper.Map<List<DatosLDRViewModel>>(response.Data);
                models.LDRs = viewModel;

                var responseT5 = await _mediator.Send(new GetAllDatosT5sCachedQuery());
                var viewModelT5 = _mapper.Map<List<DatosT5ViewModel>>(responseT5.Data);

                models.T5Combo = viewModelT5;

                return PartialView("_Asignar", models);
            }
            return null;

        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(AsignarViewModel model)
        {
            if (ModelState.IsValid)
            {
                int con = 0;
                if (model.Tipo != "T")
                {
                    foreach (var c in model.LDRs)
                    {
                        if (c.select)
                        {
                            con++;
                        }
                    }
                }
                else
                    con = 170;


                PresupuestoViewModel p = new PresupuestoViewModel();
                p.T5 = model.IdT5;
                p.Precio = model.ValUnitario;
                p.Cantidad = con;
                p.Total = p.Precio * p.Cantidad;
                p.Mes = model.MesAnual;
                p.TodoAnio = model.MesAnual;
                p.Tipo = model.Tipo == "T" ? "Nacional" : model.Tipo == "A" ? model.Area : "Usuario";


                //if (id == 0)
                //{
                var createBrandCommand = _mapper.Map<CreatePresupuestoCommand>(p);
                var result = await _mediator.Send(createBrandCommand);
                if (result.Succeeded)
                {

                    _notify.Success($"Presupuesto con ID {result.Data} creado.");

                    foreach (var c in model.LDRs)
                    {
                        DatosLDRViewModel ldr = new DatosLDRViewModel();
                        ldr.Id = c.Id;
                        ldr.TotalGasto = p.Total;
                        ldr.PorceImputado = c.Ldr / 17000;
                        ldr.ValorImputado = ldr.PorceImputado * p.Total;

                        var updateCommand = _mapper.Map<UpdateDatosLDRCommand>(ldr);
                        var resultPresu = await _mediator.Send(updateCommand);
                        if (resultPresu.Succeeded)
                        {

                            //_notify.Success($"Detalle con ID {result.Data} actualizado.");
                        }
                        else _notify.Error(result.Message);
                    }
                }
                else _notify.Error(result.Message);
                //}
                //else
                //{
                //    var updateBrandCommand = _mapper.Map<UpdateColaboradorCommand>(colaborador);
                //    var result = await _mediator.Send(updateBrandCommand);
                //    if (result.Succeeded) _notify.Information($"Colaborador con ID {result.Data} actualizado.");
                //    else _notify.Error(result.Message);
                //}

                //var response = await _mediator.Send(new GetAllColaboradoresCachedQuery());
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<ColaboradorViewModel>>(response.Data);
                //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                return new JsonResult(new { isValid = true });
                //}
                //else
                //{
                //    _notify.Error(response.Message);
                //    return null;
                //}
            }
            else
            {
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", colaborador);
                return new JsonResult(new { isValid = false });
            }
        }
    }
}
