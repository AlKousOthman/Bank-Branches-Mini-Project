using System.ComponentModel.DataAnnotations;

namespace Bank_Branches_Mini_Project.Models
{
    public class NewBranchForm
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string LocationName { get; set; }

        [Required]
        public string LocationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Employee count must be greater than 0")]
        public int EmployeeCount { get; set; }
    }
}
