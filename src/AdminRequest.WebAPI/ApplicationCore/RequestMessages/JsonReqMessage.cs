using AdminRequest.WebAPI.Domain.Enum;
using MediatR;

namespace AdminRequest.WebAPI.ApplicationCore.RequestMessages
{
    public partial class JsonReqMessage 
    {
       
        public Guid id { get; set; }

        public string name { get; set; } = default!;
               
        public string payload { get; set; } = default!;

        public Status status { get; set; }

        public DateTime createAt { get; set; }
    }
}
