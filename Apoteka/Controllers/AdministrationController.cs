using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apoteka.Models;
using Apoteka.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Apoteka.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPasswordHasher<ApplicationUser> passwordHash;

        public AdministrationController(RoleManager<IdentityRole> roleManager, 
                                        UserManager<ApplicationUser> userManager,
                                        IPasswordHasher<ApplicationUser> passwordHash)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.passwordHash = passwordHash;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "administration");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public ViewResult Index() => View(roleManager.Roles);

        

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "Rola nije pronađena");
            return View("Index", roleManager.Roles);
        }


        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }




        public ViewResult Users() => View(userManager.Users);

        public ViewResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Email,   
                    DatumRodjenja = user.DatumRodjenja,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Users");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        public async Task<IActionResult> UpdateUser(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string id, string email, string password, DateTime datumRodjenja)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                    user.UserName = email;
                }
                    
                else
                    ModelState.AddModelError("", "Email ne može biti prazan.");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHash.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Lozinka ne može biti prazna");

                      user.DatumRodjenja = datumRodjenja;

                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Users");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "Korisnik nije pronađen");
            return View(user);
        }

       

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Users");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "Korisnik nije pronađen");
            return View("Users", userManager.Users);
        }

    }


}