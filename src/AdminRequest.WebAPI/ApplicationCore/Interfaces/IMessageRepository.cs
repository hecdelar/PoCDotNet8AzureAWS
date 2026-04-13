using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using Domain.Entities;

namespace AdminRequest.WebAPI.ApplicationCore.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateAsync(JsonReqMessage message);
        Task<JsonResMessage> GetByAidAsync(Guid id);
        Task<List<JsonResMessage>> GetAllAsync();
    }
}
