using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductApplication.Query;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductNameQuery { ProductId = id });
            //   return result;
            return Ok(new ReusltApi { data = result,
                error=string.Empty,HttpStatusCode=HttpStatusCode.OK }) ;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get(int task, int skip, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpPut("PutProduct")]
        public async Task<IActionResult> Put(int id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }


    public class ReusltApi
    {
        public object data { get; set; }
        public string error { get; set; }
        public HttpStatusCode HttpStatusCode { get;set;}
}
}
