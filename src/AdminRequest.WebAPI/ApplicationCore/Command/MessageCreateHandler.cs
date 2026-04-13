using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using AdminRequest.WebAPI.Domain.Enum;
using MediatR;

namespace AdminRequest.poc.WebAPI.ApplicationCore.Command
{
    public record MessageCreateCommand(
      Guid id,
      string name,
      string payload,
      Status status,
      DateTime createAt 
      ) : IRequest<string>;
    public class MessageCreateHandler : IRequestHandler<MessageCreateCommand, string>
    {
        private readonly IMessageRepository _repository;
        private readonly IMessageBus _messageBus;

        /// <summary>
        /// Metodo Constructor
        /// </summary>
        /// <param name="db"></param>
        public MessageCreateHandler(IMessageRepository repository,
                                    IMessageBus messageBus)
        {
              _repository = repository;
              _messageBus = messageBus; 
        }

        /// <summary>
        /// Handle del command de inserciÓn
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(MessageCreateCommand request, CancellationToken cancellationToken)
        {
            JsonReqMessage message = new JsonReqMessage();
            try
            {

                message.id = request.id;
                message.name = request.name;   
                message.payload = request.payload;
                message.status = request.status;
                message.createAt = request.createAt;


                await _repository.CreateAsync(message);

                await _messageBus.PublishAsync(message,messageGroupId:"admin-request");

                return request.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
