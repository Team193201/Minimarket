using MediatR;
using ProductApplication.Dto;

namespace ProductApplication.Command
{
    public class InsertCategoryCommand : IRequest<InsertCategoryDto>
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
