// Data/DoctorsRepository.cs
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{
    public class DoctorsRepository : IRepository<Doctor>
    {
        private readonly HospitalManagementSystemContext _context;

        public DoctorsRepository(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
