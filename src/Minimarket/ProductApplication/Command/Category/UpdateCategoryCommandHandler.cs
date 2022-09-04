using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;

namespace ProductApplication.Command.Category
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, GetCategoryDto>
    {
        IUnitOfWork unitOfWork;
        public UpdateCategoryCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<GetCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.UpdateCategoryAsync(request, cancellationToken);
            unitOfWork.CategoryRepository.UpdateEntity(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new GetCategoryDto(category.CategoryName, category.Description, category.CreateDateTime, category.ModifiDateTime);

        }
    }
}
