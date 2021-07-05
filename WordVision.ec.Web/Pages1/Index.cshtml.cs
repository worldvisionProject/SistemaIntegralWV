using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById;
using WordVision.ec.Web.Areas.Identity.Models;
using Microsoft.Extensions.DependencyInjection;
using WordVision.ec.Web.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Services;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;

namespace WordVision.ec.Web.Pages
{
    [AllowAnonymous]
    public class IndexModel : BasePageModel<IndexModel>
    {
       
        private readonly IMediator _mediator;
        //private readonly MyDataClientService _myDataClientService;
        //public List<string> DataFromApi;
        public IndexModel( IMediator mediator)
        {
            //_myDataClientService = myDataClientService;
              _mediator = mediator;
        }

        /// <summary>
        /// Gets or sets login model property.
        /// </summary>
        [BindProperty]
        public UsuarioViewModel LoginModel { get; set; }


        #region On Get method.
        //public async Task OnGetAsync()
        //{
        //    //DataFromApi = await _myDataClientService.GetMyData();
        //}


        /// <summary>
        /// GET: /Index
        /// </summary>
        /// <returns>Returns - Appropriate page </returns>
        public IActionResult OnGet()
        {
            try
            {
                // Verification.
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.
                    //if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value.ToUpper() == "PANGOS")
                    //    return this.RedirectToPage("/Areas/Dashboard/Views/Registro/Index");
                    //else
                        return this.RedirectToPage("/Home/Index");
                   // return this.RedirectToPage("/Home/Dashboard");
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.Page();
        }

        #endregion


        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    string usrname = Environment.UserDomainName;
                    var loginInfo = await _mediator.Send(new GetUsuarioByIdQuery() { Id = LoginModel.UserNameRegular });
                    if (loginInfo != null)
                    {
                        // Initialization.
                        var logindetails = loginInfo.Data;

                        int idColabora = 0;

                        var response = await _mediator.Send(new GetColaboradorByIdentificacionQuery() { Identificacion = logindetails.Cedula });
                        if (response.Succeeded)
                        {
                            var colaborador = response.Data;
                            
                            if (colaborador == null)
                            {

                                var userInfo = await _mediator.Send(new CreateColaboradorCommand()
                                {
                                    Id = 0,
                                    Apellidos = logindetails.ApellidoPaterno??"DEBE ACTUALIZAR DATOS",
                                    ApellidoMaterno = logindetails.ApellidoMaterno ?? "DEBE ACTUALIZAR DATOS",
                                    Identificacion = logindetails.Cedula ?? "DEBE ACTUALIZAR DATOS",
                                    Email = logindetails.Mail ?? "DEBE ACTUALIZAR DATOS",
                                    Cargo = logindetails.Title ?? "DEBE ACTUALIZAR DATOS",
                                    Area = logindetails.Department ?? "DEBE ACTUALIZAR DATOS",
                                    LugarTrabajo = logindetails.PhysicalDeliveryOfficeName ?? "DEBE ACTUALIZAR DATOS",
                                    PrimerNombre = logindetails.PrimerNombre ?? "DEBE ACTUALIZAR DATOS",
                                    SegundoNombre = logindetails.SegundoNombre ?? "DEBE ACTUALIZAR DATOS"

                                });
                                
                                if (userInfo == null)
                                {
                                    _notyf.Error("No se insertaron los datos del colaborador.");

                                    ModelState.AddModelError(string.Empty, "No se insertaron los datos del colaborador.");
                                }
                                else
                                {
                                     idColabora = userInfo.Data;
                                    var formulario = await _mediator.Send(new CreateFormularioCommand()
                                    {
                                        IdColaborador= idColabora,
                                        FechaNacimiento=DateTime.Now,
                                        VigenciaDesde = DateTime.Now,
                                        VigenciaHasta = DateTime.Now,
                                        FamiliaPorcentajeDiscapacidad=0,
                                        PorcentajeDiscapacidad=0,
                                        PorcentajeEscrito=0,
                                        PorcentajeHablado=0
                                    });

                                    if (formulario == null)
                                    {
                                        _notyf.Error("No se insertaron los datos del formulario.");

                                        ModelState.AddModelError(string.Empty, "No se insertaron los datos del formulario.");
                                    }
                                }
                               
                            }
                            else
                            {
                                idColabora = colaborador.Id;
                                logindetails.ApellidoMaterno = colaborador.ApellidoMaterno;
                                logindetails.ApellidoPaterno = colaborador.Apellidos;
                                logindetails.PrimerNombre = colaborador.PrimerNombre;
                                logindetails.SegundoNombre = colaborador.SegundoNombre;
                            }
                               


                            // Login In.
                            await this.SignInUser(idColabora.ToString(), logindetails, false);

                            _notyf.Success($"Ingreso como {logindetails.DisplayName}.");
                            // Info.

                           
                            //if(logindetails.UserNameRegular.ToUpper()== "PANGOS")
                            //return this.RedirectToPage("/Areas/Dashboard/Views/Registro/Index");
                            //else
                                return this.RedirectToPage("/Home/Index");
                        }

                       
                    }
                    else
                    {
                      
                            _notyf.Error("Usuario Invalido.");
                         
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                _notyf.Error("Usuario Invalido.");
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.Page();
        }

        #region Helpers

        #region Sign In method.

        /// <summary>
        /// Sign In User method.
        /// </summary>
        /// <param name="username">Username parameter.</param>
        /// <param name="isPersistent">Is persistent parameter.</param>
        /// <returns>Returns - await task</returns>
        private async Task SignInUser(string id,GetUsuarioByIdResponse username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                
                claims.Add(new Claim(ClaimTypes.Name, username.UserNameRegular));
                claims.Add(new Claim(ClaimTypes.Email, username.Mail));
                claims.Add(new Claim(ClaimTypes.Locality, username.PhysicalDeliveryOfficeName));
                claims.Add(new Claim("DisplayName", username.DisplayName));
                claims.Add(new Claim("Cargo", username.Title));
                claims.Add(new Claim("Jefe", username.Manager));
                claims.Add(new Claim("Gerencia", username.Company));
                claims.Add(new Claim("Departamento", username.Department));
                claims.Add(new Claim("Cedula", username.Cedula));
                claims.Add(new Claim("Id", id));
                claims.Add(new Claim("Apellidos", username.ApellidoPaterno+" "+username.ApellidoMaterno));
                claims.Add(new Claim("Nombres", username.PrimerNombre + " " + username.SegundoNombre));
                claims.Add(new Claim("ApellidosNombres", username.ApellidoPaterno + " " + username.ApellidoMaterno + " " + username.PrimerNombre + " " + username.SegundoNombre));


                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        #endregion

        #endregion

    }
}
