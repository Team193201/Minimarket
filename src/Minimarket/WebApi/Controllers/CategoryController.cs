using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Category;
using Sheard.Dto.Category;
using Sheard.Query.Category;

namespace WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int take, int skip, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCategorysQuery(take, skip), cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(InsertCategoryDto insertCategoryDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send (new InsertCategoryCommand(insertCategoryDto), cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateCategoryCommand(id, updateCategoryDto), cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
            return Ok(new ApiResult(result));
        }
    }
}
