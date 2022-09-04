using Entities;
using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;
using Sheard.Dto.Product;

namespace ProductApplication.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, GetProductDto>
    {
        private readonly IUnitOfWork UnitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<GetProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new();

            if (request.ProductId != Guid.Empty && string.IsNullOrEmpty(request.Dto.ProductName) && request.Dto.CategoryId != Guid.Empty)
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.Dto.CategoryId, request.ProductId, cancellationToken);
            else if (request.ProductId == Guid.Empty && !string.IsNullOrEmpty(request.Dto.ProductName) && request.Dto.CategoryId != Guid.Empty)
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.Dto.CategoryId, request.Dto.ProductName, cancellationToken);
            else
                product = await UnitOfWork.ProductRepository.GetProductAsync(request.ProductId, cancellationToken);

            product.ProductName = request.Dto.ProductName ?? product.ProductName;
            product.Price = request.Dto.Price;
            product.ModifiDateTime = DateTime.Now;

            UnitOfWork.ProductRepository.UpdateEntity(product);

            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return new GetProductDto(product.ProductName, product.Price, product.CategoryId, product.CreateDateTime, product.ModifiDateTime);
        }
    }
}
