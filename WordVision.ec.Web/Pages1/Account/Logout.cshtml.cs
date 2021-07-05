//using Orca.Application.Features.ActivityLog.Commands.AddLog;
//using Orca.Application.Interfaces.Shared;
//using WordVision.ec.Infrastructure.Data.Identity.Models;
//using WordVision.ec.Web.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : BasePageModel<LogoutModel>
    {
        private readonly IMediator _mediator;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        //private readonly IAuthenticatedUserService _userService;
        private readonly IDistributedCache _distributedCache;
        public LogoutModel( ILogger<LogoutModel> logger, IMediator mediator, IDistributedCache distributedCache)
        {
            
            _logger = logger;
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> OnGet()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            var authenticationManager = Request.HttpContext;
            await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                //await _mediator.Send(new AddActivityLogCommand() { userId = _userService.UserId, Action = "Logged Out" });
                var authenticationManager = Request.HttpContext;
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await _distributedCache.RemoveAsync(Infrastructure.Data.CacheKeys.Identity.IdentityCacheKeys.GetKey(User.Identity.Name));
                _notyf.Information("User logged out.");
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // Info.
            return this.RedirectToPage("/Index");
    // _logger.LogInformation("User logged out.");
    //if (returnUrl != null)
    //{
    //    return LocalRedirect(returnUrl);
    //}
    //else
    //{
    //    return RedirectToPage();
    //}
    }
    }
}