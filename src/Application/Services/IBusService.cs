using System;
using System.Threading.Tasks;
using Application.Contracts.DTOs;

namespace Application.Services
{
    public interface IBusService
    {
        Task<Guid> AddBusAsync(AddBusDto input);
    }
}