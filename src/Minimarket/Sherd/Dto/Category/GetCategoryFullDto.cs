namespace Sheard.Dto.Category
{
    public record GetCategoryFullDto(Guid? CategoryId, string CategoryName, string Description, DateTime CreateDateTime, DateTime ModifiDateTime);

}
