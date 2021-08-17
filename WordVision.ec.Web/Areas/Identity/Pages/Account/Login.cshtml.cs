using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WordVision.ec.Application.Enums;
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById;
using WordVision.ec.Application.Features.Logs.Commands.AddActivityLog;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Services;

namespace WordVision.ec.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : BasePageModel<LoginModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IMediator _mediator;

        // private readonly IdentityWindowsService _identityWindowsService;
        public LoginModel(SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager, IMediator mediator)//, IdentityWindowsService identityWindowsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mediator = mediator;

            //   _identityWindowsService = identityWindowsService;


        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            //[EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Recordarme?")]
            public bool RememberMe { get; set; }


            public string UsuarioAd { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string proveedor = null, string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                if (ModelState.IsValid)
                {
                    var userName = Input.Email;

                    var response = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = userName });
                    if (response != null)
                    {
                        if (response.Succeeded)
                        {
                            var output = response.Data;
                            var colaborador = new GetUsuarioByIdResponse();
                            colaborador.ApellidoPaterno = output.Apellidos;
                            colaborador.PrimerNombre = output.PrimerNombre;
                            colaborador.Mail = output.Email;
                            colaborador.Cedula = output.Identificacion;
                            colaborador.IdEmpresa = 3;
                            var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 6 });
                            colaborador.Department = cat1.Data.Where(c => c.Secuencia == output.Cargo.ToString()).FirstOrDefault().Nombre;
                            cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 8 });
                            colaborador.PhysicalDeliveryOfficeName = cat1.Data.Where(c => c.Secuencia == output.Area.ToString()).FirstOrDefault().Nombre;

                            var defaultUser = new ApplicationUser
                            {
                                UserName = userName,
                                Email = colaborador.Mail,
                                FirstName = colaborador.PrimerNombre + " " + colaborador.SegundoNombre,
                                LastName = colaborador.ApellidoPaterno + " " + colaborador.ApellidoMaterno,
                                EmailConfirmed = true,
                                PhoneNumberConfirmed = true,
                                IsActive = true,
                                IdEmpresa = 1
                            };

                            if (_userManager.Users.All(u => u.Id != defaultUser.Id))
                            {
                                var userExterno = await _userManager.FindByEmailAsync(defaultUser.Email);
                                if (userExterno == null)
                                {
                                    await _userManager.CreateAsync(defaultUser, "123Pa$$word!");
                                    await _userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                                }

                            }

                            var users = await _userManager.FindByNameAsync(userName);
                            await AddUserClaims(users, userName, colaborador);

                            var result1 = await _signInManager.PasswordSignInAsync(userName, "123Pa$$word!", false, lockoutOnFailure: false);
                            if (result1.Succeeded)
                            {

                                await _mediator.Send(new AddActivityLogCommand() { userId = users.Id, Action = "Logged In" });
                                _logger.LogInformation("Usuario conectado.");
                                _notyf.Success($"Conectado como { userName }.");
                                return LocalRedirect(returnUrl);
                            }

                        }
                    }



                    if (IsValidEmail(Input.Email))
                    {
                        var userCheck = await _userManager.FindByEmailAsync(Input.Email);
                        if (userCheck != null)
                        {
                            userName = userCheck.UserName;
                        }
                    }
                    var logindetails = new GetUsuarioByIdResponse();
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user != null)
                    {
                        if (!user.IsActive)
                        {
                            return RedirectToPage("./Deactivated");
                        }
                        else if (!user.EmailConfirmed)
                        {
                            _notyf.Error("Correo electrónico no confirmado.");
                            ModelState.AddModelError(string.Empty, "Correo electrónico no confirmado.");
                            return Page();
                        }
                        else
                        {
                            try
                            {
                                logindetails = GetDataActive(userName);
                                var responseC = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = userName });
                                if (responseC != null)
                                {
                                    if (responseC.Succeeded)
                                    {
                                        var output = responseC.Data;
                                        var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 6 });
                                        logindetails.Department = cat1.Data.Where(c => c.Secuencia == output.Cargo.ToString()).FirstOrDefault().Nombre;
                                        cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 8 });
                                        logindetails.PhysicalDeliveryOfficeName = cat1.Data.Where(c => c.Secuencia == output.Area.ToString()).FirstOrDefault().Nombre;
                                    }
                                }
                            }
                            catch
                            {
                                logindetails.ApellidoPaterno = user.LastName;
                                logindetails.PrimerNombre = user.FirstName;
                                logindetails.Mail = user.Email;
                                logindetails.Cedula = "000" + userName;
                                logindetails.IdEmpresa = 0;
                                logindetails.Department = "NA";
                                logindetails.PhysicalDeliveryOfficeName = "NA";
                            }
                            //if (logindetails != null)
                            //{
                            //    logindetails = logindetails.Data;
                            //}
                            //else
                            //{

                            //    logindetails.ApellidoPaterno = user.LastName;
                            //    logindetails.PrimerNombre = user.FirstName;
                            //    logindetails.Mail = user.Email;
                            //    logindetails.Cedula = "000" + userName;
                            //    logindetails.IdEmpresa = 0;
                            //}

                            if (logindetails == null)
                            {
                                logindetails = new GetUsuarioByIdResponse();
                                logindetails.ApellidoPaterno = user.LastName;
                                logindetails.PrimerNombre = user.FirstName;
                                logindetails.Mail = user.Email;
                                logindetails.Cedula = "000" + userName;
                                logindetails.IdEmpresa = 0;
                            }
                            await AddUserClaims(user, userName, logindetails);



                            var result = await _signInManager.PasswordSignInAsync(userName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                            if (result.Succeeded)
                            {

                                await _mediator.Send(new AddActivityLogCommand() { userId = user.Id, Action = "Logged In" });
                                _logger.LogInformation("Usuario conectado.");
                                _notyf.Success($"Conectado como { userName}.");
                                return LocalRedirect(returnUrl);
                                //return this.RedirectToPage("./Main");
                            }
                            await _mediator.Send(new AddActivityLogCommand() { userId = user.Id, Action = "Log-In Failed" });
                            if (result.RequiresTwoFactor)
                            {
                                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                            }
                            if (result.IsLockedOut)
                            {
                                _notyf.Warning("Cuenta de usuario bloqueada.");
                                _logger.LogWarning("Cuenta de usuario bloqueada.");
                                return RedirectToPage("./Lockout");
                            }
                            else
                            {
                                _notyf.Error("Intento de inicio de sesión no válido.");
                                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");

                                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                                ReturnUrl = returnUrl;

                                return Page();
                            }
                        }
                    }
                    else
                    {
                        _notyf.Error("Correo electrónico / nombre de usuario no encontrado.");
                        ModelState.AddModelError(string.Empty, "Correo electrónico / nombre de usuario no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                ReturnUrl = returnUrl;
                _notyf.Error("Intento de inicio de sesión no válido.");
                _logger.LogError("Intento de inicio de sesión no válido.", ex);

            }
            // If we got this far, something failed, redisplay form
            return Page();
        }


        public async Task<IActionResult> OnPostLogInWin(string returnUrl = null)
        {
            try
            {
                //  return RedirectToAction("Challenge", "Windows", new { Area = "Identity", returnUrl = returnUrl });
                //  return await ChallengeWindowsAsync(returnUrl);
                // see if windows auth has already been requested and succeeded
                var result = await HttpContext.AuthenticateAsync("Windows");
                if (result?.Principal is WindowsPrincipal wp)
                {
                    // we will issue the external cookie and then redirect the
                    // user back to the external callback, in essence, treating windows
                    // auth the same as any other external authentication mechanism
                    var props = new AuthenticationProperties()
                    {
                        RedirectUri = Url.Action("Index", "Usuario"),
                        Items =
                                {
                                    { "returnUrl", returnUrl },
                                    { "scheme", "Windows" },
                                }
                    };

                    string usrname = wp.Identity.Name.Split((char)92)[1];

                    var logindetails = GetDataActive(usrname);
                    var responseC = await _mediator.Send(new GetColaboradorByUserNameQuery() { UserName = usrname });
                    if (responseC != null)
                    {
                        if (responseC.Succeeded)
                        {
                            var output = responseC.Data;
                            var cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 6 });
                            logindetails.Department = cat1.Data.Where(c => c.Secuencia == output.Cargo.ToString()).FirstOrDefault().Nombre;
                            cat1 = await _mediator.Send(new GetListByIdDetalleQuery() { Id = 8 });
                            logindetails.PhysicalDeliveryOfficeName = cat1.Data.Where(c => c.Secuencia == output.Area.ToString()).FirstOrDefault().Nombre;
                        }
                    }
                    else
                    {
                        logindetails.Department = "NA";
                        logindetails.PhysicalDeliveryOfficeName = "NA";
                    }
                    var defaultUser = new ApplicationUser
                    {
                        UserName = logindetails.UserNameRegular,
                        Email = logindetails.Mail,
                        FirstName = logindetails.PrimerNombre + " " + logindetails.SegundoNombre,
                        LastName = logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        IsActive = true,
                        IdEmpresa = 1
                    };

                    if (_userManager.Users.All(u => u.Id != defaultUser.Id))
                    {
                        var user = await _userManager.FindByEmailAsync(defaultUser.Email);
                        if (user == null)
                        {
                            await _userManager.CreateAsync(defaultUser, "123Pa$$word!");
                            await _userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                            //await _userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                            //await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                            //await _userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                        }

                    }

                    var users = await _userManager.FindByNameAsync(usrname);
                    await AddUserClaims(users, usrname, logindetails);

                    var result1 = await _signInManager.PasswordSignInAsync(usrname, "123Pa$$word!", false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {

                        await _mediator.Send(new AddActivityLogCommand() { userId = users.Id, Action = "Logged In" });
                        _logger.LogInformation("Usuario conectado.");
                        _notyf.Success($"Conectado como { wp.Identity.Name.Split((char)92)[1] }.");
                        //return LocalRedirect(returnUrl);
                        return LocalRedirect(returnUrl);
                    }


                }
                else
                {
                    // trigger windows auth
                    // since windows auth don't support the redirect uri,
                    // this URL is re-triggered when we call challenge
                    return Challenge("Windows");
                }
            }
            catch (Exception ex)
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                ReturnUrl = returnUrl;
            }
            return this.Page();
        }

        public async Task<IActionResult> OnPostLogIn(string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                var logindetails = new GetUsuarioByIdResponse();
                //try
                //{
                //  //  var identityWindows = await _identityWindowsService.GetUserWindows(Input.UsuarioAd);
                //}
                //catch
                //{
                if (ModelState.IsValid)
                {
                    var loginInfo = logindetails;// await _mediator.Send(new GetUsuarioByIdQuery() { Id = Input.UsuarioAd });
                    if (loginInfo != null)
                    {
                        //logindetails = loginInfo.Data;
                    }
                    else
                    {
                        _notyf.Error("Usuario no encontrado en la empresa.");
                        return this.Page();
                        //ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
                else
                    return this.Page();
                // }
                var defaultUser = new ApplicationUser
                {
                    UserName = logindetails.UserNameRegular,
                    Email = logindetails.Mail,
                    FirstName = logindetails.PrimerNombre + " " + logindetails.SegundoNombre,
                    LastName = logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsActive = true,
                    IdEmpresa = 1
                };
                if (_userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await _userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {

                        await _userManager.CreateAsync(defaultUser, "123Pa$$word!");
                        //await _userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                        //await _userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                        //await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                        //await _userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                    }

                }
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
                            Apellidos = logindetails.ApellidoPaterno ?? "DEBE ACTUALIZAR DATOS",
                            ApellidoMaterno = logindetails.ApellidoMaterno ?? "DEBE ACTUALIZAR DATOS",
                            Identificacion = logindetails.Cedula ?? "DEBE ACTUALIZAR DATOS",
                            Email = logindetails.Mail ?? "DEBE ACTUALIZAR DATOS",
                            //Cargo = logindetails.Title ?? "DEBE ACTUALIZAR DATOS",
                            //Area = logindetails.Department ?? "DEBE ACTUALIZAR DATOS",
                            //LugarTrabajo = logindetails.PhysicalDeliveryOfficeName ?? "DEBE ACTUALIZAR DATOS",
                            PrimerNombre = logindetails.PrimerNombre ?? "DEBE ACTUALIZAR DATOS",
                            SegundoNombre = logindetails.SegundoNombre ?? "DEBE ACTUALIZAR DATOS"

                        });

                        if (userInfo == null)
                        {
                            _notyf.Error("No se insertaron los datos del colaborador.");
                        }
                        else
                        {
                            idColabora = userInfo.Data;
                            var formulario = await _mediator.Send(new CreateFormularioCommand()
                            {
                                IdColaborador = idColabora,
                                FechaNacimiento = DateTime.Now,
                                VigenciaDesde = DateTime.Now,
                                VigenciaHasta = DateTime.Now,
                                FamiliaPorcentajeDiscapacidad = 0,
                                PorcentajeDiscapacidad = 0,
                                PorcentajeEscrito = 0,
                                PorcentajeHablado = 0
                            });

                            if (formulario == null)
                            {
                                _notyf.Error("No se insertaron los datos del formulario.");
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
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, logindetails.UserNameRegular));
                    claims.Add(new Claim(ClaimTypes.Email, logindetails.Mail));
                    claims.Add(new Claim(ClaimTypes.Locality, logindetails.PhysicalDeliveryOfficeName));
                    claims.Add(new Claim("DisplayName", logindetails.DisplayName));
                    //claims.Add(new Claim("Cargo", logindetails.Title));
                    //claims.Add(new Claim("Jefe", logindetails.Manager));
                    //claims.Add(new Claim("Gerencia", logindetails.Company));
                    //claims.Add(new Claim("Departamento", logindetails.Department));
                    claims.Add(new Claim("Cedula", logindetails.Cedula));
                    claims.Add(new Claim("Id", idColabora.ToString()));
                    //claims.Add(new Claim("Apellidos", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno));
                    //claims.Add(new Claim("Nombres", logindetails.PrimerNombre + " " + logindetails.SegundoNombre));
                    //claims.Add(new Claim("ApellidosNombres", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno + " " + logindetails.PrimerNombre + " " + logindetails.SegundoNombre));


                    //var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                    //var authenticationManager = Request.HttpContext;

                    // Sign In.
                    //await Request.HttpContext.SignInAsync(
                    //    "WordlVision",
                    //    claimPrincipal);
                    await _signInManager.SignInWithClaimsAsync(defaultUser, new AuthenticationProperties() { IsPersistent = false }, claims);

                    var result = await _signInManager.PasswordSignInAsync(logindetails.UserNameRegular, "123Pa$$word!", Input.RememberMe, lockoutOnFailure: false);
                    //if (result.Succeeded)
                    //{
                    //await _mediator.Send(new AddActivityLogCommand() { userId = logindetails.UserNameRegular, Action = "Logged In" });
                    //  _logger.LogInformation("User logged in.");
                    _notyf.Success($"Ingreso como {logindetails.DisplayName}.");
                    // return LocalRedirect(returnUrl);
                    //}

                    //await this.SignInUser(idColabora.ToString(), logindetails, false);

                    // _notyf.Success($"Ingreso como {logindetails.DisplayName}.");
                    // Info.


                    //if(logindetails.UserNameRegular.ToUpper()== "PANGOS")
                    //return this.RedirectToPage("/Areas/Dashboard/Views/Registro/Index");
                    //else
                    // return LocalRedirect(returnUrl);
                    if (logindetails.UserNameRegular.ToUpper() == "MROMAN")
                        return this.RedirectToPage("./Redirect");
                    else
                        //return this.RedirectToPage("./Main");
                        return LocalRedirect(returnUrl);
                    //return this.RedirectToPage("/Areas/Planificacion/Views/AnioFiscal/Index");
                }


            }
            catch (Exception ex)
            {
                _notyf.Error("Usuario Invalido.");
                _logger.LogError("Usuario Invalido", ex);
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                ReturnUrl = returnUrl;
            }

            // Info.
            return this.Page();
        }

        #region Helpers

        #region Sign In method.

        private async Task AddUserClaims(ApplicationUser user, string idUsername, GetUsuarioByIdResponse logindetails)
        {

            int idColabora = 0;

            var response = await _mediator.Send(new GetColaboradorByIdentificacionQuery() { Identificacion = logindetails.Cedula });
            if (response != null)
            {
                if (response.Succeeded)
                {
                    var colaborador = response.Data;

                    if (colaborador.Email == null)
                    {

                        var userInfo = await _mediator.Send(new CreateColaboradorCommand()
                        {
                            Id = 0,
                            Apellidos = logindetails.ApellidoPaterno ?? "DEBE ACTUALIZAR DATOS",
                            ApellidoMaterno = logindetails.ApellidoMaterno ?? "DEBE ACTUALIZAR DATOS",
                            Identificacion = logindetails.Cedula ?? "DEBE ACTUALIZAR DATOS",
                            Email = logindetails.Mail ?? "DEBE ACTUALIZAR DATOS",
                            PrimerNombre = logindetails.PrimerNombre ?? "DEBE ACTUALIZAR DATOS",
                            SegundoNombre = logindetails.SegundoNombre ?? "DEBE ACTUALIZAR DATOS",
                            Alias = idUsername

                        });

                        if (userInfo == null)
                        {
                            _notyf.Error("No se insertaron los datos del colaborador.");
                        }
                        else
                        {
                            idColabora = userInfo.Data;
                            var formulario = await _mediator.Send(new CreateFormularioCommand()
                            {
                                IdColaborador = idColabora,
                                FechaNacimiento = DateTime.Now,
                                VigenciaDesde = DateTime.Now,
                                VigenciaHasta = DateTime.Now,
                                FamiliaPorcentajeDiscapacidad = 0,
                                PorcentajeDiscapacidad = 0,
                                PorcentajeEscrito = 0,
                                PorcentajeHablado = 0
                            });

                            if (formulario == null)
                            {
                                _notyf.Error("No se insertaron los datos del formulario.");
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
                        logindetails.Nivel = colaborador.Estructuras?.Nivel ?? 0;
                        logindetails.ReportaA = colaborador.CodReportaA;
                        logindetails.IdEmpresa = colaborador.Estructuras?.Empresas.Id ?? 3;

                        var responsef = await _mediator.Send(new GetFormularioByIdQuery() { Id = idColabora });
                        if (responsef.Succeeded)
                        {
                            if (responsef.Data == null)
                            {
                                var formulario = await _mediator.Send(new CreateFormularioCommand()
                                {
                                    IdColaborador = idColabora,
                                    FechaNacimiento = DateTime.Now,
                                    VigenciaDesde = DateTime.Now,
                                    VigenciaHasta = DateTime.Now,
                                    FamiliaPorcentajeDiscapacidad = 0,
                                    PorcentajeDiscapacidad = 0,
                                    PorcentajeEscrito = 0,
                                    PorcentajeHablado = 0
                                });

                                if (formulario == null)
                                {
                                    _notyf.Error("No se insertaron los datos del formulario.");
                                }
                            }

                        }


                    }
                }

            }
            else
            {
                idColabora = 0;
                logindetails.ApellidoMaterno = "SN";
                logindetails.ApellidoPaterno = "SN";
                logindetails.PrimerNombre = "SN";
                logindetails.SegundoNombre = "SN";
            }


            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting

                // claims.Add(new Claim(ClaimTypes.Name, logindetails.UserNameRegular));
                claims.Add(new Claim(ClaimTypes.Email, logindetails.Mail));
                claims.Add(new Claim("Cargo", logindetails.Department));
                claims.Add(new Claim("Area", logindetails.PhysicalDeliveryOfficeName));
                claims.Add(new Claim("Cedula", logindetails.Cedula));
                claims.Add(new Claim("Id", idColabora.ToString()));
                claims.Add(new Claim("IdEmpresa", logindetails.IdEmpresa.ToString()));
                claims.Add(new Claim("Nivel", logindetails.Nivel.ToString()));
                claims.Add(new Claim("ReportaA", logindetails.ReportaA.ToString()));
                // await _signInManager.SignInWithClaimsAsync(user, new AuthenticationProperties() { IsPersistent = false }, claims);

                var result = await _userManager.RemoveClaimsAsync(user, claims);

                // Sign In.
                await _userManager.AddClaimsAsync(user, claims);
            }
            catch (Exception ex)
            {
                // Info
                _logger.LogError("Error autenticarse", ex);
            }
        }



        #endregion

        #endregion

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public GetUsuarioByIdResponse GetDataActive(string usrname)
        {
            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
            var defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value;

            //--- Code to use the current address for the LDAP and query it for the user---                  
            DirectorySearcher dssearch = new DirectorySearcher("LDAP://" + defaultNamingContext);
            dssearch.Filter = "(sAMAccountName=" + usrname + ")";
            SearchResult sresult = dssearch.FindOne();

            var logindetails = new GetUsuarioByIdResponse();
            if (sresult != null)
            {
                DirectoryEntry dsresult = sresult.GetDirectoryEntry();

                logindetails.PrimerNombre = dsresult.Properties["givenName"][0] == null ? usrname : dsresult.Properties["givenName"][0].ToString();
                logindetails.ApellidoPaterno = dsresult.Properties["sn"][0] == null ? usrname : dsresult.Properties["sn"][0].ToString();
                if (dsresult.Properties["mail"].Count > 0)
                    logindetails.Mail = dsresult.Properties["mail"][0] == null ? usrname : dsresult.Properties["mail"][0].ToString();
                else
                    logindetails.Mail = usrname;
                if (dsresult.Properties["HomePhone"].Count > 0)
                    logindetails.Cedula = dsresult.Properties["HomePhone"][0] == null ? "000" + usrname : dsresult.Properties["HomePhone"][0].ToString();
                else
                    logindetails.Cedula = "000" + usrname;

                logindetails.UserNameRegular = usrname;

            }
            else
            {
                logindetails.PrimerNombre = usrname;
                logindetails.ApellidoPaterno = usrname;
                logindetails.Mail = usrname;
                logindetails.Cedula = "000" + usrname;
                logindetails.UserNameRegular = usrname;
                logindetails.Department = "NA";
                logindetails.PhysicalDeliveryOfficeName = "NA";
            }

            return logindetails;

        }
    }

}