using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Category;
using Sheard.Dto.Category;
using Sherd;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMediator mediator;
        public CategoryController(IMediator _mediator)
        {
            mediator = _mediator;
        }

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
        public async Task<IActionResult> Post(InsertCategoryDto insertCategoryDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InsertCategoryCommand
            {
                CategoryName = insertCategoryDto.CategoryName,
                Description = insertCategoryDto.Description,
                Picture = insertCategoryDto.Picture
            });
            return Ok(new ApiResult(result));
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
