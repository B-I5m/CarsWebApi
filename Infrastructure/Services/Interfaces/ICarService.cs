using Domain.Models.Entities;
using Domain.Models.Filters;

namespace Infrastructure.Services.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetAsync(CarFilter filter);
    Task<Car?> GetByIdAsync(Guid id);
}