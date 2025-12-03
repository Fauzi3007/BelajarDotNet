namespace BelajarDotNet.Models.Model_Binding
{
    public class ProductFq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategoryFq Category { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
