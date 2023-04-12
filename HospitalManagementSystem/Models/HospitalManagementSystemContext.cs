// Models/HospitalManagementSystemContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public class HospitalManagementSystemContext : DbContext
    {
        public HospitalManagementSystemContext(DbContextOptions<HospitalManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
