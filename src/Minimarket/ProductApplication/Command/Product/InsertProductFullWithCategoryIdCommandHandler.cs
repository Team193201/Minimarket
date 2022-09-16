using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;
using Sheard.Dto.Product;

namespace ProductApplication.Command.Product
{
    public class InsertProductFullWithCategoryIdCommandHandler : IRequestHandler<ProductFullWithCategoryIdCommand, GetProductFullWithCategoryIdOutput>
    {
        IUnitOfWork unitOfWork;
        public InsertProductFullWithCategoryIdCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<GetProductFullWithCategoryIdOutput> Handle(ProductFullWithCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await unitOfWork.CategoryRepository.AnyCategoryIdAsync(request.Dto.CatecoryId, cancellationToken);
            if (!existCategory)
                throw new NullReferenceException("category is not found");

            var produsts = new List<Entities.Product>();

            foreach (var item in request.Dto.Products)
            {
                produsts.Add(new Entities.Product
                {
                    CategoryId = request.Dto.CatecoryId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    CreateDateTime = DateTime.Now,
                    ModifiDateTime = DateTime.Now
                });
            }
            //request.Dto.InsertProductWithOutCategoryIdDto.ForEach(product =>
            //{
            //    produsts.Add(new Entities.Product
            //    {
            //        CategoryId = request.Dto.CatecoryId,
            //    });
            //});


            await unitOfWork.ProductRepository.AddRangeEntitiesAsync(produsts, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new GetProductFullWithCategoryIdOutput();

            //return new GetProductFullWithCategoryIdOutput(request.Dto.CatecoryId, request.Dto.InsertProductWithOutCategoryIdDto.Select(s=>new InsertProductWithOutCategoryIdDto
            //{
            //    ProductName= s.ProductName,
            //    Price= s.Price,
            //    CreateDateTime= s.CreateDateTime,
            //    ModifiDateTime= DateTime.Now
            //}));
        }
    }
}
