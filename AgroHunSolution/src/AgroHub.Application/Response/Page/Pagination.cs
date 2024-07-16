using System.Text.Json.Serialization;

namespace AgroHub.Application.Response.Page
{
    public class Pagination<T>
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }
    }
}
