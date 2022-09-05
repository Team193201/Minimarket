using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Category;
using Sheard.Query.Category;

namespace ProductApplication.Query.Category
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryDto>
    {
        IUnitOfWork unitOfWork;
        public GetCategoryByIdQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<GetCategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            //TODO you frist check exist data and after that get data
            //there is mistake becuse you send two request to database and this is not well
            var existCategory = await unitOfWork.CategoryRepository.AnyCategoryIdAsync(request.CategoryId, cancellationToken);
            if (existCategory)
            {
                var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);
                var categoryResult = new GetCategoryDto
                (
                     category.CategoryName,
                     category.Description,
                     category.ModifiDateTime,
                     category.CreateDateTime
                );
                return categoryResult;
            }
            return null;
        }
    }
}
