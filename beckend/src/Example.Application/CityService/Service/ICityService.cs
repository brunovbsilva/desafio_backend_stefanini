﻿using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllCitiesResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(int id);
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request);
        Task<DeleteCityResponse> DeleteAsync(int id);
    }
}
