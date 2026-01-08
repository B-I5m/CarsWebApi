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
}