using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class PerfilController : BaseController<PerfilController>
    {
        public IActionResult Index()
        {
            var model = new PerfilDesempenioViewModel();

            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            //var response = await _mediator.Send(new GetAllIndicadorEstrategicoesCachedQuery());
            //if (response.Succeeded)
            //{

            //  var viewModel = _mapper.Map<List<IndicadorEstrategicoViewModel>>(response.Data);
            var modelista = new List<PerfilDesempenioViewModel>();
            var model = new PerfilDesempenioViewModel();
            model.ResponsabilidadCargo = "Coordina la adopción de iniciativas globales , asegurando su correcto funcionamiento a nivel local.";
            model.Indicador = "100% de Aplicaciones de iniciativas del Centro Global implementadas acorde a los cronogramas establecidos por LACRO o GC.";
            model.MetaAnual = "100%";


            modelista.Add(model);

            model = new PerfilDesempenioViewModel();
            model.ResponsabilidadCargo = "Garantizar la continuidad y funcionalidad de las aplicaciones mediante el soporte a nivel nacional. A fin de asegurar la disponibilidad de las aplicaciones en función de la resolución de incidentes frecuentes en el menor tiempo.";
            model.Indicador = "Informe del estado de las aplicaciones mediante la solución de incidentes resueltos en el soporte de aplicaciones";
            model.MetaAnual = "40%";
            modelista.Add(model);

            model = new PerfilDesempenioViewModel();
            model.ResponsabilidadCargo = "Incrementar la satisfacción del servicio se porte de TI a través de la solución oportuna de requerimientos enviados por los clientes a través de la mesa de servicio .";
            model.Indicador = "Gestión  de Mesa de servicio  ";
            model.MetaAnual = "100%";
            modelista.Add(model);

            return PartialView("_ViewAll", modelista);
            //}

        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idNivel = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new AcuerdoDesempenioViewModel();

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            //else
            //{
            //    var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
            //    if (response.Succeeded)
            //    {
            //        var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
            //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            //    }
            //}
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEditPerfil(int id = 0, int idNivel = 0)
        {

            if (id == 0)
            {
                var entidadViewModel = new PerfilDesempenioViewModel();

                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 11 });
                entidadViewModel.NumMesesList = new SelectList(cat11.Data, "Secuencia", "Nombre");
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                var entidadViewModel = new PerfilDesempenioViewModel();
                entidadViewModel.ResponsabilidadCargo = "Coordina la adopción de iniciativas globales , asegurando su correcto funcionamiento a nivel local.";
                entidadViewModel.Indicador = "100% de Aplicaciones de iniciativas del Centro Global implementadas acorde a los cronogramas establecidos por LACRO o GC.";
                entidadViewModel.MetaAnual = "100%";

                var cat2 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 10 });
                entidadViewModel.UnidadList = new SelectList(cat2.Data, "Secuencia", "Nombre");
                var cat11 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 11 });
                entidadViewModel.NumMesesList = new SelectList(cat11.Data, "Secuencia", "Nombre");

                var MetaViewModelL = new List<MetaViewModel>();
                var MetaViewModel = new MetaViewModel();
                MetaViewModel.NumMeses = 3;
                MetaViewModel.TipoMedida = 1;
                MetaViewModel.Valor = 20;
                MetaViewModel.Entregable = "Aplicaciones disponibles de iniciativas Globales o Regionales";
                MetaViewModelL.Add(MetaViewModel);

                MetaViewModel = new MetaViewModel();
                MetaViewModel.NumMeses = 6;
                MetaViewModel.TipoMedida = 1;
                MetaViewModel.Valor = 30;
                MetaViewModel.Entregable = "Aplicaciones disponibles";
                MetaViewModelL.Add(MetaViewModel);


                MetaViewModel = new MetaViewModel();
                MetaViewModel.NumMeses = 9;
                MetaViewModel.TipoMedida = 1;
                MetaViewModel.Valor = 30;
                MetaViewModel.Entregable = "Aplicaciones disponibles de iniciativas Globales o Regionales";
                MetaViewModelL.Add(MetaViewModel);

                MetaViewModel = new MetaViewModel();
                MetaViewModel.NumMeses = 12;
                MetaViewModel.TipoMedida = 1;
                MetaViewModel.Valor = 20;
                MetaViewModel.Entregable = "Aplicaciones disponibles de iniciativas Globales o Regionales";
                MetaViewModelL.Add(MetaViewModel);

                entidadViewModel.MetaTacticas = MetaViewModelL;

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });

            }
            //else
            //{
            //    var response = await _mediator.Send(new GetIndicadorPOAByIdQuery() { Id = id });
            //    if (response.Succeeded)
            //    {
            //        var entidadViewModel = _mapper.Map<IndicadorPOAViewModel>(response.Data);
            //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            //    }
            //}
            return null;
        }
    }
}
