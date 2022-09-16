namespace Sheard.Dto.Product
{
    public record GetProductDto(string ProductName, decimal Price, Guid? CategoryId, DateTime CreateDateTime, DateTime ModifiDateTime);
}
