using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Data;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReservationSystem.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class ReservationController : Controller
    {
        ApplicationDbContext _Context;
        

        public ReservationController(ApplicationDbContext Context)
        {
            _Context = Context;
            
        }
        public IEnumerable<ReservationType> reservationtype { get; set; }

        // GET: ReservationController
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Result = (from r in _Context.Reservations
                          join s in _Context.Students
                          on r.student.Id equals s.Id
                          join rt in _Context.ReservationTypes
                          on r.ReservationType.Id equals rt.Id
                          where r.studentId== userId
                          select new ReservationViewModel
                          {
                              Id = r.id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Email = s.Email,
                              date = r.date,
                              status=r.status,
                              cause = r.cause,
                              reservationName = rt.Name,
                          }).ToList();

            ViewBag.Id = userId;
            return View("Index", Result);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            var reservationtype = _Context.ReservationTypes.ToList();
            ViewBag.items = reservationtype;

            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationViewModel rt)
        {
            Reservations reservation = new Reservations() {

                cause = rt.cause,
                date = rt.date,
               
               
            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //int lastreservationId = _Context.Reservations.Max(item => item.id);
            //reservation.id = lastreservationId+1;

            reservation.studentId= userId;
            var type = _Context.ReservationTypes.FirstOrDefault(t => t.Id == rt.ReservationTypeId);
            reservation.ReservationType = type;
             _Context.Reservations.Add(reservation);
            await _Context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            

        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
