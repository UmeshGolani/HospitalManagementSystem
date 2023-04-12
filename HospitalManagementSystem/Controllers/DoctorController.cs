using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialization,PhoneNumber,Email")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.AddDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialization,PhoneNumber,Email")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _doctorService.UpdateDoctorAsync(doctor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _doctorService.DoctorExists(id);
        }
    }
}
