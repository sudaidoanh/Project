using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.UserAccount;
using Project.Application.System.Users;
using Project.ViewModels.Catalog.UserAccount;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IPublicUserService _publicUserService;
        public ServicesController(IPublicUserService publicUserService)
        {
            _publicUserService = publicUserService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid guid)
        {
            var user = await _publicUserService.View(guid);
            if (user == null) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPatch("Profile")]
        public async Task<IActionResult> Update([FromForm]EditProfileRequest request)
        {
            var user = await _publicUserService.Update(request);
            if (user == false) return BadRequest("Can not find user");
            return Ok(user);
        }

        [HttpPatch("Password")]
        public async Task<IActionResult> UpdatePassword([FromForm] EditPasswordRequest request)
        {
            var user = await _publicUserService.UpdatePassword(request);
            if (user == false) return BadRequest("Can not find user");
            return Ok(user);
        }
    }
}
