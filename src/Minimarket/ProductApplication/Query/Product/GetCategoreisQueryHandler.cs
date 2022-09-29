using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Category;
using Sheard.Query.Category;

namespace ProductApplication.Query.Product
{
    public class GetCategoreisQueryHandler : IRequestHandler<GetCategoreisQuery, List<GetCategoryDto>>
    {
        private readonly IUnitOfWork UnitOfWork;

        public GetCategoreisQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<List<GetCategoryDto>> Handle(GetCategoreisQuery request, CancellationToken cancellationToken)
        {
            var result = await UnitOfWork.CategoryRepository.GetCategoreisAsync(request.Take, request.Skip, cancellationToken);

            return result.Select(s => new GetCategoryDto(s.CategoryId, s.CategoryName, s.Description, s.CreateDateTime, s.ModifiDateTime)).ToList();
        }
    }
}
