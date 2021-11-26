using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Identity.Models;

namespace WordVision.ec.Web.Areas.Identity.Controllers
{

    public class UsuarioController : BaseController<UsuarioController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [Route("Auth/IngresoExterno")]
        [AllowAnonymous]
        public IActionResult IngresoExterno(string proveedor, string urlRetorno)
        {
            var redurectUrl = Url.Action("ExternalLoginCallback", "Usuario", new { ReturnUrl = urlRetorno });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(proveedor, redurectUrl);
            return new ChallengeResult(proveedor, properties);
        }

        [Route("Auth/IngresoExterno")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            UsuarioViewModel ingresoViewModel = new UsuarioViewModel
            {
                UrlRetorno = returnUrl,
                LoginExterno = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error en el proveedor externo:{remoteError}");

                return View("Ingreso", ingresoViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error cargando la información");
                return View("Ingreso", ingresoViewModel);
            }
            int idEmpresas = 0;
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed)
                {

                    ModelState.AddModelError(string.Empty, "Email sin confirmar");
                    return View("Ingreso", ingresoViewModel);
                }
                //else
                //    idEmpresas = user.IdEmpresa;
            }

            //vaida si el usuario tiene ya un usuario 
            var loginResultado = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
            isPersistent: false, bypassTwoFactor: true);

            if (loginResultado.Succeeded)
            {
                return RedirectToAction("index", "home", new { idEmpresa = idEmpresas });
                // return LocalRedirect(returnUrl);
            }
            else// si no tiene cuenta local
            {

                //if (email != null)
                //{
                //    var user = await gestionUsuarios.FindByEmailAsync(email);

                //    if (user == null)
                //    {
                //        user = new ApplicationUser
                //        {
                //            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                //            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                //        };
                //        await gestionUsuarios.CreateAsync(user);

                //        var token = await gestionUsuarios.GenerateEmailConfirmationTokenAsync(user);

                //        var linkConfirmation = "https://localhost:44350/Auth/ConfirmarEmail?usuarioId=" + user.Id + "&token=" + WebUtility.UrlEncode(token);

                //    }
                //    await gestionUsuarios.AddLoginAsync(user, info);
                //    await gestionLogin.SignInAsync(user, isPersistent: false);

                //    return LocalRedirect(returnUrl);
                //}

                //ViewBag.ErrorTitle = $"Email claim no fue recibido de; {info.LoginProvider}";
                //ViewBag.ErrorMessage = $"Contactar con Administrador";

                return View("Error");
            }

        }



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUsuario(string id)
        //{
        //    var loginInfo = await _mediator.Send(new GetUsuarioByIdQuery() { Id = id });
        //    if (loginInfo != null)
        //    {
        //        // Initialization.
        //        var logindetails = loginInfo;

        //        // Login In.
        //        await this.SignInUser(id, false);

        //        // Info.
        //        return this.RedirectToPage("/Colaborador/Index");
        //    }
        //    else
        //    {
        //        // Setting.
        //        ModelState.AddModelError(string.Empty, "Invalid username or password.");
        //    }
        //    return null;
        //}

        #region Helpers

        #region Sign In method.

        /// <summary>
        /// Sign In User method.
        /// </summary>
        /// <param name="username">Username parameter.</param>
        /// <param name="isPersistent">Is persistent parameter.</param>
        /// <returns>Returns - await task</returns>
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
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
