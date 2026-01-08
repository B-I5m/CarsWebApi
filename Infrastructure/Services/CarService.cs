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
        var q = _db.Cars
            .Include(x => x.Images)
            .Where(x => x.IsActive)
            .AsQueryable();

        if (filter.PriceFrom != null)
            q = q.Where(x => x.Price >= filter.PriceFrom);

        if (filter.PriceTo != null)
            q = q.Where(x => x.Price <= filter.PriceTo);

        if (filter.SortBy != null)
        {
            q = filter.SortBy switch
            {
                "price" => filter.Desc ? q.OrderByDescending(x => x.Price) : q.OrderBy(x => x.Price),
                "year"  => filter.Desc ? q.OrderByDescending(x => x.Year)  : q.OrderBy(x => x.Year),
                _       => q.OrderByDescending(x => x.CreatedAt)
            };
        }

        q = q.Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

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