namespace Bank_Branches_Mini_Project.Models
{
    public class BankDashboardViewModel
    {
        public int TotalBranches { get; set; }
        public int TotalEmployees { get; set; }
        public BankBranchModel BranchWithMostEmployees { get; set; }
        public List<BankBranchModel> BranchList { get; set; }
    }
}


