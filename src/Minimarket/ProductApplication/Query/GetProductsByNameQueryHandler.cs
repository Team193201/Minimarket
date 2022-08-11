using Infrastructure.Interface;
using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<string>>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductsByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<List<string>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.ProductName);

            await UnitOfWork.ProductRepository.GetProductsByNameAsync(request.ProductName, cancellationToken);

            return new List<string>();
        }
    }
}
