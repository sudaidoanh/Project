using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.UserAccount;
using Project.ViewModels.Catalog.UserAccount;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IManageAccountService _manageAccountService;
        public ManageController(IManageAccountService manageAccountService)
        {
            _manageAccountService = manageAccountService;
        }

        [HttpGet("User")]
        public async Task<IActionResult> Get()
        {
            var data = await _manageAccountService.GetAll();
            return Ok(data);
        }

        [HttpGet("User/{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            var user = await _manageAccountService.GetById(guid);
            if(user == null) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPost("User")]
        public async Task<IActionResult> Create([FromForm]UserCreateRequest request)
        {
            var userId = await _manageAccountService.Create(request);
            if(userId != Guid.Empty)
            {
                var user = _manageAccountService.GetById(userId);
                return CreatedAtAction(nameof(GetById), new { id = userId }, user);
               
            }
            return BadRequest();
        }

        [HttpDelete("User/{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var userId = await _manageAccountService.Delete(guid);
            if (userId == 0)
            {
                return BadRequest();
            }
            var user = _manageAccountService.GetById(guid);
            return Ok();
        }
    }
}
