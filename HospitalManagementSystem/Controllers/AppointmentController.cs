// AppointmentController.cs
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: /Appointment/
        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return View(appointments);
        }

        // GET: /Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,Time,PatientId,DoctorId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.CreateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: /Appointment/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _appointmentService.GetAppointmentById(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: /Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,Time,PatientId,DoctorId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _appointmentService.UpdateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        // GET: /Appointment/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _appointmentService.GetAppointmentById(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: /Appointment/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _appointmentService.GetAppointmentById(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: /Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _appointmentService.DeleteAppointmentById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
