using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.Plan;
using Project.Data.Enums;
using Project.ViewModels.Catalog.Plan;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVisitPlan([FromForm] PlanViewModel request)
        {
            var plan = await _planService.CreateVisitPlan(request);
            if (plan) {
                return Ok(plan);
            }
            return BadRequest();
        }
        [HttpGet("Request")]
        public async Task<IActionResult> GetRequestPlan(Guid guid)
        {
            var plan = await _planService.GetRequestPlan(guid);
            if (plan != null)
            {
                return Ok(plan);
            }
            return BadRequest();
        }

        [HttpGet("My")]
        public async Task<IActionResult> GetVisitPlan(Guid guid)
        {
            var plan = await _planService.GetVisitPlan(guid);
            if (plan != null)
            {
                return Ok(plan);
            }
            return BadRequest();
        }

        [HttpPut("Request/{PlanId}")]
        public async Task<IActionResult> ReplyVisitPlan(Guid invitedUser, int PlanId, [FromForm] RequestStatus reply)
        {
            var plan = await _planService.ReplyVisitPlan(invitedUser,PlanId, reply);
            if (plan != false)
            {
                return Ok(plan);
            }
            return BadRequest();
        }
    }
}
