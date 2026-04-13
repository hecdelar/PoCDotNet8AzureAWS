using Domain.Entities;

namespace AdminRequest.WebAPI.ApplicationCore.Interfaces
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(T message, string messageGroupId);
     
    }
}
