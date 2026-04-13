using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// Datos de trazabilidad e información técnica del mensaje.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or Sets UuId
        /// </summary>
        /// <example>c4e6bd04-5149-11e7-b114-a2f933d5fe66</example>
        [Required]
        public Guid uuId { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        /// <example>2017-01-24T05:00:00.000Z</example>
        [Required]
        public string timestamp { get; set; }

        /// <summary>
        /// Gets or Sets SystemId
        /// </summary>
        /// <example>acxff62e-6f12-42de-9012-1e7304418abd</example>
        [Required]
        public string systemId { get; set; }
    }
}
