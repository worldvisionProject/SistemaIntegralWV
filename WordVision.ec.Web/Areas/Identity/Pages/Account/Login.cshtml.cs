using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById;
using WordVision.ec.Application.Features.Logs.Commands.AddActivityLog;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
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

            [Required]
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
            returnUrl = returnUrl ?? Url.Content("~/");
          
            if (ModelState.IsValid)
            {
                var userName = Input.Email;
                if (IsValidEmail(Input.Email))
                {
                    var userCheck = await _userManager.FindByEmailAsync(Input.Email);
                    if (userCheck != null)
                    {
                        userName = userCheck.UserName;
                    }
                }
               
                    var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    if (!user.IsActive)
                    {
                        return RedirectToPage("./Deactivated");
                    }
                    else if (!user.EmailConfirmed)
                    {
                        _notyf.Error("Email Not Confirmed.");
                        ModelState.AddModelError(string.Empty, "Email Not Confirmed.");
                        return Page();
                    }
                    else
                    {

                        //await AddUserClaims(user, userName);
                    
                        var result = await _signInManager.PasswordSignInAsync(userName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            //List<Claim> claims = new List<Claim>();
                            //claims.Add(new Claim("IdEmpresa", user.IdEmpresa.ToString()));
                            //await _userManager.AddClaimsAsync(user, claims);

                            await _mediator.Send(new AddActivityLogCommand() { userId = user.Id, Action = "Logged In" });
                            _logger.LogInformation("User logged in.");
                            _notyf.Success($"Logged in as {userName}.");
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
                            _notyf.Warning("User account locked out.");
                            _logger.LogWarning("User account locked out.");
                            return RedirectToPage("./Lockout");
                        }
                        else
                        {
                            _notyf.Error("Invalid login attempt.");
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return Page();
                        }
                    }
                }
                else
                {
                    _notyf.Error("Email / Username Not Found.");
                    ModelState.AddModelError(string.Empty, "Email / Username Not Found.");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        public async Task<IActionResult> OnPostLogInWin(string returnUrl = null)
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

                var logindetails = new GetUsuarioByIdResponse();
                if (ModelState.IsValid)
                {
                    var loginInfo = await _mediator.Send(new GetUsuarioByIdQuery() { Id = wp.Identity.Name.Split((char)92)[1] });
                    if (loginInfo != null)
                    {
                        logindetails = loginInfo.Data;
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

                var defaultUser = new ApplicationUser
                {
                    UserName = logindetails.UserNameRegular,
                    Email = logindetails.Mail,
                    FirstName = logindetails.PrimerNombre + " " + logindetails.SegundoNombre,
                    LastName = logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                    //IdEmpresa = 1
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
                            Cargo = logindetails.Title ?? "DEBE ACTUALIZAR DATOS",
                            Area = logindetails.Department ?? "DEBE ACTUALIZAR DATOS",
                            LugarTrabajo = logindetails.PhysicalDeliveryOfficeName ?? "DEBE ACTUALIZAR DATOS",
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
                }



                var id = new ClaimsIdentity("Windows");

                // the sid is a good sub value
                id.AddClaim(new Claim(JwtClaimTypes.Subject, wp.FindFirst(ClaimTypes.PrimarySid).Value));


                //Login In.

                id.AddClaim(new Claim(ClaimTypes.Name, logindetails.UserNameRegular));
                id.AddClaim(new Claim(ClaimTypes.Email, logindetails.Mail));
                id.AddClaim(new Claim(ClaimTypes.Locality, logindetails.PhysicalDeliveryOfficeName));
                id.AddClaim(new Claim("DisplayName", logindetails.DisplayName));
                //id.AddClaim(new Claim("Cargo", logindetails.Title));
                //id.AddClaim(new Claim("Jefe", logindetails.Manager));
                //id.AddClaim(new Claim("Gerencia", logindetails.Company));
                //id.AddClaim(new Claim("Departamento", logindetails.Department));
                id.AddClaim(new Claim("Cedula", logindetails.Cedula));
                id.AddClaim(new Claim("Id", idColabora.ToString()));
                id.AddClaim(new Claim("Apellidos", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno));
                id.AddClaim(new Claim("Nombres", logindetails.PrimerNombre + " " + logindetails.SegundoNombre));
                //id.AddClaim(new Claim("ApellidosNombres", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno + " " + logindetails.PrimerNombre + " " + logindetails.SegundoNombre));

                // the account name is the closest we have to a display name
                id.AddClaim(new Claim(JwtClaimTypes.Name, wp.Identity.Name));

                // add the groups as claims -- be careful if the number of groups is too large
                var wi = wp.Identity as WindowsIdentity;

                // translate group SIDs to display names
                var groups = wi.Groups.Translate(typeof(NTAccount));
                var roles = groups.Select(x => new Claim(JwtClaimTypes.Role, x.Value));
                id.AddClaims(roles);

                //claims.Add(id);
                //await _signInManager.SignInWithClaimsAsync(defaultUser, new AuthenticationProperties() { IsPersistent = false }, claims);

                //var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var claimPrincipal = new ClaimsPrincipal(claimIdenties);

                await Request.HttpContext.SignInAsync(
                    IdentityServerConstants.ExternalCookieAuthenticationScheme,
                    new ClaimsPrincipal(id),
                    props);
                return this.RedirectToPage("./Main");
            }
            else
            {
                // trigger windows auth
                // since windows auth don't support the redirect uri,
                // this URL is re-triggered when we call challenge
                return Challenge("Windows");
            }
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
                        var loginInfo = await _mediator.Send(new GetUsuarioByIdQuery() { Id = Input.UsuarioAd });
                        if (loginInfo != null)
                        {
                            logindetails = loginInfo.Data;
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
                    FirstName = logindetails.PrimerNombre+" "+logindetails.SegundoNombre,
                    LastName = logindetails.ApellidoPaterno+" "+logindetails.ApellidoMaterno,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                    //IdEmpresa=1
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
                            Cargo = logindetails.Title ?? "DEBE ACTUALIZAR DATOS",
                            Area = logindetails.Department ?? "DEBE ACTUALIZAR DATOS",
                            LugarTrabajo = logindetails.PhysicalDeliveryOfficeName ?? "DEBE ACTUALIZAR DATOS",
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
                    claims.Add(new Claim("Apellidos", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno));
                    claims.Add(new Claim("Nombres", logindetails.PrimerNombre + " " + logindetails.SegundoNombre));
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
                _logger.LogError("Usuario Invalido",ex);
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                ReturnUrl = returnUrl;
            }

            // Info.
            return this.Page();
        }

        #region Helpers

        #region Sign In method.

        private async Task AddUserClaims(ApplicationUser user, string idUsername)
        {
            var logindetails = new GetUsuarioByIdResponse();
            if (ModelState.IsValid)
            {
                var loginInfo = await _mediator.Send(new GetUsuarioByIdQuery() { Id = idUsername });
                if (loginInfo != null)
                {
                    logindetails = loginInfo.Data;
                }
                else
                {
                    _notyf.Error("Usuario no encontrado en la empresa.");
                    return;
                    //ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }
            else
                return;

           
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
                        Cargo = logindetails.Title ?? "DEBE ACTUALIZAR DATOS",
                        Area = logindetails.Department ?? "DEBE ACTUALIZAR DATOS",
                        LugarTrabajo = logindetails.PhysicalDeliveryOfficeName ?? "DEBE ACTUALIZAR DATOS",
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
            }


            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting

                //claims.Add(new Claim(ClaimTypes.Name, logindetails.UserNameRegular));
                //claims.Add(new Claim(ClaimTypes.Email, logindetails.Mail));
                //claims.Add(new Claim(ClaimTypes.Locality, logindetails.PhysicalDeliveryOfficeName));
                //claims.Add(new Claim("DisplayName", logindetails.DisplayName));
                ////claims.Add(new Claim("Cargo", logindetails.Title));
                ////claims.Add(new Claim("Jefe", logindetails.Manager));
                ////claims.Add(new Claim("Gerencia", logindetails.Company));
                ////claims.Add(new Claim("Departamento", logindetails.Department));
                //claims.Add(new Claim("Cedula", logindetails.Cedula));
                //claims.Add(new Claim("Id", idColabora.ToString()));
                //claims.Add(new Claim("Apellidos", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno));
                //claims.Add(new Claim("Nombres", logindetails.PrimerNombre + " " + logindetails.SegundoNombre));
                ////claims.Add(new Claim("ApellidosNombres", logindetails.ApellidoPaterno + " " + logindetails.ApellidoMaterno + " " + logindetails.PrimerNombre + " " + logindetails.SegundoNombre));


                ////var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ////var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                ////var authenticationManager = Request.HttpContext;

                //// Sign In.
                //await _userManager.AddClaimsAsync(user,claims);
            }
            catch (Exception ex)
            {
                // Info
                _logger.LogError("Error autenticarse", ex);
            }
        }


        /// <summary>
        /// Sign In User method.
        /// </summary>
        /// <param name="username">Username parameter.</param>
        /// <param name="isPersistent">Is persistent parameter.</param>
        /// <returns>Returns - await task</returns>
        private async Task SignInUser(string id, GetUsuarioByIdResponse username, bool isPersistent)
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
                //claims.Add(new Claim("Cargo", username.Title));
                //claims.Add(new Claim("Jefe", username.Manager));
                //claims.Add(new Claim("Gerencia", username.Company));
                //claims.Add(new Claim("Departamento", username.Department));
                claims.Add(new Claim("Cedula", username.Cedula));
                claims.Add(new Claim("Id", id));
                claims.Add(new Claim("Apellidos", username.ApellidoPaterno + " " + username.ApellidoMaterno));
                claims.Add(new Claim("Nombres", username.PrimerNombre + " " + username.SegundoNombre));
               // claims.Add(new Claim("ApellidosNombres", username.ApellidoPaterno + " " + username.ApellidoMaterno + " " + username.PrimerNombre + " " + username.SegundoNombre));


                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
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
    }

}
