﻿using Example.Application.PersonService.Models.Request;
using Example.Application.PersonService.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.PersonService.Service
{
    public interface IPersonService
    {
        Task<GetAllPeopleResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(int id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request);
        Task<DeletePersonResponse> DeleteAsync(int id);
    }
}
