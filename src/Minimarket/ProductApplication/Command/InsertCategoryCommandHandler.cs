using Infrastructure.Interface;
using MediatR;
using Sherd.Command.Category;
using Sherd.Dto.Category;

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
    }
}
