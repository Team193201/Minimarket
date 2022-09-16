using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Product;
using Sheard.Dto.Product;
using Sheard.Query.Product;

namespace WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int take, int skip, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductsQuery(take, skip), cancellationToken);
            return Ok(new ApiResult(result));
        }

        //[HttpPost("")]
        //public async Task<IActionResult> Post(InsertProductDto insertProductDto, CancellationToken cancellationToken)
        //{
        //    var result = await mediator.Send(new InsertProductCommand(insertProductDto));
        //    return Ok(new ApiResult(result));
        //}

        [HttpPost("")]
        public async Task<IActionResult> Post1(Guid? categoryId, ProductFullWithCategoryId productFullWithCategoryId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new ProductFullWithCategoryIdCommand(productFullWithCategoryId));
            return Ok(new ApiResult(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateProductCommand(id, productDto));
            return Ok(new ApiResult(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteProductCommand(id));
            return Ok(new ApiResult(result));
        }
    }
}
