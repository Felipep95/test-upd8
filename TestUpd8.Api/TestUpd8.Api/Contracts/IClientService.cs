using System;
using System.Threading.Tasks;
using TestUpd8.Api.DTOs.Request;
using TestUpd8.Api.DTOs.Response;

namespace TestUpd8.Api.Contracts
{
    public interface IClientService
    {
        ValueTask<CreateClientResponse> AddAsync(CreateClientRequest request);
        ValueTask<GetClientByIdResponse> FindByIdAsync(Guid id);
        ValueTask<GetAllClientResponse> FindAllAsNoTrackingAsync();
        ValueTask<UpdateClientResponse> UpdateAsync(Guid id, UpdateClientRequest request);
        ValueTask<DeleteClientResponse> DeleteAsync(Guid id);
    }
}
