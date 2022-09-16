using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;
using Sheard.Dto.Product;

namespace ProductApplication.Command.Category
{
    public class InsertCategoryAndItsProductsCommandHandler : IRequestHandler<InsertCategoryAndItsProductsCommand, GetCategoryAndItsProductsDto>
    {
        IUnitOfWork unitOfWork;
        public InsertCategoryAndItsProductsCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        //public async Task<GetCategoryAndItsProductsDto> Handle(InsertCategoryAndItsProductsCommand request, CancellationToken cancellationToken)
        //{
        //    var produsts = new List<Entities.Product>();

        //    var category = await unitOfWork.CategoryRepository.AddEntityAsync(new Entities.Category
        //    {
        //        CategoryId = new Guid(),
        //        CategoryName = request.insertCategoryAndItsProductsDto.insertCategoryDto.CategoryName,
        //        CreateDateTime = DateTime.Now,
        //        ModifiDateTime = DateTime.Now,
        //        Description = request.insertCategoryAndItsProductsDto.insertCategoryDto.Description,
        //        Products = request.insertCategoryAndItsProductsDto.products.ForEach(product =>
        //        {
        //            produsts.Add(new Entities.Product
        //            {
        //                CategoryId = Entities.Category.
        //                ProductId = new Guid(),
        //                ProductName = product.ProductName,
        //                CreateDateTime = DateTime.Now,
        //                ModifiDateTime = DateTime.Now,
        //                Price = product.Price,
        //            });
        //        }, cancellationToken)
        //    });

        //    await unitOfWork.CategoryRepository.AddRangeEntitiesAsync(category, cancellationToken);
        //    await unitOfWork.SaveChangesAsync(cancellationToken);
        //    return new GetCategoryAndItsProductsDto();
        //}



        public async Task<GetCategoryAndItsProductsDto> Handle(InsertCategoryAndItsProductsCommand request, CancellationToken cancellationToken)
        {
            var categoryId = await unitOfWork.CategoryRepository.GetCategoryIdByNameAsync(request.insertCategoryAndItsProductsDto.CategoryName, cancellationToken);
            if (categoryId == Guid.Empty)
            {
                await unitOfWork.CategoryRepository.AddEntityAsync(new Entities.Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = request.insertCategoryAndItsProductsDto.CategoryName,
                    CreateDateTime = DateTime.Now,
                    ModifiDateTime = DateTime.Now,
                    Description = request.insertCategoryAndItsProductsDto.Description,
                }, cancellationToken);
            }
            var produsts = new List<Entities.Product>();
            request.insertCategoryAndItsProductsDto.products.ForEach(product =>
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
            //return new GetCategoryAndItsProductsDto(
            //    request.insertCategoryAndItsProductsDto.CategoryName,
            //    request.insertCategoryAndItsProductsDto.Description,new List<InsertProductWithOutCategoryIdDto> { }
            //           new InsertProductWithOutCategoryIdDto{ ProductName = s.ProductName, Price = s.Price });
            return null;
        }
    }
}
