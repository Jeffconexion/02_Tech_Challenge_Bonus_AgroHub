using AgroHub.Domain.Entities;

namespace AgroHub.Application.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
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
