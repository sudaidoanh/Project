using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Catalog.UserAccount;

namespace Project.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageAccountService _manageAccountService;
        public UserController(IManageAccountService manageAccountService)
        {
            _manageAccountService = manageAccountService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _manageAccountService.GetAll();
            return Ok(data);
        }
    }
}
