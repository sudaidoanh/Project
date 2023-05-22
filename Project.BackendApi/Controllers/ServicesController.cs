using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.Notification;
using Project.Application.Catalog.UserAccount;
using Project.Application.System.Users;
using Project.ViewModels.Catalog.Noftication;
using Project.ViewModels.Catalog.UserAccount;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IPublicUserService _publicUserService;
        private readonly INotificationService _notificationService;
        public ServicesController(IPublicUserService publicUserService, INotificationService notificationService)
        {
            _publicUserService = publicUserService;
            _notificationService = notificationService;
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

        [HttpGet("Notifications")]
        public async Task<IActionResult> GetNotificationPage(Guid user, [FromQuery] GetNotificationPagingRequest request)
        {
            var notif = await _notificationService.GetNotificationPaging(user, request);
            if(notif == null) return NotFound();
            return Ok(notif);
        }

        [HttpPost("Notifications")]
        public async Task<IActionResult> AddNewNotification([FromBody] AddNotificationRequest request)
        {
            var notif = await _notificationService.CreateNewNotification(request);
            if (notif == false) return BadRequest();
            return Ok(notif);
        }
    }
}
