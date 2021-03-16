using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class Reservations : Controller
    {
        ApplicationDbContext _Context;
        public Reservations(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        // GET: Reservations
        public ActionResult Index(DateTime datecalendar)
        {
            var Result = (from r in _Context.Reservations
                          join s in _Context.Students
                          on r.studentId equals s.Id
                          join rt in _Context.ReservationTypes
                          on r.ReservationTypeId equals rt.Id
                          //where (r.date== datecalendar)
                          select new ReservationViewModel
                          {
                              Id = r.id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Email = s.Email,
                              date=r.date,
                              status=r.status,
                              cause = r.cause,
                              reservationName = rt.Name,
                          }).ToList();

            return View("Index",Result);

        }

        // Post: Reservations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postdata(bool status, string Id)
        {


            var resId = _Context.Reservations.FirstOrDefault(a => a.id == Id);
            resId.status = status;
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
           


        }
        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resid =  _Context.Reservations.Find(id);
            if (resid == null)
            {
                return NotFound();
            }
            return View(resid);
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
