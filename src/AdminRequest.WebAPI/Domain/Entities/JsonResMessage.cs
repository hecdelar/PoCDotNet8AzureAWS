using AdminRequest.WebAPI.Domain.Enum;
using MediatR;

namespace Domain.Entities
{
    public partial class JsonResMessage
    {
        /// <summary>
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// </summary>
        public string payload { get; set; }

        public Status status { get; set; }

        public DateTime createAt { get; set; }
    }
}
