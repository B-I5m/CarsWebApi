using Domain.Models.Entities;
using Domain.Models.Filters;
using Domain.Response;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
    private readonly ICarService _service;

    public CarsController(ICarService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ApiResponse<object>> Get([FromQuery] CarFilter filter)
    {
        var cars = await _service.GetAsync(filter);
        return ApiResponse<object>.Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<object>> GetById(Guid id)
    {
        var car = await _service.GetByIdAsync(id);
        if (car == null)
            return ApiResponse<object>.Fail("Not found");

        return ApiResponse<object>.Ok(car);
    }
    [HttpPost("{carId}/images")]
    public async Task<IActionResult> UploadImage(
        Guid carId,
        IFormFile file,
        [FromServices] IImageService imageService)
    {
        var url = await imageService.UploadAsync(file);

        _db.CarImages.Add(new CarImage
        {
            Id = Guid.NewGuid(),
            CarId = carId,
            Url = url,
            IsMain = false
        });

        await _db.SaveChangesAsync();
        return Ok(url);
    }

}