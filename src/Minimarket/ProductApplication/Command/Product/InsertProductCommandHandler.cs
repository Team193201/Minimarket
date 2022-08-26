using Infrastructure.Interface;
using Infrastructure.Util;
using MediatR;
using Sheard.Command.Product;

namespace ProductApplication.Command
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, object>
    {
        private IUnitOfWork UnitOfWork;
        public IClassBuilder ClassBuilder;

        public InsertProductCommandHandler(IUnitOfWork unitOfWork, IClassBuilder classBuilder)
        {
            UnitOfWork = unitOfWork;
            ClassBuilder = classBuilder;
        }

        public async Task<object> Handle(InsertProductCommand request, CancellationToken cancellationToken)
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
                return ClassBuilder.BuildDynamicClass(
                      new string[] { "CategoryId", "CreateDateTime", "ProductName", "QuantityPerUnit", "UnitPrice", "UnitsInStock" },
                      new Type[] { typeof(Guid), typeof(DateTime), typeof(string), typeof(string), typeof(decimal), typeof(short) },
                      new object[] { request.CategoryId, request.CreateDateTime, request.ProductName, request.QuantityPerUnit, request.UnitPrice, request.UnitsInStock });


            }
            else
            {
                throw new NullReferenceException("category is not found");
            }
        }
    }
}
