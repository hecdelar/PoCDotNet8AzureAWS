using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Domain.Response
{
    [BindNever]
    public class Base
    {
        /// <summary>
        /// Gets or Sets Meta
        /// </summary>

        public Meta meta { get; set; }

        /// <summary>
        /// Codigo de estado HTTP (status codigo) asociado al mensaje  de la respuesta del llamado a la API.
        /// </summary>
        /// <value>Codigo de estado HTTP (status codigo) asociado al mensaje  de la respuesta del llamado a la API.</value>
        [Required]
        public decimal statusCodigo { get; set; }

        /// <summary>
        /// Titulo asociado al código de estado HTTP (status codigo) asociado al mensaje  de la respuesta del llamado a la API.
        /// </summary>
        /// <value>Titulo asociado al código de estado HTTP (status codigo) asociado al mensaje  de la respuesta del llamado a la API.</value>
        [Required]
        public string statusDesc { get; set; }

        /// <summary>
        /// Lista de codigos y mensajes controlados
        /// </summary>
        /// <value>Lista de codigos y mensajes controlados</value>

        public List<AdicionalInfo> adicionalInfo { get; set; }

    }
}
