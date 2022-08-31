namespace Sheard.Dto.Product
{
    public record InsertProductDto(string ProductName, decimal Price, Guid CategoryId);
}
