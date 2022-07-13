using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetProduct")]
        public async Task<IActionResult> Get(int id)
        {
            return await  Task.FromResult(Ok());
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult>Get(int task , int skip)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post()
        {
            return await Task.FromResult(Ok());
        }

        [HttpPut("PutProduct")]
        public async Task<IActionResult>Put(int id)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteProduct")]
        public async  Task<IActionResult> Delete(int id)
        {
            return await Task.FromResult(Ok());
        }
    }
}
