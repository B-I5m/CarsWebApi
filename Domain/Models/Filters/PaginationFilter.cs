namespace Domain.Models.Filters;

public class PaginationFilter
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}