using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Encuesta.EncuestaKobos;
using WordVision.ec.Application.Features.Encuesta.EReporteTabulados;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Controllers
{
    [Area("Encuesta")]
    // [Authorize]  //Para aplicar política de autorizaciones
    public class EncuestaKoboController : BaseController<EncuestaKoboController>
    {
        public async Task<IActionResult> Index()
        {

            //Traemos las evaluaciones de la base de datos y lo ponemos en el SelectList para el combo
            //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
            var respuestaEEvaluaciones = await _mediator.Send(new GetAllEEvaluacionesQuery());
            if (respuestaEEvaluaciones.Succeeded && respuestaEEvaluaciones.Data != null)
            {
                var fromDatabaseEF = new SelectList(respuestaEEvaluaciones.Data.ToList(), "Id", "NombreCompleto");
                ViewData["EEvaluacionesList"] = fromDatabaseEF;
            }


            //Ejecuta el Select que trae todos los registros de la base
            var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
            if (response.Succeeded && response.Data != null)
            {
                //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);


                //return PartialView("_ViewAll", viewModel);
                return View(viewModel);
            }

            return View(new List<EncuestaKoboViewModel>());
        }

        public async Task<IActionResult> LoadFromAPI()
        {
            try
            {
                //Traemos nuevamente los datos del API y actualizamos la base de datos

                var resp1 = await _mediator.Send(new GetAllEncuestaKobosFromAPIQuery());
                if (resp1 != null && resp1.Succeeded)
                {
                    //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                    var listadoEncuestaKoboViewModel = _mapper.Map<List<EncuestaKoboViewModel>>(resp1.Data);

                    if (listadoEncuestaKoboViewModel.Count > 0)
                    {
                        foreach (var itemViewModel in listadoEncuestaKoboViewModel)
                        {
                            //Vamos a averiguar si la encuesta ya existe para actualizalo, caso contrario lo insertamos
                            var resp = await _mediator.Send(new GetEncuestaKobosByIdQuery() { Id = itemViewModel.Id });
                            if (resp != null && resp.Succeeded && resp.Data != null)
                            {
                                //Existe el registro, lo vamos a actualizar con la info que vino de la API
                                var updateEncuestaKoboCommand = _mapper.Map<UpdateEncuestaKoboCommand>(itemViewModel);
                                var result = await _mediator.Send(updateEncuestaKoboCommand);
                            }
                            else
                            {
                                var createEntidadCommand = _mapper.Map<CreateEncuestaKoboCommand>(itemViewModel);
                                var result = await _mediator.Send(createEntidadCommand);
                            }
                        }

                        //Una vez terminada la operación de inserción o edición, se va a leer todos los registros nuevamente
                        //para mostrar un listado actualizado al usuario
                        //Ejecuta el Select que trae todos los registros de la base
                        var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                        if (response.Succeeded && response.Data != null)
                        {
                            //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                            var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);

                            //return PartialView("_ViewAll", viewModel);
                            return View(viewModel);
                        }

                        return View(new List<EncuestaKoboViewModel>());

                    }
                    else
                    {
                        return View(new List<EncuestaKoboViewModel>());
                    }

                }
                //Retornamos el Id tanto si se insertó o se modificó
                return View(new List<EncuestaKoboViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadFromAPI", ex);
                _notify.Error("Error al insertar registros batch de Encuestas Kobo");
            }
            return View();
        }

        public async Task<IActionResult> SyncRespuestasAPI(int id)
        {
            try
            {
                var resp = await _mediator.Send(new SyncEncuestaKoboCommand() { Id = id });

                //Una vez terminada la operación de sincronizacion API, se va a leer todos los registros nuevamente
                //para mostrar un listado actualizado al usuario
                //Ejecuta el Select que trae todos los registros de la base
                var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                if (response.Succeeded && response.Data != null)
                {
                    //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                    var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);

                    //return PartialView("_ViewAll", viewModel);
                    return View(viewModel);
                }

                return View(new List<EncuestaKoboViewModel>());


            }
            catch (Exception ex)
            {
                _logger.LogError("SyncRespuestasAPI", ex);
                _notify.Error("Error al sincronizar registros batch de Encuestas Kobo");
            }
            return View(new List<EncuestaKoboViewModel>());
        }

        public async Task<IActionResult> SyncAllRespuestasAPI(int id)
        {
            try
            {
                var resp = await _mediator.Send(new DeleteRelatedDataEncuestaKoboCommand() { Id = id });
                if (resp.Succeeded)
                {
                    var resp2 = await _mediator.Send(new SyncEncuestaKoboCommand() { Id = id });

                    //Una vez terminada la operación de sincronizacion API, se va a leer todos los registros nuevamente
                    //para mostrar un listado actualizado al usuario
                    //Ejecuta el Select que trae todos los registros de la base
                    var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                    if (response.Succeeded && response.Data != null)
                    {
                        //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                        var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);

                        //return PartialView("_ViewAll", viewModel);
                        return View(viewModel);
                    }
                }

                return View(new List<EncuestaKoboViewModel>());

            }
            catch (Exception ex)
            {
                _logger.LogError("SyncAllRespuestasAPI", ex);
                _notify.Error("Error al sincronizar registros batch de Encuestas Kobo");
            }
            return View(new List<EncuestaKoboViewModel>());
        }

        public async Task<IActionResult> GenerarKPI(int EvaluacionId)
        {
            try
            {
                //Traemos las evaluaciones de la base de datos y lo ponemos en el SelectList para el combo
                //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/
                var respuestaEEvaluaciones = await _mediator.Send(new GetAllEEvaluacionesQuery());
                if (respuestaEEvaluaciones.Succeeded && respuestaEEvaluaciones.Data != null && respuestaEEvaluaciones.Data.Count > 0)
                {
                    var fromDatabaseEF = new SelectList(respuestaEEvaluaciones.Data.ToList(), "Id", "NombreCompleto");
                    ViewData["EEvaluacionesList"] = fromDatabaseEF;
                }

                //Ejecuta el Select que trae todos los registros de la base
                List<EncuestaKoboViewModel> viewModel = new List<EncuestaKoboViewModel>();
                var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                if (response.Succeeded && response.Data != null)
                {
                    //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                    viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);
                }

                var resp = await _mediator.Send(new GenerateKPIResultsCommand() { evaluacionId = EvaluacionId });
                if (resp.Succeeded)
                {
                    //Mostramos un mensaje de exito
                    _notify.Success("Se han generado los resultados con éxito");
                }

                if (viewModel.Count > 0)
                    return View(viewModel);
                else
                    return View(new List<EncuestaKoboViewModel>());

            }
            catch (Exception ex)
            {
                _logger.LogError("GenerarAPI", ex);
                _notify.Error("Error al calcular los resultados de indicadores para la Evaluación seleccionada. Error: " + ex.Message);
            }
            return View(new List<EncuestaKoboViewModel>());
        }

        [HttpPost]
        public async Task<JsonResult> OnPostBatchCreateOrEdit()
        {
            //Funcion que va a actualizar la base de datos, se recibe un listado de EncuestaKobo
            try
            {
                //Traemos nuevamente los datos del API.
                var resp1 = await _mediator.Send(new GetAllEncuestaKobosFromAPIQuery());
                if (resp1.Succeeded)
                {
                    //Ponemos los valores del listado que se trajo en el formato declarado en el ViewModel
                    var listadoEncuestaKobo = _mapper.Map<List<EncuestaKoboViewModel>>(resp1.Data);

                    //Si pasaron todas las validaciones en pantalla, entonces proceder con la operacion.
                    if (listadoEncuestaKobo.Count > 0)
                    {
                        foreach (var item in listadoEncuestaKobo)
                        {
                            //Vamos a averiguar si la encuesta ya existe para actualizalo, caso contrario lo insertamos
                            var resp = await _mediator.Send(new GetEncuestaKobosByIdQuery() { Id = item.Id });
                            if (resp.Succeeded)
                            {
                                var updateEntidadCommand = _mapper.Map<UpdateEncuestaKoboCommand>(item);
                                var result = await _mediator.Send(updateEntidadCommand);
                            }
                            else
                            {
                                var createEntidadCommand = _mapper.Map<CreateEncuestaKoboCommand>(item);
                                var result = await _mediator.Send(createEntidadCommand);
                            }
                        }

                        //Una vez terminada la operación de inserción o edición, se va a leer todos los registros nuevamente
                        //para mostrar un listado actualizado al usuario
                        var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                        if (response.Succeeded)
                        {
                            //Transformamos (mapeamos) el objeto que tiene los datos de GetAllEncuestaKobosResponse al modelo ViewModel
                            //GetAllEncuestaKobosResponse:  \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Queries\GetAllEncuestaKobosResponse.cs
                            //EncuestaKoboViewModel:        \WordVision.ec.Web\Areas\Encuesta\Models\EncuestaKoboViewModel.cs
                            var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);
                            var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                            return new JsonResult(new { isValid = true, html = html1 });
                        }
                    }
                    else
                    {
                        return new JsonResult(new { isValid = false });
                    }

                }
                //Retornamos el Id tanto si se insertó o se modificó
                return new JsonResult(new { isValid = true, Id = 0 });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostBatchCreateOrEdit", ex);
                _notify.Error("Error al insertar registros de Encuestas Kobo");
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            //Trae la información para llenar el formulario que va a ver el usuario para su inserción o edición.

            //Si el codigo del i = 0 entonces se parametrizara el formulario con la información para la inserción, 
            //en caso contrario se parametrizara para edición leyendo los datos del registro actuales.

            //Para llenar con informacion un combobox con informacion del catalogo 
            //var catalogo = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 21, Ninguno = true });
            //var formaPago = new SelectList(catalogo.Data, "Secuencia", "Nombre");

            if (id == 0)
            {
                //Vamos a INSERTAR un nuevo registro
                //Configuramos la clase ViewModel con datos predeterminados
                var entidadViewModel = new EncuestaKoboViewModel();

                //Si este ViewForm tendria una propiedad tipo select, asignamos la lista que se consultó arriba
                //entidadViewModel.FormaPagoList = formaPago;

                //Datos por default de los campos
                //entidadViewModel.FechaConversion = DateTime.Now;

                //Pasamos la info al formulario
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
            }
            else
            {
                //Vamos a EDITAR un registro existente

                //Consultamos el DETALLE del registro de la base utilizando las funciones definidas
                //en \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Queries\GetEncuestaKobosByIdQuery.cs
                var response = await _mediator.Send(new GetEncuestaKobosByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    //Transformamos del modelo GetEncuestaKobosByIdResponse (que es igual al modelo de la base de datos) al modelo ViewModel
                    //El objeto GetEncuestaKobosByIdResponse esta definido en \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Queries\GetEncuestaKobosByIdQuery.cs
                    //Para que haga bien la transformacion (mapeo), es necesario que las propiedades se llamen igual.
                    var entidadViewModel = _mapper.Map<EncuestaKoboViewModel>(response.Data);

                    //Si este ViewForm tendria una propiedad tipo select, asignamos la lista que se consultó arriba
                    //entidadViewModel.FormaPagoList = formaPago;

                    //Pasamos la info al formulario
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", entidadViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int? id, EncuestaKoboViewModel entidad)
        {
            //Funcion que va a actualizar la base de datos tanto para insercion o edicion 

            //En el objeto entidad estan los datos que ingresó el usuario por el formulario de pantalla.
            try
            {
                //Si pasaron todas las validaciones en pantalla, entonces proceder con la operacion.
                if (ModelState.IsValid)
                {
                    //Si en el formulario existió un campo para la carga de un archivo,
                    //entonces asignamos el contenido de ese archivo en una propiedad del objeto entidad
                    //y así enviar los bytes requeridos a la base de datos para su almacenamiento.
                    //if (Request.Form.Files.Count > 0)
                    //{
                    //    IFormFile file = Request.Form.Files.FirstOrDefault();
                    //    var image = file.OpenReadStream();
                    //    MemoryStream ms = new MemoryStream();
                    //    image.CopyTo(ms);
                    //    entidad.EvidenciaConversion = ms.ToArray();
                    //}

                    if (id == 0)
                    {
                        //Para INSERCION de un nuevo registro
                        //Transformamos el objeto entidad que es de tipo ViewModel al objeto de tipo CreateEncuestaKoboCommand
                        //que esta definido en \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Commands\CreateEncuestaKoboCommand.cs
                        var createEntidadCommand = _mapper.Map<CreateEncuestaKoboCommand>(entidad);

                        //Enviamos a ejecutar la funcion para insercion que esta definido en la variable createEntidadCommand que es de tipo CreateEncuestaKoboCommand
                        var result = await _mediator.Send(createEntidadCommand);
                        if (result.Succeeded)
                        {
                            //La funcion de crear registro devuelve el nuevo ID
                            id = result.Data;
                            _notify.Success($"Encuesta Kobo con ID {result.Data} Creado.");

                            //Enviamos una alerta de que se creó el registro
                            //await EnviarMail(result.Data, 1);
                        }
                        else _notify.Error(result.Message);
                    }
                    else
                    {
                        //Para EDICION de un registro existente
                        //Transformamos el objeto entidad que es de tipo ViewModel al objeto de tipo UpdateEncuestaKoboCommand
                        //que esta definido en \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Commands\UpdateEncuestaKoboCommand.cs
                        var updateEntidadCommand = _mapper.Map<UpdateEncuestaKoboCommand>(entidad);

                        //Enviamos a ejecutar la funcion para actualizar que esta definido en la variable updateEntidadCommand que es de tipo CreateEncuestaKoboCommand
                        var result = await _mediator.Send(updateEntidadCommand);
                        if (result.Succeeded) _notify.Information($"EncuestaKobo con ID {result.Data} Actualizado.");

                        //Enviamos una alerta de que se actualizó el registro
                        //await EnviarMail(result.Data, 2);
                    }

                    //Una vez terminada la operación de inserción o edición, se va a leer todos los registros nuevamente
                    //para mostrar un listado actualizado al usuario
                    var response = await _mediator.Send(new GetAllEncuestaKobosQuery());
                    if (response.Succeeded)
                    {
                        //Transformamos (mapeamos) el objeto que tiene los datos de GetAllEncuestaKobosResponse al modelo ViewModel
                        //GetAllEncuestaKobosResponse:  \WordVision.ec.Application\Features\Encuesta\EncuestaKobos\Queries\GetAllEncuestaKobosResponse.cs
                        //EncuestaKoboViewModel:        \WordVision.ec.Web\Areas\Encuesta\Models\EncuestaKoboViewModel.cs
                        var viewModel = _mapper.Map<List<EncuestaKoboViewModel>>(response.Data);

                        var html1 = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                        return new JsonResult(new { isValid = true, html = html1 });
                    }


                }
                else
                {
                    return new JsonResult(new { isValid = false });
                }

                //Retornamos el Id tanto si se insertó o se modificó
                return new JsonResult(new { isValid = true, Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError("OnPostCreateOrEdit", ex);
                _notify.Error("Error al insertar el EncuestaKobo");
            }
            return null;
        }

        public async Task<FileResult> ShowPDF(int id, int tipo)
        {
            //Consultamos la informacion de detalle del registro
            var responseC = await _mediator.Send(new GetEncuestaKobosByIdQuery() { Id = id });
            if (responseC.Succeeded)
            {
                //Transformamos de GetEncuestaKobosByIdQuery a EncuestaKoboViewModel
                var entidadViewModel = _mapper.Map<EncuestaKoboViewModel>(responseC.Data);

                //byte[] dataArray = entidadViewModel.EvidenciaConversion;
                //return File(dataArray, "application/pdf");
            }

            return null;
        }

        public async Task<ActionResult> EnviarMail(int idEncuestaKobo, int estado)
        {
            //Configurar este método de acuerdo a las necesidades.

            DateTime fechaEnvio = DateTime.Now;
            string primerNombre = "";
            string segundoNombre = "";
            string primerApellido = "";
            string segundoApellido = "";
            string fechaConversion = "";
            string comentario = "";
            string comentarioResponsable = "";
            string email = "";
            string celular = "";
            string responsable = "";
            string emailResponsable = "";

            ////try
            ////{
            ////    //Consultamos la informacion de detalle del registro
            ////    var response = await _mediator.Send(new GetEncuestaKobosByIdQuery() { Id = idEncuestaKobo });
            ////    if (response.Succeeded)
            ////    {
            ////        primerNombre = response.Data.Nombre1;
            ////        segundoNombre = response.Data.Nombre2;
            ////        primerApellido = response.Data.Apellido1;
            ////        segundoApellido = response.Data.Apellido2;
            ////        fechaConversion = response.Data.FechaConversion.ToString();
            ////        email = response.Data.Email;
            ////        celular = response.Data.TelefonoCelular;
            ////        comentario = response.Data.ComentarioActualizacion;
            ////        comentarioResponsable = response.Data.ComentarioResolucion;
            ////        responsable = response.Data.CreatedBy;
            ////    }

            ////    var responseC = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = responsable });
            ////    if (responseC.Succeeded)
            ////    {
            ////        emailResponsable = responseC.Data.Email;
            ////        responsable = responseC.Data.PrimerNombre + " " + responseC.Data.Apellidos;
            ////    }

            ////    string plantilla = "";
            ////    string asunto = "";
            ////    switch (estado)
            ////    {

            ////        case 1:
            ////            plantilla = "EncuestaKobos\\Nuevo.html";
            ////            asunto = "Ingreso de nuevo EncuestaKobo: " + primerNombre + " " + primerApellido;
            ////            email = _configuration["DestinoEncuestaKobo"];
            ////            break;
            ////        case 2:
            ////            plantilla = "EncuestaKobos\\Devolucion.html";
            ////            email = emailResponsable;
            ////            asunto = "Realizar cambios en la información del EncuestaKobo " + primerNombre + " " + primerApellido;
            ////            break;
            ////        case 3:
            ////            plantilla = "EncuestaKobos\\Realizacion.html";
            ////            asunto = "Confirmación de cambios realizados " + primerNombre + " " + primerApellido;
            ////            email = _configuration["DestinoEncuestaKobo"];
            ////            comentario = comentarioResponsable;
            ////            break;



            ////    }

            ////    //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html  
            ////    var pathToFile = _env.WebRootPath
            ////            + Path.DirectorySeparatorChar.ToString()
            ////            + "Templates"
            ////            + Path.DirectorySeparatorChar.ToString()
            ////            + "EmailTemplate"
            ////            + Path.DirectorySeparatorChar.ToString()
            ////            + plantilla;


            ////    var builder = new BodyBuilder();
            ////    using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            ////    {
            ////        builder.HtmlBody = SourceReader.ReadToEnd();
            ////    }


            ////    string messageBody = string.Format(builder.HtmlBody,
            ////        String.Format("{0:dddd, d MMMM yyyy}", fechaConversion),
            ////        primerNombre + " " + segundoNombre + " " + primerApellido + " " + segundoApellido,
            ////        email,
            ////        celular,
            ////        responsable,
            ////        comentario,
            ////        String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now)
            ////        );


            ////    await _emailSender
            ////        .SendEmailAsync(email, asunto, messageBody)
            ////        .ConfigureAwait(false);


            ////    _notify.Success($"Mail Enviado.");


            ////}
            ////catch (Exception ex)
            ////{
            ////    _logger.LogError(ex, $"Error en enviar Mail.");
            ////}

            //   return new JsonResult(new { isValid = true });
            // return RedirectToPage("/Wizard/Index", new { area = "Registro" });
            return null;
        }

    }
}
