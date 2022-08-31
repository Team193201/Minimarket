using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Product;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<GetProductDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductsByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<List<GetProductDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.ProductName);

            var products = await UnitOfWork.ProductRepository.GetProductsByNameAsync(request.ProductName, cancellationToken);

            //TODO mapping
            return new List<GetProductDto>();
        }
    }
}
