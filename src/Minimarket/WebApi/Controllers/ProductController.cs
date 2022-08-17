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
            var result = await mediator.Send(new GetProductByIdQuery { ProductId = id }, cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int take, int skip, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductsQuery { Take = take, Skip = skip }, cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(InsertProductDto insertProductDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InsertProductCommand
            {
                CategoryId = insertProductDto.CategoryId,
                CreateDateTime = DateTime.UtcNow,
                ProductName = insertProductDto.ProductName,
                QuantityPerUnit = insertProductDto.QuantityPerUnit,
                UnitPrice = insertProductDto.UnitPrice,
                UnitsInStock = insertProductDto.UnitsInStock,
            });

            return Ok(new ApiResult(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateProductCommand
            {
                CategoryId = productDto.CategoryId,
                ProductName = productDto.ProductName,
                QuantityPerUnit = productDto.QuantityPerUnit,
                UnitPrice = productDto.UnitPrice,
                UnitsInStock = productDto.UnitsInStock,
                ProductId = id
            });

            return Ok(new ApiResult(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,DeleteProductDto productDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteProductCommand
            {
                ProductId = id
            });

            return Ok(new ApiResult(result));
        }
    }
}
