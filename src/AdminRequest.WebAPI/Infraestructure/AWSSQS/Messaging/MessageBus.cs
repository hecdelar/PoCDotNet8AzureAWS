using System.Text.Json;
using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.Infraestructure.AWSSQS.Utils;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

namespace AdminRequest.WebAPI.Infraestructure.AWSSQS.Messaging
{
    public class MessageBus : IMessageBus
    {

        private readonly IAmazonSQS _sqs;
        private readonly SqsOptions _options;

        public MessageBus(IAmazonSQS sqs, IOptions<SqsOptions> options)
        {
            _sqs = sqs;
            _options = options.Value;
        }

        public async Task PublishAsync<T>(T message, string messageGroupId)
        {

            var request = new SendMessageRequest
            {
                QueueUrl = _options.queueUrl,
                MessageBody = JsonSerializer.Serialize(message),
                MessageGroupId = messageGroupId,
                MessageDeduplicationId = Guid.NewGuid().ToString()
            };

            await _sqs.SendMessageAsync(request);
           

        }
    }
}
