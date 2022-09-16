namespace Sheard.Dto.Product
{
    public record InsertProductDto(string ProductName, decimal Price, Guid CategoryId);
    public record InsertProductWithOutCategoryIdDto(string ProductName, decimal Price);

    public record ProductFullWithCategoryId
    {
        public Guid? CatecoryId { get; set; }
        public List<InsertProductWithOutCategoryIdDto> Products { get; set; }
    }
}
