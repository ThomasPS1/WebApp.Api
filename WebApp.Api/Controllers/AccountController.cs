using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entity.Dto;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(UserInfoRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Credential");
            }

            var user = await userManager.FindByNameAsync(request.UserName);
            var result = await userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                return Ok(user);
            }
            return BadRequest("Invalid Credential");
        }
    }
}
