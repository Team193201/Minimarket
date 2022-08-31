namespace Sheard.Dto.Product
{
    public record UpdateProductDto(string ProductName, Guid CategoryId, decimal Price);
}
