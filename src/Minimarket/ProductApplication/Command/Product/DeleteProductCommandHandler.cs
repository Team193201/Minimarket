using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;

namespace ProductApplication.Command
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IUnitOfWork UnitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

          //  ArgumentNullException.ThrowIfNull(request.ProductId == Guid.Empty);

            var product = await UnitOfWork.ProductRepository.GetProductAsync(request.ProductId, cancellationToken);
            UnitOfWork.ProductRepository.DeleteEntity(product);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return request.ProductId;
        }
    }
}
