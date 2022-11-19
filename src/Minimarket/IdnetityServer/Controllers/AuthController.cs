using Microsoft.AspNetCore.Mvc;

namespace IdnetityServer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        public async Task<IActionResult> Login(CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        public async Task<IActionResult> Register()
        {
            return await Task.FromResult(Ok());
        }

        public async Task<IActionResult> ForgotPassWord()
        {
            return await Task.FromResult(Ok());
        }
    }
}
