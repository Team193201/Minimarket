using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Product;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<List<GetProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await UnitOfWork.ProductRepository.GetProductsAsync(request.Take, request.Skip, cancellationToken);
            return products.Select(s => new GetProductDto
            (
                s.ProductName,
                s.Price,
                s.ProductId,
                s.CategoryId,
                s.CreateDateTime,
                s.ModifiDateTime
                )).ToList();
        }
    }
}
