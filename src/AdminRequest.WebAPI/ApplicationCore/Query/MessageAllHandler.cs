using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.Domain.Enum;
using AdminRequest.WebAPI.Infraestructure.DynamoDB.Repository;
using Domain.Entities;
using MediatR;

namespace AdminRequest.poc.WebAPI.ApplicationCore.Command
{

    public record MessageAllMessagesQuery() : IRequest<List<JsonResMessage>>;

    public class MessageAllHandler : IRequestHandler<MessageAllMessagesQuery, List<JsonResMessage>>
    {
        private readonly IMessageRepository _repository;

        /// <summary>
        /// Metodo Constructor
        /// </summary>
        /// <param name="db"></param>
        public MessageAllHandler(IMessageRepository repository)
        {
              _repository = repository;
        }

        /// <summary>
        /// Handle del command de inserciÓn
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<JsonResMessage>> Handle(MessageAllMessagesQuery request, CancellationToken cancellationToken)
        {
            try
            {
               
                var response = await _repository.GetAllAsync();
                
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
