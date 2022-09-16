using Infrastructure.Interface;
using MediatR;
using Sheard.Dto.Category;
using Sheard.Query.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Query.Category
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery,List< GetCategoryFullDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetCategoryByNameQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<List<GetCategoryFullDto>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetCategoryByNameAsync(request.CategoryName, cancellationToken);

            //TODO mapping
            return null;/* new GetCategoryFullDto(category.CategoryId, category.CategoryName, category.Description, category.CreateDateTime, category.ModifiDateTime);*/
        }
    }
}

