using System.ComponentModel.DataAnnotations;

namespace Bank_Branches_Mini_Project.Models
{
    public class EditFormModel
    {
        [Required]
        public int BankId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LocationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }
        [Required]
        public int EmployeeCount { get; set; }

    }
}
