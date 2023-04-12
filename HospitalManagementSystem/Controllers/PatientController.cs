using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _patientService.GetPatientById(id.Value);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Address,PhoneNumber,Email,Gender,DateOfBirth")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.AddPatient(patient);
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _patientService.GetPatientById(id.Value);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Address,PhoneNumber,Email,Gender,DateOfBirth")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(patient);
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _patientService.GetPatientById(id.Value);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
