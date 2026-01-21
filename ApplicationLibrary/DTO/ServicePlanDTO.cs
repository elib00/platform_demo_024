using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.DTO
{
    public class ServicePlanDTO
    {
        public int Id { get; set; }
        public DateOnly DateOfPurchase { get; set; }
        public int TimesheetCount { get; set; }
    }
}
