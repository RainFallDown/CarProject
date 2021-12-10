namespace CarProject.Core.Dto
{
    public class QueryAdvertDto
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public List<PagedAdvertDto> Adverts { get; set; }
    }
}
