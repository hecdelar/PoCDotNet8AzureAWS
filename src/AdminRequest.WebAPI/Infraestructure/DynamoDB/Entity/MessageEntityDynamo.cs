namespace AdminRequest.WebAPI.Infraestructure.DynamoDB.Entity
{
    using AdminRequest.WebAPI.Domain.Enum;
    using Amazon.DynamoDBv2.DataModel;
    [DynamoDBTable("Messages")]
    public class MessageEntityDynamo
    {
        [DynamoDBHashKey]
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string payload { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public DateTime createAt { get; set; }
    }
}
