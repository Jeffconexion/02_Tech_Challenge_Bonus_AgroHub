using AgroHub.Domain.Entities;
using System.Text.Json.Serialization;

namespace AgroHub.Application.Dtos
{
    public class ProductDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        public Product ToEntity()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                CreateDate = DateTime.Now,
                Image = Image,
                Value = Value,
                Quantity = Quantity,
                Unit = Unit,
                Category = new Category
                {
                    Name = Name
                }
            };
        }

    }
}
