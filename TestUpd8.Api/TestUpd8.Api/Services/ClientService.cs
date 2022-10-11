using System;
using System.Threading.Tasks;
using TestUpd8.Api.Contracts;
using TestUpd8.Api.DTOs.Request;
using TestUpd8.Api.DTOs.Response;
using TestUpd8.Api.Entities;
using TestUpd8.Api.Utils;
using TestUpd8.Api.ViewModels;

namespace TestUpd8.Api.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async ValueTask<CreateClientResponse> AddAsync(CreateClientRequest request)
        {
            var response = new CreateClientResponse();

            if (await _clientRepository.AnyAsync(x => x.Cpf.Equals(request.Cpf)))
            {
                response.Message = ClientMessages.CpfAlreadyExist;
                return response;
            }

            await _clientRepository.AddAsync(Client.New(request.Name, request.Cpf, request.Gender, request.Address, request.State, request.City, request.BirthDate));
            await _clientRepository.SaveChangesAsync();

            response.Message = ClientMessages.ClientCreatedSucessfully;
            response.Sucess = true;
            return response;
        }

        public async ValueTask<DeleteClientResponse> DeleteAsync(Guid id)
        {
            var response = new DeleteClientResponse();

            var client = await _clientRepository.FindByIdAsync(id);

            if (client == null)
            {
                response.Message = ClientMessages.ClientNotFound;
                return response;
            }

            _clientRepository.Delete(client);
            await _clientRepository.SaveChangesAsync();

            response.Message = ClientMessages.ClientDeletedSucessfully;
            response.Sucess = true;
            return response;
        }

        public async ValueTask<GetAllClientResponse> FindAllAsNoTrackingAsync()
        {
            var response = new GetAllClientResponse();
            var clients = await _clientRepository.FindAllAsNoTrackingAsync();

            foreach (var client in clients)
            {
                response.Clients.Add(new ClientListVm
                {
                    Id = client.Id,
                    Name = client.Name,
                    Cpf = client.Cpf,
                    Gender = client.Gender.ToString(),
                    Address = client.Address,
                    City = client.City,
                    State = client.State,
                    BirthDate = client.BirthDate
                });
            }

            response.Sucess = true;
            return response;
        }

        public async ValueTask<GetClientByIdResponse> FindByIdAsync(Guid id)
        {
            var response = new GetClientByIdResponse();

            var client = await _clientRepository.FindByIdAsync(id);

            if (client == null)
            {
                response.Message = ClientMessages.ClientNotFound;
                response.Sucess = true;
                return response;
            }

            response.Client = new ClientVm
            {
                Name = client.Name,
                Cpf = client.Cpf,
                Gender = client.Gender.ToString(),
                Address = client.Address,
                City = client.City,
                State = client.State,
                BirthDate = client.BirthDate
            };

            response.Sucess = true;
            return response;
        }

        public async ValueTask<UpdateClientResponse> UpdateAsync(Guid id, UpdateClientRequest request)
        {
            var response = new UpdateClientResponse();

            var client = await _clientRepository.FindByIdAsync(id);

            if (client == null)
            {
                response.Message = ClientMessages.ClientNotFound;
                return response;
            }

            client.Update(request.Name, request.Cpf, request.Gender, request.Address, request.State, request.City, request.BirthDate);

            _clientRepository.Update(client);
            await _clientRepository.SaveChangesAsync();

            response.Message = ClientMessages.ClientUpdatedSucessfully;
            response.Sucess = true;
            return response;
        }
    }
}
