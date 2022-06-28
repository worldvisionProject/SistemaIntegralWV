using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached;
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetAllCached;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Web.Areas.Planificacion.Models;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Areas.Valoracion.Models;
using WordVision.ec.Web.Extensions;
using WordVision.ec.Application.Features.Valoracion.Escalas.Queries.GetAll;
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetAll;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;

namespace WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // Regarding cleaning the ModelState:
        // https://stackoverflow.com/questions/54356921/razor-views-bounded-property-not-updating-after-post

        [BindRequired]
        [BindProperty(SupportsGet = true)]
        public int CurrentStepIndex { get; set; }
        public int Estado { get; set; }
        public string DescEstado { get; set; }
        public string Colaborador { get; set; }
        public int Perfil { get; set; }
        public IList<StepViewModel> Steps { get; set; }
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private INotyfService _notify;
        private IWebHostEnvironment _env;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;
        private readonly ILogger<IndexModel> _logger;
        // private readonly ContactService _service;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IEmailSender email, IWebHostEnvironment env, IMediator mediator, IMapper mapper, INotyfService notify)//ContactService service)
        {
            // _service = service;
            _configuration = configuration;
            _emailSender = email;
            _env = env;
            _mediator = mediator;
            _mapper = mapper;
            _notify = notify;
            _logger = logger;
            InitializeSteps();
        }

        private void InitializeSteps()
        {
            Steps = typeof(StepViewModel)
                .Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && typeof(StepViewModel).IsAssignableFrom(t))
                .Select(t => (StepViewModel)Activator.CreateInstance(t))
                .OrderBy(x => x.Position)
                .ToList();
        }

        public async Task<IActionResult> OnGetAsync(int id, int perfil = 0, int anioFiscal = 0)/*0 colaborador 1:p jefatura*/
        {
            try
            {
                HttpContext.Session.SetInt32("PerfilId", perfil);
                Perfil = perfil;
                if (id != null)
                {
                    var responseColaborador = await _mediator.Send(new GetColaboradorByIdQuery() { Id = id });
                    if (responseColaborador.Succeeded)
                    {
                        if (responseColaborador.Data != null)
                        {
                            var colaborador = responseColaborador.Data.Apellidos + " " + responseColaborador.Data.ApellidoMaterno
                             + " " + responseColaborador.Data.PrimerNombre + " " + responseColaborador.Data.SegundoNombre;
                            HttpContext.Session.SetString("ColaboradorNombre", colaborador);
                            Colaborador = colaborador;
                        }
                    }
                    int anioActual = 0;
                    string descAnioActual=string.Empty ;
                    if (anioFiscal==0)
                    {
                        var responseAnio = await _mediator.Send(new GetAllEstrategiaNacionalesCachedQuery());
                        if (responseAnio.Succeeded)
                        {
                            var viewModel = _mapper.Map<List<EstrategiaNacionalViewModel>>(responseAnio.Data);
                            int contar = viewModel.Where(x => x.Estado == "1").SelectMany(f => f.Gestiones).Where(d => d.Estado == "1").Count();
                            if (contar>1)
                            {
                                _notify.Error("Existe mas de un Año Fiscal Activo, no puede continuar. Consulte al Administrador.");
                                return Page();
                            }
                            var responseAF = viewModel.Where(x => x.Estado == "1").SelectMany(f => f.Gestiones).Where(d => d.Estado == "1").FirstOrDefault();//.Id.Select(s=>s.Id).FirstOrDefault();
                            anioActual=_mapper.Map<GestionViewModel>(responseAF).Id;
                            descAnioActual = _mapper.Map<GestionViewModel>(responseAF).Anio;
                            TempData["AnioActual"] = anioActual;
                        }
                    }
                    else
                    {
                        TempData["AnioActual"] = anioFiscal;
                    }
                    var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = (int) TempData["AnioActual"], IdColaborador = id,Perfil= perfil });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<ObjetivoResponseViewModel>>(response.Data);
                        if (viewModel.SelectMany(c=>c.AnioFiscales).Count()==0)
                        {
                            _notify.Error("No existe objetivos para este Año Fiscal "+ descAnioActual + ", no puede continuar. Consulte al Administrador.");
                            return Page();
                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery() );
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);
                        }
                        
                        DescEstado = viewModel.Select(p=>p.DescEstadoProceso).FirstOrDefault();
                        Estado= viewModel.Select(p => p.EstadoProceso).FirstOrDefault();
                        LoadWizardData(viewModel, id, viewModelEscala, perfil);
                    }

                    if (id == 4)
                    {
                        //  JumpToStepAsync(this.Steps[0], 3);
                        return this.RedirectToPage("./Index"); //new { idStep = 3 , handler = "StepLink" }


                        //return Page();
                    }
                    //if (client != null)
                    //{
                    //    LoadWizardData(client);
                    //}
                    //else
                    //{
                    //    return NotFound();
                    //}
                }
                //else
                //{
                //    SetEmptyTempData();
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer datos de los objetivos.");
                _notify.Error("Error al traer datos de los objetivos.");
            }
            return Page();

        }
        public async Task<PageResult> OnPostStepLink(StepViewModel currentStep, int idStep)
        {
            var suma = decimal.Zero;
            var porcentaje = decimal.Zero;
            int perfil = (int)HttpContext.Session.GetInt32("PerfilId");
            Perfil = perfil;
            Colaborador = HttpContext.Session.GetString("ColaboradorNombre");
            Decimal? valor = 0;
            string calificacion = "";
            switch (currentStep.Position)
            {
                case 0:
                    var c = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_1Step)currentStep;
                    DescEstado = c.DescEstadoProceso;
                    Estado = c.EstadoProceso;
                    var ponderacion = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c.IdObjetivo });
                    var min = ponderacion.Data.Minimo;
                    var max = ponderacion.Data.Maximo;
                    porcentaje = ponderacion.Data.Ponderacion;
                    var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c.IdObjetivo, IdColaborador = c.IdColaborador });
                    var contar = planifica.Data.Count();

                   
                    var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c.AnioFiscal, IdColaborador = c.IdColaborador, Perfil = perfil });
                    if (response.Succeeded)
                    {

                        foreach (var r in response.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c.ValorValoracionFinal = valor;
                    c.ValoracionFinal = calificacion;

                    foreach (var l in planifica.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }

                    if (contar >= min && contar <= max)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(c, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 0);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: "+ suma.ToString());
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 0);
                        _notify.Error("Debe ingresar minimo " + min.ToString() + " Resultados.");
                        return Page();
                    }

                    break;

                case 1:
                    var c1 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_2Step)currentStep;
                    DescEstado = c1.DescEstadoProceso;
                    Estado = c1.EstadoProceso;
                    var ponderacion1 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c1.IdObjetivo });
                    var min1 = ponderacion1.Data.Minimo;
                    var max1 = ponderacion1.Data.Maximo;
                    var planifica1 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c1.IdObjetivo, IdColaborador = c1.IdColaborador });
                    var contar1 = planifica1.Data.Count();
                    porcentaje = ponderacion1.Data.Ponderacion;

                  
                    var response1 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c1.AnioFiscal, IdColaborador = c1.IdColaborador, Perfil = perfil });
                    if (response1.Succeeded)
                    {

                        foreach (var r in response1.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c1.ValorValoracionFinal = valor;
                    c1.ValoracionFinal = calificacion;


                    foreach (var l in planifica1.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar1 >= min1 && contar1 <= max1)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(c1, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 1);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: " + suma.ToString());
                            return Page();
                        }
                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 1);
                        _notify.Error("Debe ingresar minimo " + min1.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 2:
                    var c2 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_3Step)currentStep;
                    DescEstado = c2.DescEstadoProceso;
                    Estado = c2.EstadoProceso;
                    var ponderacion2 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c2.IdObjetivo });
                    var min2 = ponderacion2.Data.Minimo;
                    var max2 = ponderacion2.Data.Maximo;
                    var planifica2 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c2.IdObjetivo, IdColaborador = c2.IdColaborador });
                    var contar2 = planifica2.Data.Count();
                    porcentaje = ponderacion2.Data.Ponderacion;

                    var response2 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c2.AnioFiscal, IdColaborador = c2.IdColaborador, Perfil = perfil });
                    if (response2.Succeeded)
                    {

                        foreach (var r in response2.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c2.ValorValoracionFinal = valor;
                    c2.ValoracionFinal = calificacion;

                    foreach (var l in planifica2.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar2 >= min2 && contar2 <= max2)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(c2, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 2);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: " + suma.ToString());
                            return Page();
                        }
                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 2);
                        _notify.Error("Debe ingresar minimo " + min2.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 3:
                    var c3 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_4Step)currentStep;
                    DescEstado = c3.DescEstadoProceso;
                    Estado = c3.EstadoProceso;
                    var ponderacion3 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c3.IdObjetivo });
                    var min3 = ponderacion3.Data.Minimo;
                    var max3 = ponderacion3.Data.Maximo;
                    var planifica3 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c3.IdObjetivo, IdColaborador = c3.IdColaborador });
                    var contar3 = planifica3.Data.Count();
                    porcentaje = ponderacion3.Data.Ponderacion;


                    var response3 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c3.AnioFiscal, IdColaborador = c3.IdColaborador, Perfil = perfil });
                    if (response3.Succeeded)
                    {

                        foreach (var r in response3.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c3.ValorValoracionFinal = valor;
                    c3.ValoracionFinal = calificacion;

                    foreach (var l in planifica3.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar3 >= min3 && contar3 <= max3)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(c3, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 3);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: " + suma.ToString());
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 3);
                        _notify.Error("Debe ingresar minimo " + min3.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 4:
                    var c4 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_5Step)currentStep;
                    DescEstado = c4.DescEstadoProceso;
                    Estado = c4.EstadoProceso;

                    var response4 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c4.AnioFiscal, IdColaborador = c4.IdColaborador, Perfil =perfil });
                    if (response4.Succeeded)
                    {

                        foreach (var r in response4.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c4.ValorValoracionFinal = valor;
                    c4.ValoracionFinal = calificacion;


                    JumpToStepAsync(c4, idStep);
                    break;
                case 5:
                    var c5 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_6Step)currentStep;
                    DescEstado = c5.DescEstadoProceso;
                    Estado = c5.EstadoProceso;

                    var response5 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c5.AnioFiscal, IdColaborador = c5.IdColaborador, Perfil = perfil });
                    if (response5.Succeeded)
                    {

                        foreach (var r in response5.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c5.ValorValoracionFinal = valor;
                    c5.ValoracionFinal = calificacion;

                    JumpToStepAsync(c5, idStep);
                    break;
                case 6:
                    var c6 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
                    DescEstado = c6.DescEstadoProceso;
                    Estado = c6.EstadoProceso;

                    var response6 = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = c6.AnioFiscal, IdColaborador = c6.IdColaborador, Perfil = perfil });
                    if (response6.Succeeded)
                    {

                        foreach (var r in response6.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                        {
                            if (r.PonderacionResultado != null)
                            {
                                valor = valor + r.PonderacionResultado;
                            }

                        }
                        var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                        List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                        if (responseEscala.Succeeded)
                        {
                            viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                            foreach (var e in viewModelEscala)
                            {
                                if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                                {
                                    calificacion = e.Calificacion;
                                    break;
                                }
                            }
                        }
                    }
                    c6.ValorValoracionFinal = valor.ToString();
                    c6.ValoracionFinal = calificacion;

                    JumpToStepAsync(c6, idStep);
                    break;
                default:
                  
                    JumpToStepAsync(currentStep, idStep);
                    break;
            }
            return Page();
            //if (currentStep.Position == 5)
            //{
            //    var c = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_1Step)currentStep;

            //    int num = c.;
            //    if (num >= 2)
            //    {

            //        if (ModelState.IsValid) MoveToNextStep(currentStep);
            //        return Page();
            //    }
            //    else
            //    {
            //        _notify.Error("Debe ingresar minimo dos Contactos.");


            //        return Page();
            //    }

            //}
            //else
            //{
            //JumpToStepAsync(currentStep, idStep);
            //return Page();
            //}
        }


        public async Task<PageResult> OnPostNext(StepViewModel currentStep)
        {
            int perfil = (int)HttpContext.Session.GetInt32("PerfilId");
            Perfil = perfil;
            
            Colaborador = HttpContext.Session.GetString("ColaboradorNombre");

            switch (currentStep.Position)
            {
                case 0:
                    var c = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_1Step)currentStep;
                    DescEstado = c.DescEstadoProceso;
                    Estado = c.EstadoProceso;
                    var ponderacion = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c.IdObjetivo });
                    var min = ponderacion.Data.Minimo;
                    var max = ponderacion.Data.Maximo;
                    var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c.IdObjetivo, IdColaborador =c.IdColaborador });
                    var contar = planifica.Data.Count();

                    var porcentaje = ponderacion.Data.Ponderacion;
                    var suma = decimal.Zero;
                    foreach (var l in planifica.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }

                    if (contar >= min && contar <= max)
                    {
                        if (suma == porcentaje)
                        { 
                            if (ModelState.IsValid) MoveToNextStep(currentStep); 
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 0);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: " + suma.ToString());
                            return Page();
                        }
                      
                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 0);
                        _notify.Error("Debe ingresar minimo " + min.ToString() + " Resultados.");
                        return Page();
                    }
                    
                    break;

                case 1:
                    var c1 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_2Step)currentStep;
                    DescEstado = c1.DescEstadoProceso;
                    Estado = c1.EstadoProceso;
                    var ponderacion1 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c1.IdObjetivo });
                    var min1 = ponderacion1.Data.Minimo;
                    var max1 = ponderacion1.Data.Maximo;
                    var planifica1 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c1.IdObjetivo, IdColaborador = c1.IdColaborador });
                    var contar1 = planifica1.Data.Count();

                    var porcentaje1 = ponderacion1.Data.Ponderacion;
                    var suma1 = decimal.Zero;
                    foreach (var l in planifica1.Data)
                    {
                        suma1 = suma1 + (decimal)l.Ponderacion;
                    }


                    if (contar1 >= min1 && contar1<= max1)
                    {
                        if (suma1 == porcentaje1)
                        {
                            if (ModelState.IsValid) MoveToNextStep(currentStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 1);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje1.ToString() + " %, en la ponderación. Actualmente suman: " + suma1.ToString());
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 1);
                        _notify.Error("Debe ingresar minimo " + min1.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 2:
                    var c2 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_3Step)currentStep;
                    DescEstado = c2.DescEstadoProceso;
                    Estado = c2.EstadoProceso;
                    var ponderacion2 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c2.IdObjetivo });
                    var min2 = ponderacion2.Data.Minimo;
                    var max2 = ponderacion2.Data.Maximo;
                    var planifica2 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c2.IdObjetivo, IdColaborador = c2.IdColaborador });
                    var contar2 = planifica2.Data.Count();
                    
                    var porcentaje2 = ponderacion2.Data.Ponderacion;
                    var suma2 = decimal.Zero;
                    foreach (var l in planifica2.Data)
                    {
                        suma2 = suma2 + (decimal)l.Ponderacion;
                    }

                   
                    if (contar2 >= min2 && contar2 <= max2)
                    {
                        if (suma2 == porcentaje2)
                        {
                            if (ModelState.IsValid) MoveToNextStep(currentStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 2);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje2.ToString() + " %, en la ponderación. Actualmente suman: " + suma2.ToString());
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 2);
                        _notify.Error("Debe ingresar minimo " + min2.ToString() + " y maximo "+ max2.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 3:
                    var c3 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_4Step)currentStep;
                    DescEstado = c3.DescEstadoProceso;
                    Estado = c3.EstadoProceso;
                    var ponderacion3 = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = c3.IdObjetivo });
                    var min3 = ponderacion3.Data.Minimo;
                    var max3 = ponderacion3.Data.Maximo;
                    var planifica3 = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = c3.IdObjetivo, IdColaborador = c3.IdColaborador });
                    var contar3 = planifica3.Data.Count();

                    var porcentaje3 = ponderacion3.Data.Ponderacion;
                    var suma3= decimal.Zero;
                    foreach (var l in planifica3.Data)
                    {
                        suma3 = suma3 + (decimal)l.Ponderacion;
                    }

                    if (contar3 >= min3 && contar3 <= max3)
                    {
                        if (suma3 == porcentaje3)
                        {
                            if (ModelState.IsValid) MoveToNextStep(currentStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 3);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje3.ToString() + " %, en la ponderación. Actualmente suman: " + suma3.ToString());
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(currentStep, 3);
                        _notify.Error("Debe ingresar minimo " + min3.ToString() + " Resultados.");
                        return Page();
                    }
                    break;
                case 4:
                    var c4 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_5Step)currentStep;
                    DescEstado = c4.DescEstadoProceso;
                    Estado = c4.EstadoProceso;
                    if (ModelState.IsValid) MoveToNextStep(currentStep);
                    break;
                case 5:
                    var c5 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_6Step)currentStep;
                    DescEstado = c5.DescEstadoProceso;
                    Estado = c5.EstadoProceso;
                    if (ModelState.IsValid) MoveToNextStep(currentStep);
                    break;
                case 6:
                    var c6 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
                    DescEstado = c6.DescEstadoProceso;
                    Estado = c6.EstadoProceso;
                    c6.ComentarioColaborador = "ewewewe0";
                 
                    if (ModelState.IsValid) MoveToNextStep(c6);
                    break;
                default:
                  
                    if (ModelState.IsValid) MoveToNextStep(currentStep);
                    break;
            }
            return Page();


            //if (currentStep.Position == 5)
            //{
            //    var c = (WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard.ContactosStep)currentStep;

            //    int num = c.NumContacto;
            //    if (num >= 2)
            //    {

            //        if (ModelState.IsValid) MoveToNextStep(currentStep);
            //        return Page();
            //    }
            //    else
            //    {
            //        _notify.Error("Debe ingresar minimo dos Contactos.");

            //        return Page();
            //    }

            //}
            //else
            //{


            //}
        }

        public PageResult OnPostPrevious(StepViewModel currentStep)
        {
            if (ModelState.IsValid) MoveToPreviousStep(currentStep);
            return Page();
        }

        public async Task<IActionResult> OnPostDevolver(StepViewModel currentStep)
        {
            var c = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
            int id = c.IdColaborador;
            try
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction("EnviarMail", "Objetivo", new { Area = "Valoracion", idColaborador = id, reportaA = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value), proceso = 3, idAnioFiscal = c.AnioFiscal });

                }
                else
                {
                    return RedirectToPage("Index", new { id = 1 });
                }
            }
            catch (Exception ex)
            {
                _notify.Error($"Error en devolver los datos.");
                _logger.LogError(ex, $"Error en devolver los datos Formulario.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                return new JsonResult(new { isValid = false });
            }
        }
        
        public async Task<IActionResult> OnPostFinish(StepViewModel currentStep)
        {
            //if (Request.Form.Files.Count == 0)
            //{
            //    _notify.Error("Firma obligatoria.");
            //    ModelState.AddModelError("", "Firma obligatoria");
            //    return Page();
            //}

            if (!ModelState.IsValid) return Page();

  

            //if (client.Idioma != "S")
            //{
            //    _notify.Error("Firma obligatoria.");
            //    ModelState.AddModelError("", "Firma obligatoria");
            //    return Page();
            //}


            //_service.Save(client);

            //OnPostCreateOrEdit(id, client);



            int perfil = HttpContext.Session.GetInt32("PerfilId") == null?0: (int)HttpContext.Session.GetInt32("PerfilId"); ;
            Perfil =perfil;
            var c = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
            int id = c.IdColaborador;
            bool validado=false;
            Estado = c.EstadoProceso;
            DescEstado=c.DescEstadoProceso.ToString();
            try
            {
                if (ModelState.IsValid)
                {

                    if (c.EstadoProceso == 6)
                    {
                       
                            validado = false;
                            JumpToStepAsync(currentStep, 6);
                            _notify.Error("Valoracion Finalizada no se puede modificar.");
                            return Page();
                       
                    }

                    var listaObjetivos = await _mediator.Send(new GetObjetivoByIdAnioFiscalQuery() { IdAnioFiscal = c.AnioFiscal });
                    foreach (var l in listaObjetivos.Data)
                    {

                        var ponderacion = await _mediator.Send(new GetObjetivoByIdAnioQuery() { Id = l.Id });
                        var min = ponderacion.Data.Minimo;
                        var max = ponderacion.Data.Maximo;
                        var planifica = await _mediator.Send(new GetPlanificacionResultadoByIdObjetivoColaboradorQuery() { IdObjetivo = l.Id, IdColaborador = c.IdColaborador });
                        var contar = planifica.Data.Count();

                        var porcentaje = ponderacion.Data.Ponderacion;
                        var suma = decimal.Zero;
                        foreach (var l1 in planifica.Data)
                        {
                            suma = suma + (decimal)l1.Ponderacion;
                        }

                        if (contar >= min && contar <= max)
                        {
                            if (suma == porcentaje)
                            {
                                validado = true;
                            }
                            else
                            {
                                validado = false;
                                JumpToStepAsync(currentStep, Convert.ToInt32( l.Numero) - 1);
                                _notify.Error("OBJETIVO: "+ l.Numero + ". Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación. Actualmente suman: " + suma.ToString());
                                return Page();
                            }

                        }
                        else
                        {
                            validado = false;
                            JumpToStepAsync(currentStep, Convert.ToInt32(l.Numero) - 1);
                            _notify.Error("OBJETIVO: " + l.Numero + ". Debe ingresar minimo " + min.ToString() + " Resultados.");
                            return Page();
                        }


                        if  (c.EstadoProceso==4)
                        {
                           foreach(var p in planifica.Data)
                            {
                                if (Convert.ToInt32(l.Numero)==1 || Convert.ToInt32(l.Numero) == 2 || Convert.ToInt32(l.Numero) == 3 || Convert.ToInt32(l.Numero) == 4)
                                {
                                    if (p.FechaCumplimiento == null || p.PorcentajeCumplimiento == null || p.PonderacionResultado == null)
                                    {
                                        validado = false;
                                        JumpToStepAsync(currentStep, Convert.ToInt32(l.Numero) - 1);
                                        _notify.Error("OBJETIVO: " + l.Numero + ". No todos los  items tiene datos de Final del periodo.");
                                        return Page();
                                    }
                                }
                                else
                                {
                                    if (p.ComentarioCumplimiento == null )
                                    {
                                        validado = false;
                                        JumpToStepAsync(currentStep, Convert.ToInt32(l.Numero) - 1);
                                        _notify.Error("OBJETIVO: " + l.Numero + ". No todos los  items tiene datos de Final del periodo.");
                                        return Page();
                                    }
                                }
                               
                            }

                            
                        }

                        

                    }

                    if (c.EstadoProceso == 5)
                    {
                        if (ModelState["ValoracionLider1"]?.AttemptedValue == null || ModelState["ValoracionLider1"]?.AttemptedValue.Length == 0)
                        {
                            validado = false;
                            JumpToStepAsync(currentStep, 6);
                            _notify.Error("Ingrese la valoracion Final del Lider 1.");
                            return Page();
                        }
                        if (ModelState["ComentarioLider1"]?.AttemptedValue == null || ModelState["ComentarioLider1"]?.AttemptedValue.Length == 0)
                        {
                            validado = false;
                            JumpToStepAsync(currentStep, 6);
                            _notify.Error("Ingrese el comentario Final del Lider 1.");
                            return Page();
                        }
                    }

                    // ACTAULZIA EN TABLA ACTIVE
                    //UsuarioViewModel usr = new UsuarioViewModel();
                    //usr.UserNameRegular = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                    //usr.ApellidoPaterno = client.ApellidoPaterno;
                    //usr.ApellidoMaterno = client.ApellidoMaterno;
                    //usr.PrimerNombre = client.PrimerNombre;
                    //usr.SegundoNombre = client.SegundoNombre;


                    //var updateUsuarioCommand = _mapper.Map<UpdateUsuarioCommand>(usr);
                    //var resultUsuario = await _mediator.Send(updateUsuarioCommand);
                    if (validado)
                    {
                        var cf = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;

                        return RedirectToAction("EnviarMail", "Objetivo", new
                        {
                            Area = "Valoracion",
                            idColaborador = id,
                            reportaA = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value),
                            proceso = perfil == 0 ? 1 : 2,
                            idAnioFiscal = c.AnioFiscal,
                            ComentarioColaborador = ModelState["ComentarioColaborador"]?.AttemptedValue.Split(',')[0]
                             ,
                            ComentarioLider1 = ModelState["ComentarioLider1"]?.AttemptedValue.Split(',')[0]
                            ,
                            ComentarioLider2 = ModelState["ComentarioLider2"]?.AttemptedValue
                            ,
                            ComentarioLiderMatricial = ModelState["ComentarioLiderMatricial"]?.AttemptedValue
                            ,
                            ValorValoracionFinal = cf.ValorValoracionFinal?.Replace(",",".")
                            ,
                            ValoracionFinal = cf.ValoracionFinal
                            ,
                            ValoracionLider1 = ModelState["ValoracionLider1"]?.AttemptedValue,
                            estadoProceso = cf.EstadoProceso
                        });
                    }
                    else
                    {
                    
                        JumpToStepAsync(currentStep, 6);
                        _notify.Error("Error en los datps ingresados en los objetivos.");
                        return Page();
                    }

                    //return RedirectToPage("Index", new { id = client.Id });

                }
                else
                {
                    return RedirectToPage("Index", new { id =   1 });
                }
            }
            catch (Exception ex)
            {
                _notify.Error($"Error en Finalizar los datos.");
                _logger.LogError(ex,$"Error en Finalizar los datos Formulario.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                return new JsonResult(new { isValid = false });
            }





        }

        private void LoadWizardData(List<ObjetivoResponseViewModel> client, int IdColaborador, List<EscalaViewModel> escala, int perfil=0)
        {
            TempData["ClientId"] = IdColaborador;
           
            Steps = StepMapper.ToSteps(client, escala).OrderBy(x => x.Position).ToList();

            for (var i = 0; i < Steps.Count; i++)
            {
                TempData.Set($"Step{i}", Steps[i]);
            }
        }

        private void SetEmptyTempData()
        {
            TempData.Remove("ClientId");
            for (var i = 0; i < Steps.Count; i++)
            {
                TempData.Set($"Step{i}", Steps[i]);
            }
        }

        private void MoveToNextStep(StepViewModel currentStep) => JumpToStepAsync(currentStep, CurrentStepIndex + 1);

        private void MoveToPreviousStep(StepViewModel currentStep) => JumpToStepAsync(currentStep, CurrentStepIndex - 1);

        private async void JumpToStepAsync(StepViewModel currentStep, int nextStepPosition)
        {
            try
            {
                //if (currentStep.Position != 4 && currentStep.Position != 5 && currentStep.Position != 6)
                //    TempData.Set($"Step{CurrentStepIndex}", currentStep);
                //else
                //{
                //    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                //    if (response.Succeeded)
                //    {
                //        var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                //        if (formularioViewModel == null)
                //        {
                //            formularioViewModel = new FormularioViewModel();
                //            formularioViewModel.Id = 0;
                //        }

                //        formularioViewModel.IdColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                //        // LoadWizardData(formularioViewModel);
                //        TempData.Set($"Step{CurrentStepIndex}", formularioViewModel.FormularioTerceros);

                //    }
                //}
                CurrentStepIndex = nextStepPosition;
                string json = "";
                if (nextStepPosition == 6)
                {
                    decimal? valor = (Decimal)0;
                    string calificacion = string.Empty;
                    int a = 0, c = 0, p = 0;
                    switch (currentStep.Position)
                    {
                        case 0:
                            var c1 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_1Step)currentStep;
                            //a = c1.AnioFiscal;
                            //c = c1.IdColaborador;
                            //p = c1.Perfil;
                            valor = c1.ValorValoracionFinal;
                            calificacion = c1.ValoracionFinal;
                            break;
                        case 1:
                            var c2 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_2Step)currentStep;
                            a = c2.AnioFiscal;
                            c = c2.IdColaborador;
                            p = c2.Perfil;
                            valor = c2.ValorValoracionFinal;
                            calificacion = c2.ValoracionFinal;
                            break;
                        case 2:
                            var c3 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_3Step)currentStep;
                            a = c3.AnioFiscal;
                            c = c3.IdColaborador;
                            p = c3.Perfil;
                            valor = c3.ValorValoracionFinal;
                            calificacion = c3.ValoracionFinal;
                            break;
                        case 3:
                            var c4 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_4Step)currentStep;
                            a = c4.AnioFiscal;
                            c = c4.IdColaborador;
                            p = c4.Perfil;
                            valor = c4.ValorValoracionFinal;
                            calificacion = c4.ValoracionFinal;
                            break;
                        case 4:
                            var c5 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_5Step)currentStep;
                            a = c5.AnioFiscal;
                            c = c5.IdColaborador;
                            p = c5.Perfil;
                            valor = c5.ValorValoracionFinal;
                            calificacion = c5.ValoracionFinal;
                            break;
                        case 5:
                            var c6 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_6Step)currentStep;
                            a = c6.AnioFiscal;
                            c = c6.IdColaborador;
                            p = c6.Perfil;
                            valor = c6.ValorValoracionFinal;
                            calificacion = c6.ValoracionFinal;
                            break;
                        case 6:
                            var c7 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
                            a = c7.AnioFiscal;
                            c = c7.IdColaborador;
                            p = c7.Perfil;
                            valor =Convert.ToDecimal( c7.ValorValoracionFinal);
                            calificacion = c7.ValoracionFinal;
                            break;
                    }

                    //var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = a, IdColaborador = c, Perfil = p });
                    //if (response.Succeeded)
                    //{

                    //    foreach (var r in response.Data.SelectMany(c => c.AnioFiscales.SelectMany(p => p.PlanificacionResultados)))
                    //    {
                    //        if (r.PonderacionResultado != null)
                    //        {
                    //            valor = valor + r.PonderacionResultado;
                    //        }

                    //    }
                    //    var responseEscala = await _mediator.Send(new GetAllEscalaQuery());
                    //    List<EscalaViewModel> viewModelEscala = new List<EscalaViewModel>();
                    //    if (responseEscala.Succeeded)
                    //    {
                    //        viewModelEscala = _mapper.Map<List<EscalaViewModel>>(responseEscala.Data);

                    //        foreach (var e in viewModelEscala)
                    //        {
                    //            if (valor >= e.EscalaInicio && valor <= e.EscalaFin)
                    //            {
                    //                calificacion = e.Calificacion;
                    //                break;
                    //            }
                    //        }
                    //    }


                    json = (string)TempData.Peek($"Step{CurrentStepIndex}");
                    var des = JsonConvert.DeserializeObject<Objetivo_7Step>(json);
                    des.ValorValoracionFinal = valor.ToString().Replace(".",",");
                    des.ValoracionFinal = calificacion;
                    json = JsonConvert.SerializeObject(des);
                    //}
                    //    //TempData.Remove($"Step{nextStepPosition}");
                    //    //TempData.Set($"Step{nextStepPosition}", c);
                    //    //Steps[0] = c;
                    //json = (string)TempData.Peek($"Step{CurrentStepIndex}").ToString().Replace($"\"ValorValoracionFinal\":0.0", $"\"ValorValoracionFinal\":\"{valor.ToString().Replace(",",".")}\"");

                    //json = json.Replace($"\"ValoracionFinal\":\"\"", "\"ValoracionFinal\":\"" + calificacion.ToString() + "\"");

                }
                else
                json = (string)TempData.Peek($"Step{CurrentStepIndex}");



                JsonConvert.PopulateObject(json, Steps[CurrentStepIndex]);
                
                
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                _notify.Error($"Error ingrese nuevamenete al sistema.");
                _logger.LogError(ex,$"Error en insertar los datos Formulario.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);

            }

        }

        private FormularioViewModel ProcessSteps(StepViewModel finalStep)
        {
            //for (var i = 0; i < Steps.Count; i++)
            //{
            //    var data = TempData.Peek($"Step{i}");
            //    JsonConvert.PopulateObject((string)data, Steps[i]);
            //}

            Steps[CurrentStepIndex] = finalStep;

            var contact = new FormularioViewModel();
            if (TempData.Peek("ClientId") != null)
            {
                contact.Id = (int)TempData["ClientId"];
            }

          //  StepMapper.EnrichClient(contact, Steps);
            return contact;
        }

    }
}