using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;
using Sheard.Dto.Product;

namespace ProductApplication.Command
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, GetProductDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<GetProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {

            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryIdAsync(request.Dto.CategoryId, cancellationToken);
            if (!existCategory)
                throw new NullReferenceException("category is not found");

            var productId = Guid.NewGuid();
            UnitOfWork.ProductRepository.AddEntity(new Entities.Product
            {
                CategoryId = request.Dto.CategoryId,
                CreateDateTime = DateTime.UtcNow,
                ModifiDateTime = default(DateTime),
                ProductId = productId,
                ProductName = request.Dto.ProductName,
                Price = request.Dto.Price,
            });
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return new GetProductDto(request.Dto.ProductName, request.Dto.Price, productId, request.Dto.CategoryId, DateTime.UtcNow, default);
        }

    }
}
