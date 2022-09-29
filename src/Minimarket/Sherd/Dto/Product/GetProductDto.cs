namespace Sheard.Dto.Product
{
    public record GetProductDto(string ProductName, int Price, Guid ProductId, Guid CategoryId, DateTime CreateDateTime, DateTime ModifiDateTime);
}
