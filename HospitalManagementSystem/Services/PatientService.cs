using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientService(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _patientsRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            return _patientsRepository.GetById(id);
        }

        public void CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _patientsRepository.Create(patient);
            _patientsRepository.Save();
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _patientsRepository.Update(patient);
            _patientsRepository.Save();
        }

        public void DeletePatient(int id)
        {
            _patientsRepository.Delete(id);
            _patientsRepository.Save();
        }
    }
}
