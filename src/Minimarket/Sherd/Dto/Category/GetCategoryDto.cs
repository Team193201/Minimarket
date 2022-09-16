namespace Sheard.Dto.Category
{
    public record GetCategoryDto(Guid? CategoryId,string CategoryName, string Description, DateTime CreateDateTime, DateTime ModifiDateTime);
}
