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
            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryNameAsync(request.CategoryName, cancellationToken);
            if (!existCategory)
            {
                UnitOfWork.CategoryRepository.AddEntity(new Entities.Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = request.CategoryName,
                    Picture = request.Picture,
                    Description = request.Description
                });
                await UnitOfWork.SaveChangesAsync(cancellationToken);
                return new InsertCategoryDto
                {
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    Picture = request.Picture,
                };
            }
            else
            {
                throw new NullReferenceException("category is exist");
            }
        }
    }
}
