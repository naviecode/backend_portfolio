using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;
using Portfolio.ViewModel;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var jwt = await _userService.Login(loginVM);
                return Ok(new { Token = jwt });

            }
            catch (AbandonedMutexException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutVM logoutVM)
        {
            try
            {
                var result = await _userService.Logout(logoutVM);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshVM refreshVM)
        {
            try
            {
                var jwt = await _userService.RefreshToken(refreshVM);
                return Ok(new { Token = jwt });
            }
            catch (AbandonedMutexException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
