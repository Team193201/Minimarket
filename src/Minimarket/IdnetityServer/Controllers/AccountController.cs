using Microsoft.AspNetCore.Mvc;

namespace IdnetityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
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
