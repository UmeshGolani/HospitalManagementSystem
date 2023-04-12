using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: /Staff
        public IActionResult Index()
        {
            var staff = _staffService.GetAllStaff();
            return View(staff);
        }

        // GET: /Staff/Details/5
        public IActionResult Details(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // GET: /Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Position, Department")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _staffService.AddStaff(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: /Staff/Edit/5
        public IActionResult Edit(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: /Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name, Position, Department")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _staffService.UpdateStaff(staff);
                }
                catch
                {
                    if (!_staffService.StaffExists(staff.Id))
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
            return View(staff);
        }

        // GET: /Staff/Delete/5
        public IActionResult Delete(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: /Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = _staffService.GetStaffById(id);
            _staffService.DeleteStaff(staff);
            return RedirectToAction(nameof(Index));
        }
    }
}
