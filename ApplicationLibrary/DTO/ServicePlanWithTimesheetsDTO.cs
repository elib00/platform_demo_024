using ApplicationLibrary.Models;

namespace ApplicationLibrary.DTO
{
    public class ServicePlanWithTimesheetsDTO
    {
        public int Id { get; set; }
        public DateOnly DateOfPurchase { get; set; }
        public List<TimesheetDTO> Timesheets { get; set; } = [];
    }
}
