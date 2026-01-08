namespace Domain.Models.Filters;

public class CarFilter
{
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
    public int? YearFrom { get; set; }
    public int? YearTo { get; set; }
    public Guid? CityId { get; set; }
    public Guid? BrandId { get; set; }
}