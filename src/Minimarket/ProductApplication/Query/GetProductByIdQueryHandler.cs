using Infrastructure.Interface;
using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, string>
    {
        private readonly IUnitOfWork UnitOfWork;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public async Task<string> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.ProductId);

            await UnitOfWork.ProductRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
            return string.Empty;
        }
    }
}
