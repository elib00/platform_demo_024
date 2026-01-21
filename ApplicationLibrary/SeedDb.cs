using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public  class SeedDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.ServicePlans.Any())
                return; // Already seeded

            var random = new Random();

            // 10–15 service plans
            int servicePlanCount = random.Next(10, 16);
            var servicePlans = Enumerable.Range(1, servicePlanCount).Select(i =>
            {
                // Random number of days in the past (0 = today, up to 120 days ago)
                int daysAgo = random.Next(0, 121); // 0–120 days ago

                return new ServicePlan
                {
                    DateOfPurchase = DateOnly.FromDateTime(DateTime.Now.AddDays(-daysAgo))
                };
            }).ToList();


            context.ServicePlans.AddRange(servicePlans);
            context.SaveChanges();

            // 0–5 timesheets per service plan
            foreach (var plan in servicePlans)
            {
                int timesheetCount = random.Next(0, 6);
                for (int t = 0; t < timesheetCount; t++)
                {
                    // Pick a random start time within 30 days after purchase
                    var start = plan.DateOfPurchase.ToDateTime(new TimeOnly(9, 0)) // start at 9 AM
                                .AddDays(random.Next(0, 30))
                                .AddHours(random.Next(0, 8)); // add 0-8 random hours

                    // End is 1–8 hours after start
                    var end = start.AddHours(random.Next(1, 9));

                    plan.Timesheets.Add(new Timesheet
                    {
                        Start = start,
                        End = end,
                        Description = $"Timesheet {t + 1} for ServicePlan {plan.Id}"
                    });
                }
            }


            context.SaveChanges();
        }
    }
}
