using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class ServicePlan
    {
        public int Id { get; set; }
        public DateOnly DateOfPurchase { get; set; }

        //navigational props
        public List<Timesheet> Timesheets { get; set; } = [];
    }
}
