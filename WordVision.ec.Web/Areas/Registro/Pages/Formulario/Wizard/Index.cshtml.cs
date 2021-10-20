using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
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
using MimeKit;
using Newtonsoft.Json;

using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Update;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Identity.Models;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Extensions;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // Regarding cleaning the ModelState:
        // https://stackoverflow.com/questions/54356921/razor-views-bounded-property-not-updating-after-post

        [BindRequired]
        [BindProperty(SupportsGet = true)]
        public int CurrentStepIndex { get; set; }

        public IList<StepViewModel> Steps { get; set; }
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private INotyfService _notify;
        private IWebHostEnvironment _env;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;
        private readonly ILogger<IndexModel> _logger;
        // private readonly ContactService _service;

        public IndexModel(ILogger<IndexModel> logger,IConfiguration configuration, IEmailSender email,IWebHostEnvironment env,IMediator mediator, IMapper mapper, INotyfService notify)//ContactService service)
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
                .Select(t => (StepViewModel) Activator.CreateInstance(t))
                .OrderBy(x => x.Position)
                .ToList();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                if (id != null)
                {
                    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                    if (response.Succeeded)
                    {
                        var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                        if (formularioViewModel == null)
                        {
                            formularioViewModel = new FormularioViewModel();
                            formularioViewModel.Id = 0;
                        }
                        if (id!=0)
                            formularioViewModel.IdColaborador = id;
                        LoadWizardData(formularioViewModel);
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
                else
                {
                    SetEmptyTempData();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Error al traer datos del Colaborador.");
                _notify.Error("Error al traer datos del Colaborador.");
            }
            return Page();

        }
        public async Task<PageResult> OnPostStepLink(StepViewModel currentStep, int idStep)
        {
            if (currentStep.Position == 5)
            {
                var c = (WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard.ContactosStep)currentStep;

                int num = c.NumContacto;
                if (num >= 2)
                {

                    if (ModelState.IsValid) MoveToNextStep(currentStep);
                    return Page();
                }
                else
                {
                    _notify.Error("Debe ingresar minimo dos Contactos.");

                    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                    if (response.Succeeded)
                    {
                        var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                        if (formularioViewModel != null)
                        {
                            num = formularioViewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
                        }
                        LoadWizardData(formularioViewModel);
                    }

                    return Page();
                }

            }
            else
            {
                JumpToStepAsync(currentStep, idStep);
             return Page();
            }
        }


        public async Task<PageResult> OnPostNext(StepViewModel currentStep)
        {
            if (currentStep.Position == 5)
            {
                var c = (WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard.ContactosStep)currentStep;
                
                int num = c.NumContacto;
                if (num >= 2)
                {

                    if (ModelState.IsValid) MoveToNextStep(currentStep);
                    return Page();
                }
                else
                {
                    _notify.Error("Debe ingresar minimo dos Contactos.");

                    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value) });
                    if (response.Succeeded)
                    {
                        var formularioViewModel = _mapper.Map<FormularioViewModel>(response.Data);
                        if (formularioViewModel != null)
                        {
                            num = formularioViewModel.FormularioTerceros.Where(x => x.Tipo == "C").Count();
                        }
                        LoadWizardData(formularioViewModel);
                    }

                    return Page();
                }
           
            }
            else
            { 

            if (ModelState.IsValid) MoveToNextStep(currentStep);
            return Page();
            }
        }

        public PageResult OnPostPrevious(StepViewModel currentStep)
        {
            if (ModelState.IsValid) MoveToPreviousStep(currentStep);
            return Page();
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

            var client = ProcessSteps(currentStep);


            //if (client.Idioma != "S")
            //{
            //    _notify.Error("Firma obligatoria.");
            //    ModelState.AddModelError("", "Firma obligatoria");
            //    return Page();
            //}
            

            //_service.Save(client);

            //OnPostCreateOrEdit(id, client);

            int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(new GetFormularioByIdQuery() { Id = id });
                    if (response.Succeeded)
                    {
                        if (response.Data == null)
                        {
                            id = 0;
                            client.Id = 0;
                        }
                        else
                        {
                            id = 1;
                            client.Id = response.Data.Id;
                        }
                        if (Request.Form.Files.Count > 0)
                        {
                            for (int i = 0; i<  Request.Form.Files.Count;i++)
                            {
                                IFormFile file = Request.Form.Files[i];
                                
                                switch (Request.Form.Files[i].Name)
                                {
                                    case "ImageCedula":
                                        var imageC = file.OpenReadStream();
                                        MemoryStream ms = new MemoryStream();
                                        imageC.CopyTo(ms);
                                        client.ImageCedula = ms.ToArray();
                                        break;
                                    case "ImagePapeleta":
                                        var imageP = file.OpenReadStream();
                                        MemoryStream msP = new MemoryStream();
                                        imageP.CopyTo(msP);
                                        client.ImagePapeleta = msP.ToArray();
                                        break;
                                    case "ImageCovid":
                                        var imageCo = file.OpenReadStream();
                                        MemoryStream msCo = new MemoryStream();
                                        imageCo.CopyTo(msCo);
                                        client.ImageCovid = msCo.ToArray();
                                        break;
                                    case "ImageDiscapacidad":
                                        var imageD = file.OpenReadStream();
                                        MemoryStream msD = new MemoryStream();
                                        imageD.CopyTo(msD);
                                        client.ImageDiscapacidad = msD.ToArray();
                                        break;
                                    case "ImageDiscapacidadFamiliar":
                                        var imageDF = file.OpenReadStream();
                                        MemoryStream msDF = new MemoryStream();
                                        imageDF.CopyTo(msDF);
                                        client.ImageDiscapacidadFamiliar = msDF.ToArray();
                                        break;
                                    case "Image":
                                        var image1 = file.OptimizeImageSize(700, 700);
                                        client.Image = image1;
                                        break;


                                }
                              
                                
                               

                            }
                           
                        }
                        else
                        {
                            _notify.Error("Ingrese PDF de la cédula,Papeleta de Votación y Carnet de COVID.");
                            return Page();
                        }
                    }
                    client.IdColaborador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);

                    if (id == 0)
                    {
                        var createBrandCommand = _mapper.Map<CreateFormularioCommand>(client);
                        var result = await _mediator.Send(createBrandCommand);
                        if (result.Succeeded)
                        {
                            id = result.Data;
                            _notify.Success($"Formulario con ID {result.Data} creado.");
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        var updateFormuCommand = _mapper.Map<UpdateFormularioCommand>(client);
                        var result = await _mediator.Send(updateFormuCommand);

                        ColaboradorViewModel cola = new ColaboradorViewModel();
                        cola.Id = client.IdColaborador;
                        cola.Apellidos = client.ApellidoPaterno;
                        cola.ApellidoMaterno = client.ApellidoMaterno;
                        cola.PrimerNombre = client.PrimerNombre;
                        cola.SegundoNombre = client.SegundoNombre;
                        cola.Identificacion = client.Identificacion;

                        var updateColaboCommand = _mapper.Map<UpdateColaboradorCommand>(cola);
                        var resultCola = await _mediator.Send(updateColaboCommand);

                        if (result.Succeeded) _notify.Information($"Formulario con ID {result.Data} actualizado.");
                        else _notify.Error(result.Message);
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
                 
                    return RedirectToAction("EnviarMail", "Formulario", new { Area = "Registro", idDocumento=0, idColaborador= client.IdColaborador });
                    //return RedirectToPage("Index", new { id = client.Id });

                }
                else
                {
                    return RedirectToPage("Index", new { id = client.Id });
                }
            }
            catch (Exception ex)
            {
                _notify.Error($"Error en insertar los datos.");
                _logger.LogError($"Error en insertar los datos Formulario.", ex);
                //var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", formulario);
                return new JsonResult(new { isValid = false });
            }




          
        }

        private void LoadWizardData(FormularioViewModel client)
        {
            TempData["ClientId"] = client.Id;
            
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
            if (currentStep.Position!=3 && currentStep.Position != 5)
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
            JsonConvert.PopulateObject((string) TempData.Peek($"Step{CurrentStepIndex}"), Steps[CurrentStepIndex]);
            ModelState.Clear();
        }

        private FormularioViewModel ProcessSteps(StepViewModel finalStep)
        {
            for (var i = 0; i < Steps.Count; i++)
            {
                var data = TempData.Peek($"Step{i}");
                JsonConvert.PopulateObject((string) data, Steps[i]);
            }

            Steps[CurrentStepIndex] = finalStep;

            var contact = new FormularioViewModel();
            if (TempData.Peek("ClientId") != null)
            {
                contact.Id = (int) TempData["ClientId"];
            }
    
            StepMapper.EnrichClient(contact, Steps);
            return contact;
        }

    }
}