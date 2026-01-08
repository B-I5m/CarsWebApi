namespace Domain.Models.Entities;

public class Model
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }

    public string Name { get; set; } = null!;
}