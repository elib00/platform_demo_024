using ApplicationLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.ServicePlan;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/serviceplan/")]
    public class ServicePlanController : ControllerBase
    {
        private readonly IServicePlanService _servicePlanService;

        public ServicePlanController(IServicePlanService servicePlanService)
        {
            _servicePlanService = servicePlanService;
        }


        [HttpGet]
        public async Task<IActionResult> GetServicePlans()
        {
            var response = await _servicePlanService.GetServicePlans();
            return Ok(response);
        }

        [HttpGet("with-timesheets")]
        public async Task<IActionResult> GetServicePlanWithTimesheets()
        {
            var response = await _servicePlanService.GetServicePlanWithTimesheets();
            return Ok(response);
        }
    }
}
