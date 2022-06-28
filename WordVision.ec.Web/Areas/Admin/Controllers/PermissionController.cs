﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Constants;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Admin.Models;
using WordVision.ec.Web.Helpers;

namespace WordVision.ec.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionController : BaseController<PermissionController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> Index(string roleId)
        {
            var model = new PermissionViewModel();
            var allPermissions = new List<RoleClaimsViewModel>();
            allPermissions.GetPermissions(typeof(Permissions.Dashboard), roleId);
            allPermissions.GetPermissions(typeof(Permissions.EstrategiaNacional), roleId);
            allPermissions.GetPermissions(typeof(Permissions.ObjetivoEstrategico), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Gestion), roleId);
            allPermissions.GetPermissions(typeof(Permissions.FactorCriticoExito), roleId);
            allPermissions.GetPermissions(typeof(Permissions.IndicadorEstrategico), roleId);
            allPermissions.GetPermissions(typeof(Permissions.IndicadorAF), roleId);
            allPermissions.GetPermissions(typeof(Permissions.IndicadorPOA), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Users), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Donante), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Catalogo), roleId);
            allPermissions.GetPermissions(typeof(Permissions.ObjetivoBloque), roleId);
            allPermissions.GetPermissions(typeof(Permissions.ProductoObjetivo), roleId);
            allPermissions.GetPermissions(typeof(Permissions.IndicadorProductoObjetivo), roleId);
            allPermissions.GetPermissions(typeof(Permissions.IndicadorClicoEstrategico), roleId);
            

            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var claimsModel = _mapper.Map<List<RoleClaimsViewModel>>(claims);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claimsModel.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = _mapper.Map<List<RoleClaimsViewModel>>(allPermissions);
            ViewData["Title"] = $"Permissions for {role.Name} Role";
            ViewData["Caption"] = $"Manage {role.Name} Role Permissions.";
            _notify.Success($"Updated Claims / Permissions for Role '{role.Name}'");
            return View(model);
        }

        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            //Remove all Claims First
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            _notify.Success($"Updated Claims / Permissions for Role '{role.Name}'");
            //var user = await _userManager.GetUserAsync(User);
            //await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", new { roleId = model.RoleId });
        }
    }
}
