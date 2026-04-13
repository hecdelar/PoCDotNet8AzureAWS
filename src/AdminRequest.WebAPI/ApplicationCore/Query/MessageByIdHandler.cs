using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using AdminRequest.WebAPI.Domain.Enum;
using Domain.Entities;
using MediatR;

namespace AdminRequest.poc.WebAPI.ApplicationCore.Command
{
    public class MessageByIdHandler : IRequestHandler<JsonReqMessageById, JsonResMessage>
    {
        private readonly IMessageRepository _repository;

        /// <summary>
        /// Metodo Constructor
        /// </summary>
        /// <param name="db"></param>
        public MessageByIdHandler(IMessageRepository repository)
        {
              _repository = repository;
        }

        /// <summary>
        /// Handle del command de inserciÓn
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResMessage> Handle(JsonReqMessageById request, CancellationToken cancellationToken)
        {
            try
            {
               
                var response = await _repository.GetByAidAsync(request.id);
                
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
