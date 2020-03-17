using System.Threading.Tasks;
using System.Collections.Generic;
using Rudy.DTO;
using Rudy.Services.Interfaces;
using Rudy.Persistence;
using AutoMapper;
using Rudy.Models;
using Rudy.Common.Data.Pagination;
using System;

namespace Rudy.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ClientDTO> GetClient(int id)
        {
            var clientModel = await _unitOfWork.Clients.SingleOrDefault(c => c.id == id);

            return _mapper.Map<ClientDTO>(clientModel);
        }

        public async Task<PagedResults<ClientDTO>> GetAll(PagingOptions options)
        {
            var clients = await _unitOfWork.Clients.GetAll(options);

            return _mapper.Map<PagedResults<ClientDTO>>(clients);
        }

        public async Task<CreateResponseDTO> CreateClient(ClientDTO client)
        {
            try
            {
                var clientModel = _mapper.Map<Client>(client);
                _unitOfWork.Clients.Add(clientModel);

                if (await _unitOfWork.Complete() > 0)
                    return _mapper.Map<CreateResponseDTO>(clientModel);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditClient(ClientDTOEdit client)
        {
            try
            {
                var clientModel = _mapper.Map<Client>(client);
                _unitOfWork.Clients.Update(clientModel);

                return (await _unitOfWork.Complete() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteClient(int id)
        {
            try
            {
                var client = await _unitOfWork.Clients.SingleOrDefault(c => c.id == id);

                if (client != null)
                {
                    _unitOfWork.Clients.Remove(client);

                    return (await _unitOfWork.Complete() > 0) ? true : false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
