using Bank_Branches_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Bank_Branches_Mini_Project.Controllers
{
    public class BankController : Controller
    {
       //Dependency injection step 3
            private readonly BankContext _context;

            public BankController(BankContext context)
            {
                _context = context;
            }

        



        static List<BankBranchModel> branchList = [
            new BankBranchModel { Id = 1, LocationName = "Qurtoba", LocationURL = "https://maps.app.goo.gl/sewvic3SYtGRummD7", BranchManager = "Othman", EmployeeCount = 12 },
            new BankBranchModel { Id = 1, LocationName = "Qurtoba", LocationURL = "https://maps.app.goo.gl/sewvic3SYtGRummD7", BranchManager = "Othman", EmployeeCount = 12 },
            new BankBranchModel { Id = 1, LocationName = "Qurtoba", LocationURL = "https://maps.app.goo.gl/sewvic3SYtGRummD7", BranchManager = "Othman", EmployeeCount = 12 }

            ];
        public IActionResult Index()
        {
            //var context = _context.BankBranches.ToList();
            var viewModel = new BankDashboardViewModel();
            // return View(context);

            var viewModel1 = new BankDashboardViewModel();
            viewModel.BranchList = _context.BankBranches.Include(r => r.Employees).ToList();
            viewModel.TotalBranches = _context.BankBranches.Count();
            viewModel.TotalEmployees = _context.Employees.Count();
            viewModel.BranchWithMostEmployees = _context
                .BankBranches
                .OrderByDescending(b => b.Employees.Count)
                .FirstOrDefault();

            return View(viewModel);
        }

        public IActionResult BranchesDetails(int id)
        {
            
            using (var context = _context)
            {
                var bankBranches = context.BankBranches.Include(r=> r.Employees).FirstOrDefault(b => b.Id == id); 
                if (bankBranches == null)
                {
                    return NotFound();
                }
                return View(bankBranches);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(BankBranchModel newBranch)
        {
            using (var context = _context)
            {
             //   var bankBranch = new BankBranchModel { Url = "http://newblog.com" };
                context.BankBranches.Add(newBranch);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var form = new EditFormModel();
            var context = _context;
            var banks = context.BankBranches.SingleOrDefault(a => a.Id == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            form.BankId = banks.Id;
            form.LocationURL = banks.LocationURL;
            form.LocationName = banks.LocationName;
            form.BranchManager = banks.BranchManager;
            form.EmployeeCount = banks.EmployeeCount;
            return View(form);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditFormModel form) 
        {
            var context = _context;

            var bankId = form.BankId;
            var locationName = form.LocationName;
            var locationURL = form.LocationURL;
            var branchManager = form.BranchManager;
            var employeeCount = form.EmployeeCount;
            if (ModelState.IsValid)
            {
                var bank = context.BankBranches.Find(id);
                if (bank != null)
                {
                    bank.Id = bankId;
                    bank.LocationName = locationName;
                    bank.LocationURL = locationURL;
                    bank.BranchManager = branchManager;
                    bank.EmployeeCount = employeeCount;
                    context.SaveChanges();
                }

            }
            else
            {
                return View(form);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddEmployee(int id) 
        {
            //var db = new BankContext();
           // var bank = db.BankBranches.Find(id);

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var context = _context;

                    var name = form.Name;
                    var civilId = form.CivilId;
                    var position = form.Position;
                    var bank = context.BankBranches.Find(id);

                    bank.Employees.Add(new EmployeeModel
                    {
                        Name = name,
                        CivilId = civilId,
                        Position = position
                    });
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("CivilId", "This Civil id is already in the system");
                    return View(form);
                }
            }
            else                                                                        
            {
                return View(form);
            }
            return RedirectToAction("BranchesDetails", new { id = id });

        }


        

    }
}


































