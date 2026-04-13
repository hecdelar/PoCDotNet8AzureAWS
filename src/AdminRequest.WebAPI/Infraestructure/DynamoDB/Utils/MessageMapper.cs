using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using AdminRequest.WebAPI.Domain.Enum;
using AdminRequest.WebAPI.Infraestructure.DynamoDB.Entity;
using Domain.Entities;

namespace AdminRequest.WebAPI.Infraestructure.DynamoDB.Utils
{
    public static class MessageMapper
    {
        public static MessageEntityDynamo ToDynamo(JsonReqMessage m)
        {
            return new MessageEntityDynamo
            {
                id = m.id.ToString(),
                name = m.name,
                payload = m.payload,    
                status = m.status.ToString(),
                createAt = m.createAt
            };
        }

        public static JsonResMessage ToDomain(MessageEntityDynamo m)
        {
            return new JsonResMessage
            {
                id = Guid.Parse(m.id),
                name = m.name,
                payload = m.payload,
                status = Enum.Parse<Status>(m.status),
                createAt = m.createAt
            };
        }
    }
}
