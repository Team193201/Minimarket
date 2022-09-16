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
            var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);
            category.CategoryName = request.Dto.CategoryName;
            category.Description = request.Dto.description;
            category.ModifiDateTime = DateTime.Now;

            unitOfWork.CategoryRepository.UpdateEntity(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return new GetCategoryDto(request.CategoryId, category.CategoryName, category.Description, category.CreateDateTime, category.ModifiDateTime);

        }
    }
}
