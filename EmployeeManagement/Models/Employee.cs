using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int PersonnelCode { get; set; }

        [Required]
        public int InternalNumber { get; set; }

        [Required]
        public string Building { get; set; }

        [Required]
        [MaxLength(5)]
        public string Floor { get; set; }

        [Required]
        [MaxLength(5)]
        public string Room { get; set; }
    }
}
