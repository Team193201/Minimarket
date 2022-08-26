using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;

namespace ProductApplication.Command
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, InsertCategoryDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<InsertCategoryDto> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryNameAsync(request.categoryName, cancellationToken);
            if (existCategory)
                throw new ArgumentNullException($"{request.categoryName} is exist");

            UnitOfWork.CategoryRepository.AddEntity(new Entities.Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.categoryName,
                Picture = request.picture,
                Description = request.description
            });
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return new InsertCategoryDto
            {
                CategoryName = request.categoryName,
                Description = request.description,
                Picture = request.picture,
            };
        }
    }
}
