namespace CarProject.Core.Model
{
    public class AdvertQueryParameters
    {
        public int? CategoryId { get; set; }
        public double? PriceLow { get; set; }
        public double? PriceMax { get; set; }
        public Gear? Gear { get; set; }
        public Fuel? Fuel { get; set; }
        public SortField? Sort { get; set; } = SortField.Year;
        public SortDirection SortDirection { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; } = 5;

    }
}
