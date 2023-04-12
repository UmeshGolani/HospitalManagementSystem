// Data/PatientsRepository.cs
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{
    public class PatientsRepository : IRepository<Patient>
    {
        private readonly HospitalManagementSystemContext _context;

        public PatientsRepository(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
