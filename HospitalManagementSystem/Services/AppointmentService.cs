using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentService(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentsRepository.GetAll();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentsRepository.GetById(id);
        }

        public void CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            _appointmentsRepository.Create(appointment);
            _appointmentsRepository.Save();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            _appointmentsRepository.Update(appointment);
            _appointmentsRepository.Save();
        }

        public void DeleteAppointment(int id)
        {
            _appointmentsRepository.Delete(id);
            _appointmentsRepository.Save();
        }
    }
}
