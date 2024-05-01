using System.ComponentModel.DataAnnotations;

namespace Bank_Branches_Mini_Project.Models
{
    public class EmployeeModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }
       
    }
}
