// Models/Appointment.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Reason { get; set; }

        // Navigation Properties
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
