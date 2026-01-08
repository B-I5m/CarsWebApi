
using Domain.Models.Enums;
using DriveType = Domain.Models.Enums.DriveType;

namespace Domain.Models.Entities;

public class Car
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }
    public Currency Currency { get; set; }

    public int Year { get; set; }
    public int Mileage { get; set; }
    public MileageUnit MileageUnit { get; set; }

    public BodyType BodyType { get; set; }
    public Transmission Transmission { get; set; }
    public FuelType FuelType { get; set; }
    public DriveType DriveType { get; set; }
    public CarCondition Condition { get; set; }

    public double EngineVolume { get; set; }

    public Guid BrandId { get; set; }
    public Guid ModelId { get; set; }
    public Guid CityId { get; set; }
    public Guid UserId { get; set; }

    public bool IsExchange { get; set; }
    public bool IsCredit { get; set; }
    public bool IsInstallment { get; set; }

    public bool IsActive { get; set; } = true;
    public int ViewsCount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<CarImage> Images { get; set; } = new List<CarImage>();
}
