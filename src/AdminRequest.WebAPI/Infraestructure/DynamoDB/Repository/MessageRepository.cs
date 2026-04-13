using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using AdminRequest.WebAPI.Infraestructure.DynamoDB.Entity;
using AdminRequest.WebAPI.Infraestructure.DynamoDB.Utils;
using Amazon.DynamoDBv2.DataModel;
using Domain.Entities;

namespace AdminRequest.WebAPI.Infraestructure.DynamoDB.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDynamoDBContext _context;

        public MessageRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(JsonReqMessage message)
        {
            var entity = MessageMapper.ToDynamo(message);
            await _context.SaveAsync(entity);
        }

        public async Task<JsonResMessage> GetByAidAsync(Guid id)
        {
            var entity = await _context.LoadAsync<MessageEntityDynamo>(id.ToString());
            return entity == null ? null : MessageMapper.ToDomain(entity);
        }

        public async Task<List<JsonResMessage>> GetAllAsync()
        {
            var result = await _context.ScanAsync<MessageEntityDynamo>(new List<ScanCondition>())
                .GetRemainingAsync();
            return result.Select(MessageMapper.ToDomain).ToList();
        }

      
    }
}
