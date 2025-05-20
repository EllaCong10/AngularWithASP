using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 示例逻辑：仅允许一个固定账户登录
            if (request.Email == "test@example.com" && request.Password == "123456")
            {
                return Ok(new { message = "登录成功" });
            }

            return Unauthorized(new { message = "邮箱或密码错误" });
        }

    }
}
