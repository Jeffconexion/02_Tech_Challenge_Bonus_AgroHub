namespace AgroHub.Application.DataTransferObject
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Image { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
