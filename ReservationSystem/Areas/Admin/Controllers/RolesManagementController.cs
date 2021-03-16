using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Data;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class RolesManagementController : Controller
    {
        ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;

        public RolesManagementController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        // GET: RoleManagementController
        public ActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View(_roleManager.Roles.ToList());

            //var Result = (from o in _context.Students
            //             join i in _context.Reservations
            //             on o.Id equals i.student.Id
            //             select new
            //             {
            //                 Name = o.Email,
            //                 lastname = o.LastName,
            //                 cause = i.cause
            //             }).ToList();

            //return Json(Result);
        }

        // GET: RoleManagementController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: RoleManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string name)
        {
            //Instanciation from the identity Role 
            IdentityRole role = new IdentityRole();
            //affectation du string name on the Name of the role 
            role.Name = name;
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role Has Been Created Succefully";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private void Errors(IdentityResult result)
        {
            throw new NotImplementedException();
        }

        // GET: RoleManagementController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        // POST: RoleManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string  id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "This role is already exist";
                ViewBag.name = name;

            }
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been updated successfully";
            }
            return View();

        }

        // GET: RoleManagementController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();

        }

        // POST: RoleManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            var role = await _roleManager.FindByIdAsync(id);

            await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));

        }
    }
}
