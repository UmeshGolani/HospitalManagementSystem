using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffsRepository _staffsRepository;

        public StaffService(IStaffsRepository staffsRepository)
        {
            _staffsRepository = staffsRepository;
        }

        public IEnumerable<Staff> GetStaff()
        {
            return _staffsRepository.GetAll();
        }

        public Staff GetStaffById(int id)
        {
            return _staffsRepository.GetById(id);
        }

        public void CreateStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            _staffsRepository.Create(staff);
            _staffsRepository.Save();
        }

        public void UpdateStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            _staffsRepository.Update(staff);
            _staffsRepository.Save();
        }

        public void DeleteStaff(int id)
        {
            _staffsRepository.Delete(id);
            _staffsRepository.Save();
        }
    }
}
