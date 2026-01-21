using ApplicationLibrary;
using ApplicationLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class TimesheetsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TimesheetsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ServicePlanId { get; set; }

        public ServicePlan? ServicePlan { get; set; }

        public async Task OnGetAsync()
        {
            ServicePlan = await _context.ServicePlans
                .Include(sp => sp.Timesheets)
                .FirstOrDefaultAsync(sp => sp.Id == ServicePlanId);
        }
    }
}
