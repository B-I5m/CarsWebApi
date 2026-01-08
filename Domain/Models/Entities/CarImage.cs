namespace Domain.Models.Entities;

public class CarImage
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public string Url { get; set; } = null!;
    public bool IsMain { get; set; }
}