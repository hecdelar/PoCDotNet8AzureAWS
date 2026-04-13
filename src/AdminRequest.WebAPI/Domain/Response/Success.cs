using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Domain.Response
{
    public class Success : Base
    {
        /// <summary>
        /// Gets or Sets Data
        /// </summary>

        [JsonPropertyName("data")]
        public object data { get; set; }
    }
}
