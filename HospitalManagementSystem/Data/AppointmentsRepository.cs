// Data/AppointmentsRepository.cs
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Data
{
    public class AppointmentsRepository : IRepository<Appointment>
    {
        private readonly HospitalManagementSystemContext _context;

        public AppointmentsRepository(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
