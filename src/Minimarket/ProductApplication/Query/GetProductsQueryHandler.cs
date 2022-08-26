using Infrastructure.Interface;
using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<string>>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<List<string>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            await UnitOfWork.ProductRepository.GetProductsAsync(request.Take, request.Skip, cancellationToken);

            return new List<string>();
        }
    }
}
