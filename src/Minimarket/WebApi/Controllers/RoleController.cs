using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        [HttpGet("GetRole")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get(int task, int skip, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostRole")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPut("PutRole")]
        public async Task<IActionResult> Put(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }
}
