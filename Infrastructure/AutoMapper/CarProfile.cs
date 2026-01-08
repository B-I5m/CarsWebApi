using AutoMapper;
using Domain.Models.Entities;

namespace Infrastructure.AutoMapper;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, object>();
    }
}