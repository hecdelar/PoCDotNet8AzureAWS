using Domain.Entities;
using MediatR;

namespace AdminRequest.WebAPI.ApplicationCore.RequestMessages
{
    public partial class JsonReqMessageById : IRequest<JsonResMessage>
    {
        /// <summary>
        /// </summary>
        public Guid id { get; set; }

    }
}
