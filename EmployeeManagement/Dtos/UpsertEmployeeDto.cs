using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Dtos
{
    public class UpsertEmployeeDto
    {
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
