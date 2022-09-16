using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;
using Sheard.Dto.Product;

namespace ProductApplication.Command.Category
{
    public class InsertCategoryAndProductsCommandHandler : IRequestHandler<InsertCategoryAndProductsCommand, GetCategoryAndProductsDto>
    {
        IUnitOfWork unitOfWork;
        public InsertCategoryAndProductsCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<GetCategoryAndProductsDto> Handle(InsertCategoryAndProductsCommand request, CancellationToken cancellationToken)
        {
            var categoryId = await unitOfWork.CategoryRepository.GetCategoryIdByNameAsync(request.insertCategoryAndProductsDto.CategoryName, cancellationToken);
            if (categoryId == Guid.Empty)
            {
                await unitOfWork.CategoryRepository.AddEntityAsync(new Entities.Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = request.insertCategoryAndProductsDto.CategoryName,
                    CreateDateTime = DateTime.Now,
                    ModifiDateTime = DateTime.Now,
                    Description = request.insertCategoryAndProductsDto.Description,
                }, cancellationToken);
            }
            var produsts = new List<Entities.Product>();
            request.insertCategoryAndProductsDto.Products.ForEach(product =>
            {
                produsts.Add(new Entities.Product
                {
                    CategoryId = categoryId,
                    ProductId = Guid.NewGuid(),
                    ProductName = product.ProductName,
                    CreateDateTime = DateTime.Now,
                    ModifiDateTime = DateTime.Now,
                    Price = product.Price,
                });
            });
            await unitOfWork.ProductRepository.AddRangeEntitiesAsync(produsts, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new GetCategoryAndProductsDto(
                request.insertCategoryAndProductsDto.CategoryName, request.insertCategoryAndProductsDto.Description,
                produsts.Select(s => new InsertProductsDto(s.ProductName, s.Price)).ToList());
        }
    }
}
