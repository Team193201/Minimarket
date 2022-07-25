using Infrastructure.Interface;
using MediatR;
using ProductApplication.Dto;

namespace ProductApplication.Command.Handler
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, InsertProductDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertProductCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<InsertProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryIdAsync(request.CategoryId, cancellationToken);
            if (existCategory)
            {
                UnitOfWork.ProductRepository.AddEntity(new Entities.Product
                {
                    CategoryId = request.CategoryId,
                    CreateDateTime = request.CreateDateTime,
                    ModifiDateTime = default(DateTime),
                    ProductId = Guid.NewGuid(),
                    ProductName = request.ProductName,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitPrice = request.UnitPrice,
                    UnitsInStock = request.UnitsInStock
                });
                await UnitOfWork.SaveChangesAsync(cancellationToken);
                return new InsertProductDto
                {
                    CategoryId = request.CategoryId,
                    CreateDateTime = request.CreateDateTime,
                    ProductName = request.ProductName,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitPrice = request.UnitPrice,
                    UnitsInStock = request.UnitsInStock
                };
            }
            else
            {
                throw new NullReferenceException("category is not found");
            }
        }
    }
}
