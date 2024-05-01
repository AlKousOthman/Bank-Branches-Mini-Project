using System.ComponentModel.DataAnnotations;

namespace Bank_Branches_Mini_Project.Models
{
    public class AddEmployeeForm
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Civil ID already exists")]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }

        // [minLength(7)] / u can use more than validation on each field
        // open (Error message = "") near the validation to change the error message
    }
}
