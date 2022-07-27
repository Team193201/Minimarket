﻿using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("GetCategory")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpGet("GetCategorys")]
        public async Task<IActionResult> Get(int task, int skip, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostCategory")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPut("PutCategory")]
        public async Task<IActionResult> Put(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }
}