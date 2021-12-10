namespace CarProject.Core.Dto
{
    public class PagedAdvertDto
    {
        public long Id { get; set; }
        public string ModelName { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Km { get; set; }
        public string Color { get; set; }
        public string Gear { get; set; }
        public string Fuel { get; set; }
        public string FirstPhoto { get; set; }
    }
}
