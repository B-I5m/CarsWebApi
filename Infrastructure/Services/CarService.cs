using Domain.Models.Entities;
using Domain.Models.Filters;
using Infrastructure.Data;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _db;

    public CarService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Car>> GetAsync(CarFilter filter)
    {
        var q = _db.Cars.Include(x => x.Images).AsQueryable();

        if (filter.PriceFrom != null)
            q = q.Where(x => x.Price >= filter.PriceFrom);

        if (filter.PriceTo != null)
            q = q.Where(x => x.Price <= filter.PriceTo);

        if (filter.YearFrom != null)
            q = q.Where(x => x.Year >= filter.YearFrom);

        if (filter.YearTo != null)
            q = q.Where(x => x.Year <= filter.YearTo);

        return await q.ToListAsync();
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        var car = await _db.Cars
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (car != null)
        {
            car.ViewsCount++;
            await _db.SaveChangesAsync();
        }

        return car;
    }
}