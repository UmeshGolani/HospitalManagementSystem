using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public DoctorService(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorsRepository.GetAll();
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorsRepository.GetById(id);
        }

        public void CreateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _doctorsRepository.Create(doctor);
            _doctorsRepository.Save();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _doctorsRepository.Update(doctor);
            _doctorsRepository.Save();
        }

        public void DeleteDoctor(int id)
        {
            _doctorsRepository.Delete(id);
            _doctorsRepository.Save();
        }
    }
}
