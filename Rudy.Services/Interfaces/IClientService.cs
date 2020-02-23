using System.Collections.Generic;
using System.Threading.Tasks;
using Rudy.Common.Data.Pagination;
using Rudy.DTO;

namespace Rudy.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> GetClient(int id);
        Task<PagedResults<ClientDTO>> GetAll(PagingOptions options);
        Task<CreateResponseDTO> CreateClient(ClientDTO client);
        Task<bool> DeleteClient(int id);
        Task<bool> EditClient(ClientDTOEdit client);
    }
}
