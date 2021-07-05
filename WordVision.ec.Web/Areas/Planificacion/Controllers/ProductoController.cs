using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [Authorize]
    public class ProductoController :  BaseController<ProductoController>
    {
        public IActionResult Index(int id)
        {
            var model = new ProductoViewModel();
            model.IdGestion = id;
            return PartialView(model);
        }
        public async Task<IActionResult> LoadAll(int idGestion)
        {
            try
            {
                var viewModel = new List<ProductoViewModel>();
                //var estrategia = new EstrategiaNacionalViewModel();
                //estrategia.Nombre = "ESTRATEGIA";
                //var indicador = new IndicadorEstrategicoViewModel();
                //indicador.IndicadorResultado = "Indicador";
                var producto = new ProductoViewModel();
                producto.DescObjetivoEstra = "Promover implementación de rutas de protección de derechos de NNA en 14 cantones";
                producto.DescIndicadorEstrategico = "# sistemas o mecanismos que demuestran mejoras para la protección de NNA.";
                producto.DescProducto = "Metodología CPA en PA para mejoramiento de sistemas implementada";
                producto.DescCargoResponsable = "Alejandra Almeida";
                viewModel.Add(producto);
                var producto1 = new ProductoViewModel();
                producto1.DescObjetivoEstra = "Promover implementación de rutas de protección de derechos de NNA en 14 cantones";
                producto1.DescIndicadorEstrategico = "# de NNA impactados por cambios o mejor implementación de políticas, leyes o presupuestos.";
                producto1.DescProducto = "Plan de incidencia ante gobierno central y seccional para la expedición de políticas públicas u ordenanzas. ";
                producto1.DescCargoResponsable = "Alejandra Almeida";
                viewModel.Add(producto1);
                var producto2 = new ProductoViewModel();
                producto2.DescObjetivoEstra = "Promover implementación de rutas de protección de derechos de NNA en 14 cantones";
                producto2.DescIndicadorEstrategico = "% de actores que conocen temas principales de protección de NNA, su rol y responsabilidad.";
                producto2.DescProducto = "Metodología CPA, Canales de Esperanza y Crianza con Ternura en PA implementada";
                producto2.DescCargoResponsable = "Alejandra Almeida";
                viewModel.Add(producto2);




                //var response = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
                //if (response.Succeeded)
                //{
                //    var viewModel = _mapper.Map<List<EstrategiaNacionalViewModel>>(response.Data);
                //    var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 2 });
                //    ViewBag.EstadoList = new SelectList(cat1.Data, "Secuencia", "Nombre");

                    return PartialView("_ViewAll", viewModel);
                //}
            }
            catch (Exception ex)
            {
                _notify.Error("No se pudo cargar los Productos");
                _logger.LogError("LoadAll", ex);
            }
            return null;
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0, int idGestion = 0)
        {
            // var brandsResponse = await _mediator.Send(new GetAllBrandsCachedQuery());

            if (id == 0)
            {
                var entidadViewModel = new ProductoViewModel();
                entidadViewModel.IdGestion = idGestion;

                //  return View("_CreateOrEdit", entidadViewModel);
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                //    var response = await _mediator.Send(new GetIndicadorEstrategicoByIdQuery() { Id = id });
                //    if (response.Succeeded)
                //    {
                //        var entidadViewModel = _mapper.Map<IndicadorEstrategicoViewModel>(response.Data);
                //        // return View("_CreateOrEdit", entidadViewModel);
                var producto2 = new ProductoViewModel();
                producto2.DescObjetivoEstra = "Promover implementación de rutas de protección de derechos de NNA en 14 cantones";
                producto2.DescIndicadorEstrategico = "% de actores que conocen temas principales de protección de NNA, su rol y responsabilidad.";
                producto2.DescProducto = "Metodología CPA, Canales de Esperanza y Crianza con Ternura en PA implementada";
                producto2.DescCargoResponsable = "Alejandra Almeida";
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", producto2) });
            }
            return null;
        }


    }
}
