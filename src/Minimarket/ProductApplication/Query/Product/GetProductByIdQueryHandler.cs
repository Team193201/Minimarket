using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Product;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDto>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public async Task<GetProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.ProductId);

            var product = await UnitOfWork.ProductRepository.GetProductAsync(request.ProductId, cancellationToken);

            //TODO mapping
            return new GetProductDto(product.ProductName, product.Price, product.CategoryId, product.CreateDateTime, product.ModifiDateTime);
        }
    }
}
