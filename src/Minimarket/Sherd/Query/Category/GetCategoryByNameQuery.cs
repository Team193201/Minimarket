using MediatR;
using Sheard.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheard.Query.Category
{
    public record GetCategoryByNameQuery(string CategoryName) : IRequest<List<GetCategoryFullDto>>;
}
