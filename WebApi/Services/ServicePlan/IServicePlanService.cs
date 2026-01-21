using ApplicationLibrary.Models;
using ApplicationLibrary.DTO;
namespace WebApi.Services.ServicePlan
{
    public interface IServicePlanService
    {
        Task<List<ServicePlanDTO>> GetServicePlans();
        Task<List<ServicePlanWithTimesheetsDTO>> GetServicePlanWithTimesheets();
    }
}
