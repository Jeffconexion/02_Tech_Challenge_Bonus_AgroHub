using AgroHub.Application.Dtos;
using System.Text.Json.Serialization;

namespace AgroHub.Application.Request
{
    public class ProductRequest
    {
        [JsonPropertyName("data")]
        public List<ProductDto> Data { get; set; }
    }
}
