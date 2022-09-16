using Sheard.Dto.Product;

namespace Sheard.Dto.Category
{
    public record InsertCategoryAndProductsDto(string CategoryName, string Description, List<InsertProductsDto> Products);
}
