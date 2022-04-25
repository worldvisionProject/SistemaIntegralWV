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

        public async Task<IActionResult> OnGetAsync(int id, int perfil = 0)/*0 colaborador 1:p jefatura*/
        {
            try
            {
                HttpContext.Session.SetInt32("PerfilId", perfil);
                Perfil = perfil;
                if (id != null)
                {
                    int anioActual = 0;
                    string descAnioActual=string.Empty ;
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
                    var response = await _mediator.Send(new GetAllPlanificacionResultadosCachedQuery() { IdAnioFiscal = (int) TempData["AnioActual"], IdColaborador = id,Perfil= perfil });
                    if (response.Succeeded)
                    {
                        var viewModel = _mapper.Map<List<ObjetivoResponseViewModel>>(response.Data);
                        if (viewModel.SelectMany(c=>c.AnioFiscales).Count()==0)
                        {
                            _notify.Error("No existe objetivos para este Año Fiscal "+ descAnioActual + ", no puede continuar. Consulte al Administrador.");
                            return Page();
                        }
                        DescEstado= viewModel.Select(p=>p.DescEstadoProceso).FirstOrDefault();
                        Estado= viewModel.Select(p => p.EstadoProceso).FirstOrDefault();
                        LoadWizardData(viewModel, id,perfil);
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
                    c.ComentarioColaborador = "ewewewe0";
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
                            JumpToStepAsync(c, 0);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación.");
                            return Page();
                        }

                    }
                    else
                    {
                        JumpToStepAsync(c, 0);
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
                    foreach (var l in planifica1.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar1 >= min1 && contar1 <= max1)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(currentStep, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 1);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación.");
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
                    foreach (var l in planifica2.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar2 >= min2 && contar2 <= max2)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(currentStep, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 2);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación.");
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
                    foreach (var l in planifica3.Data)
                    {
                        suma = suma + (decimal)l.Ponderacion;
                    }
                    if (contar3 >= min3 && contar3 <= max3)
                    {
                        if (suma == porcentaje)
                        {
                            JumpToStepAsync(currentStep, idStep);
                        }
                        else
                        {
                            JumpToStepAsync(currentStep, 3);
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación.");
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
                    JumpToStepAsync(currentStep, idStep);
                    break;
                case 5:
                    var c5 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_6Step)currentStep;
                    DescEstado = c5.DescEstadoProceso;
                    Estado = c5.EstadoProceso;
                    JumpToStepAsync(currentStep, idStep);
                    break;
                case 6:
                    var c6 = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
                    DescEstado = c6.DescEstadoProceso;
                    Estado = c6.EstadoProceso;
                   
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
                            _notify.Error("Los items debe  sumar un total del " + porcentaje.ToString() + " %, en la ponderación.");
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
                            _notify.Error("Los items debe  sumar un total del " + porcentaje1.ToString() + " %, en la ponderación.");
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
                            _notify.Error("Los items debe  sumar un total del " + porcentaje2.ToString() + " %, en la ponderación.");
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
                            _notify.Error("Los items debe  sumar un total del " + porcentaje3.ToString() + " %, en la ponderación.");
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

            //var client = ProcessSteps(currentStep);


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
            try
            {
                if (ModelState.IsValid)
                {


                    // ACTAULZIA EN TABLA ACTIVE
                    //UsuarioViewModel usr = new UsuarioViewModel();
                    //usr.UserNameRegular = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                    //usr.ApellidoPaterno = client.ApellidoPaterno;
                    //usr.ApellidoMaterno = client.ApellidoMaterno;
                    //usr.PrimerNombre = client.PrimerNombre;
                    //usr.SegundoNombre = client.SegundoNombre;



                    //var updateUsuarioCommand = _mapper.Map<UpdateUsuarioCommand>(usr);
                    //var resultUsuario = await _mediator.Send(updateUsuarioCommand);
                    var cf = (WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard.Objetivo_7Step)currentStep;
                    
                    return RedirectToAction("EnviarMail", "Objetivo", new { Area = "Valoracion", idColaborador = id, reportaA= Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ReportaA")?.Value), proceso=perfil==0?1:2, idAnioFiscal = c.AnioFiscal, estadoProceso = cf.EstadoProceso });
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

        private void LoadWizardData(List<ObjetivoResponseViewModel> client, int IdColaborador,int perfil=0)
        {
            TempData["ClientId"] = IdColaborador;
           
            Steps = StepMapper.ToSteps(client).OrderBy(x => x.Position).ToList();

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

        private void JumpToStepAsync(StepViewModel currentStep, int nextStepPosition)
        {
            try
            {
                 if (currentStep.Position != 4 && currentStep.Position != 5 && currentStep.Position != 6)
                    TempData.Set($"Step{CurrentStepIndex}", currentStep);
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
                JsonConvert.PopulateObject((string)TempData.Peek($"Step{CurrentStepIndex}"), Steps[CurrentStepIndex]);
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                _notify.Error($"Error ingrese nuevamenete al sistema.");
                _logger.LogError(ex,$"Error en insertar los datos Formulario.");
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);

            }

        }

        //private FormularioViewModel ProcessSteps(StepViewModel finalStep)
        //{
        //    for (var i = 0; i < Steps.Count; i++)
        //    {
        //        var data = TempData.Peek($"Step{i}");
        //        JsonConvert.PopulateObject((string)data, Steps[i]);
        //    }

        //    Steps[CurrentStepIndex] = finalStep;

        //    var contact = new FormularioViewModel();
        //    if (TempData.Peek("ClientId") != null)
        //    {
        //        contact.Id = (int)TempData["ClientId"];
        //    }

        //    StepMapper.EnrichClient(contact, Steps);
        //    return contact;
        //}

    }
}