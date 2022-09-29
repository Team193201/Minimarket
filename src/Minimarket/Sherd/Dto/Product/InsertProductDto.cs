namespace Sheard.Dto.Product
{
    public record InsertProductDto(string ProductName, int Price, Guid CategoryId);
}
