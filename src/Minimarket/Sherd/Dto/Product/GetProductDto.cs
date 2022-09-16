namespace Sheard.Dto.Product
{
    public record GetProductDto(string ProductName, decimal Price, Guid? CategoryId, DateTime CreateDateTime, DateTime ModifiDateTime);
    public record GetProductFullWithCategoryIdOutput
    {
        public Guid? CatecoryId { get; set; }
        public List<InsertProductWithOutCategoryIdDto> ProductFullDto { get; set; }
    }
}
