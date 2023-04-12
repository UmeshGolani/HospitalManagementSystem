// Models/Staff.cs
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
