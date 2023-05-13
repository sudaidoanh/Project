using Project.Data.Enums;
using Project.ViewModels.Catalog.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Plan
{
    public interface IPlanService
    {
        Task<bool> CreateVisitPlan(PlanViewModel request);
        Task<List<PlanViewModel>> GetVisitPlan(Guid guid);
        Task<bool> ReplyVisitPlan( int PlanId, Status reply);
        Task<List<LoadDistributorRequest>> LoadListDistributor(string keyword);
        Task<List<LoadUserRequest>> LoadListUser(string keyword);
        Task<List<GetAskVisitRequest>> GetRequestPlan(Guid guid);
    }
}
