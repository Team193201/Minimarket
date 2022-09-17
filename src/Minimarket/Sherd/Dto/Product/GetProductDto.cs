namespace Sheard.Dto.Product
{
    public record GetProductDto(string ProductName, decimal Price, Guid ProductId, Guid CategoryId, DateTime CreateDateTime, DateTime ModifiDateTime);
}
