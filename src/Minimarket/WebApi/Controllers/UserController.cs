using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("GetUser")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get(int task, int skip, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostUser")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPut("PutUser")]
        public async Task<IActionResult> Put(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }
}
