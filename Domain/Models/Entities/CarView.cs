namespace Domain.Models.Entities;

public class CarView
{
    public Guid Id { get; set; }

    public Guid CarId { get; set; }
    public Guid? UserId { get; set; }

    public DateTime ViewedAt { get; set; }
}