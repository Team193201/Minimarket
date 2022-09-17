using Sheard.Dto.Product;

namespace Sheard.Dto.Category
{
    public record GetCategoryAndProductsDto(string CategoryName, string Description, List<GetProductDto> products);
}
