using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Admin.Models;

namespace WordVision.ec.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : BaseController<UserRoleController>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string userId)
        {
            var viewModel = new List<UserRolesViewModel>();
            var user = await _userManager.FindByIdAsync(userId);
            ViewData["Title"] = $"{user.UserName} - Roles";
            ViewData["Caption"] = $"Manage {user.Email}'s Roles.";

            List<string> userRoles = new List<string>();
            foreach (var role in _roleManager.Roles)
            {
                userRoles.Add(role.Name);
            }

            //foreach (var role in _roleManager.Roles)
            for (int i = 0; i <= userRoles.Count - 1; i++)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleName = userRoles[i] //role.Name
                };


                //var adminRole = await _roleManager.FindByNameAsync(user.UserName);
                //foreach (var roles in adminRole
                //{
                //}
                //    IList<string> userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                //if (userRoles.Contains(role.Name))
                //{
                //    userRolesViewModel.Selected = true;
                //}
                //else
                //{
                //    userRolesViewModel.Selected = false;
                //}
                if (await _userManager.IsInRoleAsync(user, userRoles[i]))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                viewModel.Add(userRolesViewModel);
            }
            var model = new ManageUserRolesViewModel()
            {
                UserId = userId,
                UserRoles = viewModel
            };

            return View(model);
        }

        public async Task<IActionResult> Update(string id, ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            await  Infrastructure.Data.Identity.Seeds.DefaultSuperAdminUser.SeedAsync(_userManager, _roleManager);
            _notify.Success($"Updated Roles for User '{user.Email}'");
            return RedirectToAction("Index", new { userId = id });
        }
    }

}
