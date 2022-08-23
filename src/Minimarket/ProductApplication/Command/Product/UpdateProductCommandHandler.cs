using Entities;
using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;

namespace ProductApplication.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IUnitOfWork UnitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new();

            if (request.ProductId != Guid.Empty && string.IsNullOrEmpty(request.ProductName) && request.CategoryId == Guid.Empty)
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.ProductId, cancellationToken);

            else if (!string.IsNullOrEmpty(request.ProductName) && request.ProductId == Guid.Empty && request.CategoryId != Guid.Empty)
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.CategoryId, request.ProductName, cancellationToken);

            else if (request.ProductId != Guid.Empty && string.IsNullOrEmpty(request.ProductName) && request.CategoryId != Guid.Empty)
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.CategoryId, request.ProductId, cancellationToken);

            return string.Empty;
        }
    }
}
