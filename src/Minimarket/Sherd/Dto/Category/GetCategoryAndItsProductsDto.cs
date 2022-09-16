using Sheard.Dto.Product;

namespace Sheard.Dto.Category
{
    public record GetCategoryAndItsProductsDto(string CategoryName, string Description, List<InsertProductWithOutCategoryIdDto> products);
}
