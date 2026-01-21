using ApplicationLibrary;
using Microsoft.EntityFrameworkCore;
using ApplicationLibrary.DTO;

namespace WebApi.Services.ServicePlan
{
    public class ServicePlanService : IServicePlanService
    {
        private readonly ApplicationDbContext _context;

        public ServicePlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServicePlanDTO>> GetServicePlans()
        {
            var servicePlans = await _context.ServicePlans.ToListAsync();
            return servicePlans.Select(sp => new ServicePlanDTO
            {
                Id = sp.Id,
                DateOfPurchase = sp.DateOfPurchase,
                TimesheetCount = sp.Timesheets.Count
            }).ToList();
        }

        public async Task<List<ServicePlanWithTimesheetsDTO>> GetServicePlanWithTimesheets()
        {
            var servicePlans = await _context.ServicePlans
                .Include(sp => sp.Timesheets)
                .ToListAsync();

            return servicePlans.Select(sp => new ServicePlanWithTimesheetsDTO
            {
                Id = sp.Id,
                DateOfPurchase = sp.DateOfPurchase,
                Timesheets = sp.Timesheets.Select(ts => new TimesheetDTO
                {
                    Id = ts.Id,
                    Start = ts.Start,
                    End = ts.End,
                    Description = ts.Description,
                }).ToList()
            }).ToList();
        }
    }
}
