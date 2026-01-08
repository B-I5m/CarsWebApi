

namespace Domain.Models.Entities;

public class Brand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? LogoUrl { get; set; }

    public ICollection<Model> Models { get; set; } = new List<Model>();
}