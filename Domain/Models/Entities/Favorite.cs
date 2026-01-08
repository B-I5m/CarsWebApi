namespace Domain.Models.Entities;

public class Favorite
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public Guid CarId { get; set; }

    public DateTime CreatedAt { get; set; }
}