using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;

namespace ProductApplication.Command
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, GetCategoryDto>
    {
        private IUnitOfWork UnitOfWork;
        public InsertCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<GetCategoryDto> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryNameAsync(request.Dto.CategoryName, cancellationToken);
            if (existCategory)
                throw new ArgumentNullException($"{request.Dto.CategoryName} is exist");

            UnitOfWork.CategoryRepository.AddEntity(new Entities.Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.Dto.CategoryName,
                Description = request.Dto.CategoryName,
                CreateDateTime = DateTime.UtcNow,
                ModifiDateTime = default
            });
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return new GetCategoryDto(request.Dto.CategoryName, request.Dto.Description, DateTime.UtcNow, default);
        }
    }
}
