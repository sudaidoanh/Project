using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.System.Roles;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }
        [HttpPatch("Assign")]
        public async Task<IActionResult> AssignRole()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }

        [HttpPatch("Account/{guid}")]
        public async Task<IActionResult> AcctiveAccount()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }

    }
}
