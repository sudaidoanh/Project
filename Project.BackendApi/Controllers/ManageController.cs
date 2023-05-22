using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.Area;
using Project.Application.Catalog.UserAccount;
using Project.ViewModels.Catalog.Area;
using Project.ViewModels.Catalog.UserAccount;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {
        private readonly IManageAccountService _manageAccountService;
        private readonly IAreaManageService _areaManageService;
        public ManageController(IManageAccountService manageAccountService, IAreaManageService areaManageService)
        {
            _manageAccountService = manageAccountService;
            _areaManageService = areaManageService;
        }

        [HttpGet("User")]
        public async Task<IActionResult> Get()
        {
            var data = await _manageAccountService.GetAll();
            return Ok(data);
        }

        [HttpGet("User/Page")]
        public async Task<IActionResult> GetAllUser([FromQuery] GetUserPagingRequest request)
        {
            var data = await _manageAccountService.GetAllAccount(request);
            if (data == null) return BadRequest("Can not find user");
            return Ok(data);
        }

        [HttpGet("User/{guid}")]
        public async Task<IActionResult> GetByUserId(Guid guid)
        {
            var user = await _manageAccountService.GetById(guid);
            if (user == null) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser([FromForm] UserCreateRequest request)
        {
            var userId = await _manageAccountService.Create(request);
            if (userId != Guid.Empty)
            {
                return Ok(userId);

            }
            return BadRequest();
        }

        [HttpDelete("User/{guid}")]
        public async Task<IActionResult> DeleteAccount(Guid guid)
        {
            var userId = await _manageAccountService.Delete(guid);
            if (userId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("Area")]
        public async Task<IActionResult> CreateArea([FromForm] string AreaName)
        {
            var area = await _areaManageService.Create(AreaName);
            return Ok(area);
        }

        [HttpGet("Area")]
        public async Task<IActionResult> GetAllArea([FromQuery] GetAreaPagingRequest request)
        {
            var data = await _areaManageService.GetAllArea(request);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpDelete("Area")]
        public async Task<IActionResult> DeleteArea([FromForm] List<int> AreaId)
        {
            var data = await _areaManageService.Delete(AreaId);
            return Ok(data);
        }

        [HttpGet("Area/{AreaId}/Distributors")]
        public async Task<IActionResult> GetAreaDistributor(int AreaId, [FromQuery] GetAreaPagingRequest request)
        {
            var data = await _areaManageService.GetAreaDistributor(AreaId, request);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost("Area/{AreaId}/Distributors")]
        public async Task<IActionResult> CreateDistributor(int AreaId, [FromQuery] DistributorCreateRequest request)
        {
            request.AreaId = AreaId;
            var userId = await _areaManageService.CreateDistributorArea(AreaId, request);
            if (userId != 0)
            {
                return Ok(userId);

            }
            return BadRequest();
        }

        [HttpDelete("Area/{AreaId}/Distributors")]
        public async Task<IActionResult> DeleteUDistributor([FromForm] List<int> distributorId)
        {
            var userId = await _areaManageService.DeleteUDistributor(distributorId);
            if (userId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("Area/{AreaId}/Users")]
        public async Task<IActionResult> GetAreaUser(int AreaId, [FromQuery] GetAreaPagingRequest request)
        {
            var data = await _areaManageService.GetAreaUser(AreaId, request);
            if (data == null) {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost("Area/{AreaId}/Users")]
        public async Task<IActionResult> AddAreaUser(int AreaId, [FromForm] UserCreateRequest request)
        {
            request.AreaId = AreaId;
            var userId = await _areaManageService.CreateAccountUserArea(AreaId, request);
            if (userId != Guid.Empty)
            {
                return Ok(userId);

            }
            return BadRequest();
        }

        [HttpPost("Area/{AreaId}")]
        public async Task<IActionResult> AssignAreaUser(int AreaId, [FromForm] List<Guid> guid)
        {
            var areaUser = await _areaManageService.AssignAreaUser(AreaId, guid);
            if (areaUser > 0)
            {
                return Ok(areaUser);

            }
            return BadRequest();
        }

        [HttpDelete("Area/{AreaId}/Users")]
        public async Task<IActionResult> DeleteUserArea([FromForm] List<Guid> guid)
        {
            var userId = await _areaManageService.DeleteUserArea(guid);
            if (userId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("Plan/Page")]
        public async Task<IActionResult> GetAllPlan([FromQuery] GetUserPagingRequest request)
        {
            var data = await _manageAccountService.GetAllAccount(request);
            if (data == null) return BadRequest("Can not find user");
            return Ok(data);
        }

        [HttpGet("Plan/{id}")]
        public async Task<IActionResult> GetByPlanId(Guid guid)
        {
            var user = await _manageAccountService.GetById(guid);
            if (user == null) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPatch("Plan")]
        public async Task<IActionResult> ConfirmPlanRequest([FromForm] UserCreateRequest request)
        {
            var userId = await _manageAccountService.Create(request);
            if (userId != Guid.Empty)
            {
                return Ok(userId);

            }
            return BadRequest();
        }

        [HttpDelete("Plan/{id}")]
        public async Task<IActionResult> DeletePlan(Guid guid)
        {
            var userId = await _manageAccountService.Delete(guid);
            if (userId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("Survey/Page")]
        public async Task<IActionResult> GetAllSurvey([FromQuery] GetUserPagingRequest request)
        {
            var data = await _manageAccountService.GetAllAccount(request);
            if (data == null) return BadRequest("Can not find user");
            return Ok(data);
        }

        [HttpGet("Survey/{id}")]
        public async Task<IActionResult> GetBySurveyId(Guid guid)
        {
            var user = await _manageAccountService.GetById(guid);
            if (user == null) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPatch("Survey/{id}")]
        public async Task<IActionResult> ConfirmSuvey([FromForm] UserCreateRequest request)
        {
            var userId = await _manageAccountService.Create(request);
            if (userId != Guid.Empty)
            {
                return Ok(userId);

            }
            return BadRequest();
        }

        [HttpDelete("Survey/{id}")]
        public async Task<IActionResult> DeleteSurvey(Guid guid)
        {
            var userId = await _manageAccountService.Delete(guid);
            if (userId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
