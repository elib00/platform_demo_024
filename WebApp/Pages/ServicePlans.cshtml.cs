using ApplicationLibrary;
using ApplicationLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class ServicePlansModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<ServicePlanViewModel> ServicePlans { get; set; } = [];

        public ServicePlansModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            ServicePlans = await _context.ServicePlans
                .Include(sp => sp.Timesheets) // include timesheets even if empty
                .Select(sp => new ServicePlanViewModel
                {
                    Id = sp.Id,
                    DateOfPurchase = sp.DateOfPurchase,
                    TimesheetCount = sp.Timesheets.Count
                })
                .ToListAsync();
        }
    }

    public class ServicePlanViewModel
    {
        public int Id { get; set; }
        public DateOnly DateOfPurchase { get; set; }
        public int TimesheetCount { get; set; }
        public List<Timesheet> Timesheets { get; set; } = [];
    }
}
