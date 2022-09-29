namespace Sheard.Dto.Product
{
    public record UpdateProductDto(string ProductName, Guid CategoryId, int Price);
}
