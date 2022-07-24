namespace ProductApplication.Dto
{
    public class InsertCategoryDto
    {
        public Guid CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
