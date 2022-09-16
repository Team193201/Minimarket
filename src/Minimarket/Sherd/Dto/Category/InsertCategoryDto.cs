using Sheard.Dto.Product;

namespace Sheard.Dto.Category
{
    public record InsertCategoryDto(string CategoryName, string Description);
    public record InsertCategoryAndItsProductsDto(string CategoryName, string Description, List<InsertProductWithOutCategoryIdDto> products);
}
