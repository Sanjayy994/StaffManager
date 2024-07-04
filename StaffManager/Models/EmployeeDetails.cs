using System.ComponentModel.DataAnnotations;

namespace StaffManager.Models
{
    public class EmployeeDetails
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
