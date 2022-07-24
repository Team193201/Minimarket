using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Command;
using ProductApplication.Dto;

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
            return await Task.FromResult(Ok());
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get(int task, int skip, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post(InsertProductDto insertProductDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InsertProductCommand
            {
                CategoryId = insertProductDto.CategoryId,
                CreateDateTime = DateTime.Now,
                ProductName = insertProductDto.ProductName,
                QuantityPerUnit = insertProductDto.QuantityPerUnit,
                UnitPrice = insertProductDto.UnitPrice,
                UnitsInStock = insertProductDto.UnitsInStock,
            });
            return Ok(result);
        }

        [HttpPut("PutProduct")]
        public async Task<IActionResult> Put(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }
}
