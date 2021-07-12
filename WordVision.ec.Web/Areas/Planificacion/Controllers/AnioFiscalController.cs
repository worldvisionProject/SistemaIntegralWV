using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Controllers
{
    [Area("Planificacion")]
    [AllowAnonymous]
    public class AnioFiscalController : BaseController<AnioFiscalController>
    {
        public IActionResult Index()
        {
            var model = new AnioFiscalViewModel();
            return View(model);

        }


        public async Task<IActionResult> LoadAll()
        {

            //var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
            //if (response.Succeeded)
            //{
            //    var documentoViewModel = _mapper.Map<ColaboradorViewModel>(response.Data);
            var anioFiscalViewModel = new List<AnioFiscalViewModel>();
            var anioFiscalViewModeldet = new AnioFiscalViewModel();
            anioFiscalViewModeldet.Id = 1;
            anioFiscalViewModeldet.Nombre = "Estrategia AF17-AG21";
            anioFiscalViewModeldet.Causa = "causa";
            anioFiscalViewModeldet.MetaNacional = "Meta Nacional";
            anioFiscalViewModeldet.MetaRegional = "Meta Regional";
            anioFiscalViewModel.Add(anioFiscalViewModeldet);

            anioFiscalViewModeldet = new AnioFiscalViewModel();
            anioFiscalViewModeldet.Id = 1;
            anioFiscalViewModeldet.Nombre = "Estrategia AF22-AG24";
            anioFiscalViewModeldet.Causa = "causa AF22-AG24";
            anioFiscalViewModeldet.MetaNacional = "Meta Nacional AF22-AG24";
            anioFiscalViewModeldet.MetaRegional = "Meta Regional AF22-AG24";
            anioFiscalViewModel.Add(anioFiscalViewModeldet);

            return PartialView("_ViewAll", anioFiscalViewModel);
            // return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", documentoViewModel) });
            //}
            //return null;

        }

        public async Task<IActionResult> OnGetCreateOrEdit(int id = 0)
        {
            //var response = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = id });
            //if (response.Succeeded)
            //{
            //    var terceroViewModel = new TerceroViewModel();
            //    terceroViewModel.idFormulario = idFormulario;
            //    if (response.Data != null)
            //        terceroViewModel = _mapper.Map<TerceroViewModel>(response.Data);
            var anioFiscalViewModel = new AnioFiscalViewModel();
            if (id != 0)
            {
                List<ObjetivoEstrategicoViewModel> lobj = new List<ObjetivoEstrategicoViewModel>();
                ObjetivoEstrategicoViewModel obj = new ObjetivoEstrategicoViewModel();
                obj.Id = 1;
                obj.Categoria = "B";
                obj.Descripcion = "Implementar una estrategia común de Gestión de Riesgos (ERM y HEA), que incorpore recursos humanos, financieros y tecnológicos que identifiquen, analicen y cuantifiquen las probabilidades de pérdidas y efectos secundarios en temas administrativos financieros, legales, y de gestión de desastres.";
                obj.CargoResponsable = 1;
                obj.AreaPrioridad = "Impacto";
                obj.Dimension = "Agilidad";
                lobj.Add(obj);
                obj = new ObjetivoEstrategicoViewModel();
                obj.Id = 2;
                obj.Categoria = "N";
                obj.Descripcion = "Consolidar las operaciones en los territorios de intervención de WVE y apoyar los esfuerzos de los socios locales para un impacto duradero a través del empoderamiento de las niñas, niños, adolescentes, jóvenes, comunidades y alineando nuestros programas y proyectos al contexto nacional e internacional.";
                obj.CargoResponsable = 1;
                obj.AreaPrioridad = "Impacto";
                obj.Dimension = "Agilidad";
                lobj.Add(obj);
                obj.Id = 3;
                obj = new ObjetivoEstrategicoViewModel();
                obj.Categoria = "N";
                obj.Descripcion = "Alinear y fortalecer la cultura organizacional de World Vision Ecuador hacia la transformación estratégica, de procesos, las nuevas tecnologías, el logro de resultados y el mejoramiento continuo en armonía con nuestros valores y entorno a las demandas de la organización y del país.";
                obj.CargoResponsable = 1;
                obj.AreaPrioridad = "Impacto";
                obj.Dimension = "Agilidad";
                lobj.Add(obj);

                List<GestionViewModel> lges = new List<GestionViewModel>();
                GestionViewModel ges = new GestionViewModel();
                ges.Anio = "AF";
                ges.Descripcion = "AF21";
                ges.Estado = "I";
                lges.Add(ges);
                ges = new GestionViewModel();
                ges.Anio = "AF";
                ges.Descripcion = "AF22";
                ges.Estado = "I";
                lges.Add(ges);
                ges = new GestionViewModel();
                ges.Anio = "AF";
                ges.Descripcion = "AF23";
                ges.Estado = "I";
                lges.Add(ges);
                ges = new GestionViewModel();
                ges.Anio = "AF";
                ges.Descripcion = "AF24";
                ges.Estado = "I";
                lges.Add(ges);


                anioFiscalViewModel.Id = 1;
                anioFiscalViewModel.Nombre = "Estrategia AF17-AG21";
                anioFiscalViewModel.Causa = "causa";
                anioFiscalViewModel.MetaNacional = "Meta Nacional";
                anioFiscalViewModel.MetaRegional = "Meta Regional";
                anioFiscalViewModel.ObjetivoEstrategicos = lobj;
                anioFiscalViewModel.Gestiones = lges;
            }
            //return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", anioFiscalViewModel) });
            return View("_CreateOrEdit", anioFiscalViewModel);
            //}
            //return null;

        }

        public async Task<JsonResult> OnGetCreateOrEditObjetivo(int id = 0)
        {
            //var response = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = id });
            //if (response.Succeeded)
            //{
            //    var terceroViewModel = new TerceroViewModel();
            //    terceroViewModel.idFormulario = idFormulario;
            //    if (response.Data != null)
            //        terceroViewModel = _mapper.Map<TerceroViewModel>(response.Data);
            var _objetivoEstrategicoViewModel = new ObjetivoEstrategicoViewModel();
            if (id != 0)
            {
                ObjetivoEstrategicoViewModel obj = new ObjetivoEstrategicoViewModel();
                obj.Id = 1;
                obj.Categoria = "B";
                obj.Descripcion = "Implementar una estrategia común de Gestión de Riesgos (ERM y HEA), que incorpore recursos humanos, financieros y tecnológicos que identifiquen, analicen y cuantifiquen las probabilidades de pérdidas y efectos secundarios en temas administrativos financieros, legales, y de gestión de desastres.";
                obj.CargoResponsable = 1;
                obj.AreaPrioridad = "Impacto";
                obj.Dimension = "Agilidad";

            }
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditObjetivo", _objetivoEstrategicoViewModel) });

            //}
            //return null;

        }


        public async Task<JsonResult> OnGetCreateOrEditIndicadores(int id = 0)
        {
            //var response = await _mediator.Send(new GetTerceroByIdFormularioQuery() { Id = id });
            //if (response.Succeeded)
            //{
            //    var terceroViewModel = new TerceroViewModel();
            //    terceroViewModel.idFormulario = idFormulario;
            //    if (response.Data != null)
            //        terceroViewModel = _mapper.Map<TerceroViewModel>(response.Data);
            var _factorCriticoExitoViewModel = new FactorCriticoExitoViewModel();
            if (id != 0)
            {
                _factorCriticoExitoViewModel = new FactorCriticoExitoViewModel();
                _factorCriticoExitoViewModel.FactorCritico = "Al 30 de septiembre WVE ha fortalecido las habilidades y capacidades de sus colaboradores  para rendición de cuentas a través del uso de la información y competencias de liderazgo ";
                List<IndicadorEstrategicoViewModel> Lobj = new List<IndicadorEstrategicoViewModel>();
                var obj = new IndicadorEstrategicoViewModel();
                obj.Id = 1;
                obj.IndicadorResultado = "% personal fortalecido en sus habilidades y capacidades  para la toma de decisiones ( digitales y liderazgo)";
               
             
                obj.MedioVerificacion = "Reportes de participación del personal en capacitación  Reportes de evaluación";
                obj.Responsable =1;
                Lobj.Add(obj);

                obj = new IndicadorEstrategicoViewModel();
                obj.Id = 2;
                obj.IndicadorResultado = "% personal fortalecido en sus habilidades y capacidades  para la toma de decisiones ( digitales y liderazgo)";
               
              
                obj.MedioVerificacion = "Informe de Evaluación de Capacidades";
                obj.Responsable = 1;
                Lobj.Add(obj);

                //_factorCriticoExitoViewModel.IndicadorEstrategicos = Lobj;
            }
            return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEditIndicador", _factorCriticoExitoViewModel) });

            //}
            //return null;

        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, AnioFiscalViewModel anioFiscal)
        {
            if (ModelState.IsValid)
            {
                //if (id == 0)
                //{
                //    var createTerceroCommand = _mapper.Map<CreateTerceroCommand>(tercero);
                //    var result = await _mediator.Send(createTerceroCommand);
                //    if (result.Succeeded)
                //    {
                //        id = result.Data;
                //        _notify.Success($"Tercero con ID {result.Data} Creado.");
                //    }
                //    else _notify.Error(result.Message);
                //}
                //else
                //{
                //    var updateBrandCommand = _mapper.Map<UpdateTerceroCommand>(tercero);
                //    var result = await _mediator.Send(updateBrandCommand);
                //    if (result.Succeeded) _notify.Information($"Tercero con ID  {result.Data} Actualizado.");
                //}
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
                return null;
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", anioFiscal);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<ActionResult> PlanImplementacion(int? Id)
        {

            //var response = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
            //if (response.Succeeded)
            //{
            //    var documentoViewModel = _mapper.Map<ColaboradorViewModel>(response.Data);
            var anioFiscalViewModeldet = new AnioFiscalViewModel();
            anioFiscalViewModeldet.Id = 1;
            anioFiscalViewModeldet.Nombre = "Estrategia AF17-AG21";
            anioFiscalViewModeldet.Causa = "causa";
            anioFiscalViewModeldet.MetaNacional = "Al 2024, WV Ecuador es una organización  socia y catalizadora de alianzas estratégicas público-privadas y OBFs para impactar a NNA a través del fortalecimiento de sus habilidades para la vida, liderazgo y empoderamiento de familias y comunidades; potenciando la incidencia local y nacional para promover los derechos de los NNA y contribuir a la generación de oportunidades de medios de vida";
            anioFiscalViewModeldet.MetaRegional = "Meta Regional";

            List<ObjetivoEstrategicoViewModel> lobj = new List<ObjetivoEstrategicoViewModel>();
            ObjetivoEstrategicoViewModel obj = new ObjetivoEstrategicoViewModel();
            obj.Id = 1;
            obj.Categoria = "B";
            obj.Descripcion = "Implementar una estrategia común de Gestión de Riesgos (ERM y HEA), que incorpore recursos humanos, financieros y tecnológicos que identifiquen, analicen y cuantifiquen las probabilidades de pérdidas y efectos secundarios en temas administrativos financieros, legales, y de gestión de desastres.";
            obj.CargoResponsable = 1;
            obj.AreaPrioridad = "Impacto";
            obj.Dimension = "Agilidad";
            lobj.Add(obj);
            obj = new ObjetivoEstrategicoViewModel();
            obj.Id = 2;
            obj.Categoria = "N";
            obj.Descripcion = "Consolidar las operaciones en los territorios de intervención de WVE y apoyar los esfuerzos de los socios locales para un impacto duradero a través del empoderamiento de las niñas, niños, adolescentes, jóvenes, comunidades y alineando nuestros programas y proyectos al contexto nacional e internacional.";
            obj.CargoResponsable = 1;
            obj.AreaPrioridad = "Impacto";
            obj.Dimension = "Agilidad";
            lobj.Add(obj);
            obj.Id = 3;
            obj = new ObjetivoEstrategicoViewModel();
            obj.Categoria = "N";
            obj.Descripcion = "Alinear y fortalecer la cultura organizacional de World Vision Ecuador hacia la transformación estratégica, de procesos, las nuevas tecnologías, el logro de resultados y el mejoramiento continuo en armonía con nuestros valores y entorno a las demandas de la organización y del país.";
            obj.CargoResponsable = 1;
            obj.AreaPrioridad = "Impacto";
            obj.Dimension = "Agilidad";

            var _factorCriticoExitoViewModel = new List<FactorCriticoExitoViewModel>();
            var _factorCriticoExitoViewModelD = new FactorCriticoExitoViewModel();
            _factorCriticoExitoViewModelD.FactorCritico = "Al 30 de septiembre WVE ha fortalecido las habilidades y capacidades de sus colaboradores  para rendición de cuentas a través del uso de la información y competencias de liderazgo ";
            
            List<IndicadorEstrategicoViewModel> LobjI = new List<IndicadorEstrategicoViewModel>();
            var objI = new IndicadorEstrategicoViewModel();
            objI.Id = 1;
            objI.IndicadorResultado = "% personal fortalecido en sus habilidades y capacidades  para la toma de decisiones ( digitales y liderazgo)";
            
            objI.UnidadMedida = 1;
           
            objI.MedioVerificacion = "Reportes de participación del personal en capacitación  Reportes de evaluación";
            objI.Responsable = 1;
            LobjI.Add(objI);

            objI = new IndicadorEstrategicoViewModel();
            objI.Id = 2;
            objI.IndicadorResultado = "% personal fortalecido en sus habilidades y capacidades  para la toma de decisiones ( digitales y liderazgo)";
           
            objI.UnidadMedida = 2;
           
            objI.MedioVerificacion = "Informe de Evaluación de Capacidades";
            objI.Responsable = 1;
            LobjI.Add(objI);

            //_factorCriticoExitoViewModelD.IndicadorEstrategicos= LobjI;
            _factorCriticoExitoViewModel.Add(_factorCriticoExitoViewModelD);
          //  obj.FactorCriticoExitos = _factorCriticoExitoViewModel;
            lobj.Add(obj);

            anioFiscalViewModeldet.ObjetivoEstrategicos = lobj;
          
            return  PartialView("_PlanImplementacion", anioFiscalViewModeldet);
           //  return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_PlanImplementacion", anioFiscalViewModeldet) });
            //}
            //return null;

        }
    }

}