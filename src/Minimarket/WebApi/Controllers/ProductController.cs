using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Product;
using Sheard.Dto.Product;
using Sheard.Query.Product;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator mediator;
        public ProductController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductByIdQuery { ProductId = id }, cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get(int take, int skip, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductsQuery { Take = take, Skip = skip }, cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get(string name, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductsByNameQuery { ProductName = name }, cancellationToken);
            return Ok(new ApiResult(result));
        }

        [HttpPost("PostProduct")]
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

        [HttpPut("PutProduct")]
        public async Task<IActionResult> Put(UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateProductCommand
            {
                CategoryId = productDto.CategoryId,
                ProductName = productDto.ProductName,
                QuantityPerUnit = productDto.QuantityPerUnit,
                UnitPrice = productDto.UnitPrice,
                UnitsInStock = productDto.UnitsInStock,
                ProductId = productDto.ProductId
            });

            return Ok(new ApiResult(result));
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductDto productDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteProductCommand
            {
                ProductId = productDto.ProductId
            });

            return Ok(new ApiResult(result));
        }
    }
}
