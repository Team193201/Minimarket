namespace Sheard.Dto.Product
{
    public record UpdateProductDto(Guid ProductId, string ProductName, Guid CategoryId, decimal Price);
}
