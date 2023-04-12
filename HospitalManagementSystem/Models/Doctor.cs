// Models/Doctor.cs
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
