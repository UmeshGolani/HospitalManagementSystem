using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalManagementSystemContext _context;

        public HomeController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalDoctors = _context.Doctors.Count();
            ViewBag.TotalPatients = _context.Patients.Count();
            ViewBag.TotalAppointments = _context.Appointments.Count();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
