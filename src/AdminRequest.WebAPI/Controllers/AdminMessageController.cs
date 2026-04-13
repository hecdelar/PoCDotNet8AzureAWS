using System.Net;
using AdminRequest.poc.Utils.Controller;
using AdminRequest.poc.WebAPI.ApplicationCore.Command;
using AdminRequest.WebAPI.ApplicationCore.RequestMessages;
using Domain;
using Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdminRequest.poc.WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ControllerName("Admin Message")]
    public class AdminMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        private const string msgErrorCampoNoPermitido = "Valor no permitido en el campo";

        public AdminMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear el Mensaje
        /// </summary>
        /// <param name="body">JsonReqMessage</param>
        /// <param name="uuId">Identificador del mensaje se usa para trazabilidad. Este identificador permite identificar los logs de los llamados a las APIs en los repositorios de logs, recomienda enviar un UUID para este valor.</param>
        /// <param name="timestamp">Tiempo de ejecucion de inicio de la trasaccion.</param>
        /// <param name="systemId">identificador de la aplicacion consumidora</param>
        /// <response code="200">Success</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <response code="504">El servicio no está obtendiendo respuesta a tiempo.</response>
        [HttpPost("Message")]
        [SwaggerResponse(statusCode: 200, type: typeof(Success), description: "Success")]
        [SwaggerResponse(statusCode: 500, type: typeof(Failure), description: "Error interno del servidor.")]
        [SwaggerResponse(statusCode: 504, type: typeof(Failure), description: "El servicio no está obtendiendo respuesta a tiempo.")]
        public async Task<ActionResult<Success>> Message([FromBody] JsonReqMessage body, [FromHeader]Guid uuId, [FromHeader] string timestamp, [FromHeader] string systemId)
        {

            Meta meta = new Meta { systemId = systemId, timestamp = timestamp, uuId = uuId };

            try
            {
                
                string response = await _mediator.Send(new MessageCreateCommand(
                    body.id,
                    body.name,
                    body.payload,  
                    body.status,
                    body.createAt
                    )
                );
               
                return new Success
                {
                    meta = meta,
                    statusCodigo = (int)HttpStatusCode.OK,
                    statusDesc = HttpStatusCode.OK.ToString(),
                    data = response
                };


            }
            catch(Exception ex)
            {
                return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError,
                                                        new Failure
                                                        {
                                                            meta = meta,
                                                            statusCodigo = (int)HttpStatusCode.InternalServerError,
                                                            statusDesc = HttpStatusCode.InternalServerError.ToString()
                                                        }));
            }
            
        }

        /// <summary>
        /// Consultar mensaje por Id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="uuId">Identificador del mensaje se usa para trazabilidad. Este identificador permite identificar los logs de los llamados a las APIs en los repositorios de logs, recomienda enviar un UUID para este valor.</param>
        /// <param name="timestamp">Tiempo de ejecucion de inicio de la trasaccion.</param>
        /// <param name="systemId">identificador de la aplicacion consumidora</param>
        /// <response code="200">Success</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <response code="504">El servicio no está obtendiendo respuesta a tiempo.</response>
        [HttpGet("Message/{id:guid}")]
        [SwaggerResponse(statusCode: 200, type: typeof(Success), description: "Success")]
        [SwaggerResponse(statusCode: 500, type: typeof(Failure), description: "Error interno del servidor.")]
        [SwaggerResponse(statusCode: 504, type: typeof(Failure), description: "El servicio no está obtendiendo respuesta a tiempo.")]
        public async Task<ActionResult<Success>> MessageById(Guid id, [FromHeader] Guid uuId, [FromHeader] string timestamp, [FromHeader] string systemId)
        {

            Meta meta = new Meta { systemId = systemId, timestamp = timestamp, uuId = uuId };

            try
            {
                JsonReqMessageById request = new JsonReqMessageById { id = id };
                var response = await _mediator.Send(request);

                return new Success
                {
                    meta = meta,
                    statusCodigo = (int)HttpStatusCode.OK,
                    statusDesc = HttpStatusCode.OK.ToString(),
                    data = response
                };


            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError,
                                                        new Failure
                                                        {
                                                            meta = meta,
                                                            statusCodigo = (int)HttpStatusCode.InternalServerError,
                                                            statusDesc = HttpStatusCode.InternalServerError.ToString()
                                                        }));
            }

        }

        /// <summary>
        /// Consultar todos los mensajes
        /// </summary>
        /// <param name="uuId">Identificador del mensaje se usa para trazabilidad. Este identificador permite identificar los logs de los llamados a las APIs en los repositorios de logs, recomienda enviar un UUID para este valor.</param>
        /// <param name="timestamp">Tiempo de ejecucion de inicio de la trasaccion.</param>
        /// <param name="systemId">identificador de la aplicacion consumidora</param>
        /// <response code="200">Success</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <response code="504">El servicio no está obtendiendo respuesta a tiempo.</response>
        [HttpGet("Message")]
        [SwaggerResponse(statusCode: 200, type: typeof(Success), description: "Success")]
        [SwaggerResponse(statusCode: 500, type: typeof(Failure), description: "Error interno del servidor.")]
        [SwaggerResponse(statusCode: 504, type: typeof(Failure), description: "El servicio no está obtendiendo respuesta a tiempo.")]
        public async Task<ActionResult<Success>> MessageAll([FromHeader] Guid uuId, [FromHeader] string timestamp, [FromHeader] string systemId)
        {

            Meta meta = new Meta { systemId = systemId, timestamp = timestamp, uuId = uuId };

            try
            {
                
                var response = await _mediator.Send(new MessageAllMessagesQuery());

                return new Success
                {
                    meta = meta,
                    statusCodigo = (int)HttpStatusCode.OK,
                    statusDesc = HttpStatusCode.OK.ToString(),
                    data = response
                };


            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode((int)HttpStatusCode.InternalServerError,
                                                        new Failure
                                                        {
                                                            meta = meta,
                                                            statusCodigo = (int)HttpStatusCode.InternalServerError,
                                                            statusDesc = HttpStatusCode.InternalServerError.ToString()
                                                        }));
            }

        }

    }
}
