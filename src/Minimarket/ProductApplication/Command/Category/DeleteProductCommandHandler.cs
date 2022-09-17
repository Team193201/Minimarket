using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;

namespace ProductApplication.Command.Category
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Guid>
    {
        private readonly IUnitOfWork UnitOfWork;
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await UnitOfWork.CategoryRepository.GetCategoryByIdAsync(request.categoryId, cancellationToken);
            UnitOfWork.CategoryRepository.DeleteEntity(category);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return request.categoryId;
        }
    }
}
