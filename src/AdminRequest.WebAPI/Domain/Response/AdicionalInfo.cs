using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Response

{
    /// <summary>
    /// Objeto que describe los codigos y los mensajes adicionales
    /// </summary>
    public partial class AdicionalInfo
    {
        /// <summary>
        /// codigo personalizable por el negocio para homologar los codigos del backend.
        /// </summary>
        /// <value>codigo personalizable por el negocio para homologar los codigos del backend.</value>
        /// <example>100-999</example>
        [JsonPropertyName("codigo")]
        [Required]
        public string Codigo { get; set; }

        /// <summary>
        /// Es la descripcion del mensaje personalizable para homologar los mensajes del backend.
        /// </summary>
        /// <value>Es la descripcion del mensaje personalizable para homologar los mensajes del backend.</value>
        /// <example>mensaje definido por el area.</example>
        [JsonPropertyName("detalle")]
        [Required]
        public string Detalle { get; set; }
    }
}
