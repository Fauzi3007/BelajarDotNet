using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BelajarDotNet.Models.ModelBinding
{
    public class ProductServiceFq
    {
        private readonly List<ProductFq> _products;
        public ProductServiceFq()
        {
            _products = new List<ProductFq>
            {
                new ProductFq { Id = 1, Name = "Smartphone X1", Category = ProductCategoryFq.Electronics, Price = 699.99m, DateAdded = DateTime.Now.AddDays(-10) },
                new ProductFq { Id = 2, Name = "Wireless Headphones", Category = ProductCategoryFq.Audio, Price = 199.99m, DateAdded = DateTime.Now.AddDays(-20) },
                new ProductFq { Id = 3, Name = "Gaming Laptop Pro", Category = ProductCategoryFq.Computers, Price = 1299.99m, DateAdded = DateTime.Now.AddDays(-5) },
                new ProductFq { Id = 4, Name = "4K Action Camera", Category = ProductCategoryFq.Cameras, Price = 299.99m, DateAdded = DateTime.Now.AddDays(-15) },
                new ProductFq { Id = 5, Name = "Smart Home Hub", Category = ProductCategoryFq.SmartHome, Price = 149.99m, DateAdded = DateTime.Now.AddDays(-8) },
                new ProductFq { Id = 6, Name = "Fitness Tracker", Category = ProductCategoryFq.Wearables, Price = 99.99m, DateAdded = DateTime.Now.AddDays(-12) },
                new ProductFq { Id = 7, Name = "Bluetooth Speaker", Category = ProductCategoryFq.Audio, Price = 49.99m, DateAdded = DateTime.Now.AddDays(-18) },
                new ProductFq { Id = 8, Name = "External Hard Drive", Category = ProductCategoryFq.Accessories, Price = 89.99m, DateAdded = DateTime.Now.AddDays(-22) },
                new ProductFq { Id = 9, Name = "Smart TV 55\"", Category = ProductCategoryFq.HomeEntertainment, Price = 799.99m, DateAdded = DateTime.Now.AddDays(-3) },
                new ProductFq { Id = 10, Name = "Gaming Console Z", Category = ProductCategoryFq.Gaming, Price = 499.99m, DateAdded = DateTime.Now},
                new ProductFq { Id = 11, Name = "Noise Cancelling Earbuds", Category = ProductCategoryFq.Audio, Price = 149.99m, DateAdded = DateTime.Now.AddDays(-7) },
                new ProductFq { Id = 12, Name = "4K Ultra HD Monitor", Category = ProductCategoryFq.Computers, Price = 399.99m, DateAdded = DateTime.Now.AddDays(-14) },
                new ProductFq { Id = 13, Name = "Smartwatch Series 5", Category = ProductCategoryFq.Wearables, Price = 249.99m, DateAdded = DateTime.Now.AddDays(-9) },
                new ProductFq { Id = 14, Name = "Digital SLR Camera", Category = ProductCategoryFq.Cameras, Price = 899.99m, DateAdded = DateTime.Now.AddDays(-11) },
                new ProductFq { Id = 15, Name = "Home Theater System", Category = ProductCategoryFq.HomeEntertainment, Price = 599.99m, DateAdded = DateTime.Now.AddDays(-4) },
                new ProductFq { Id = 16, Name = "VR Headset", Category = ProductCategoryFq.Gaming, Price = 349.99m, DateAdded = DateTime.Now.AddDays(-6) },
                new ProductFq { Id = 17, Name = "Tablet Pro 10\"", Category = ProductCategoryFq.Electronics, Price = 449.99m, DateAdded = DateTime.Now.AddDays(-13) },
                new ProductFq { Id = 18, Name = "Wireless Mouse", Category = ProductCategoryFq.Accessories, Price = 29.99m, DateAdded = DateTime.Now.AddDays(-16) },
                new ProductFq { Id = 19, Name = "Smart Light Bulb", Category = ProductCategoryFq.SmartHome, Price = 19.99m, DateAdded = DateTime.Now.AddDays(-17) },
                new ProductFq { Id = 20, Name = "Portable Charger", Category = ProductCategoryFq.Accessories, Price = 39.99m, DateAdded = DateTime.Now.AddDays(-19) },
            };
        }

        public async Task<(IEnumerable<ProductFq> Products, int TotalCount)> GetProductAsync(ProductQueryParametersFq queryParameters) { 
            var products = _products.AsQueryable();

            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                products = products.Where(p => p.Name.Contains(queryParameters.SearchTerm, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrEmpty(queryParameters.Category))
            {
                if (Enum.TryParse(queryParameters.Category, true, out ProductCategoryFq category))
                {
                    products = products.Where(p => p.Category == category);
                }
            }

            int totalCOunt = products.Count();

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                {
                    products = queryParameters.SortAscending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price);
                }
                else if (queryParameters.SortBy.Equals("date", StringComparison.OrdinalIgnoreCase))
                {
                    products = queryParameters.SortAscending ? products.OrderBy(p => p.DateAdded) : products.OrderByDescending(p => p.DateAdded);
                }
            }

            products = products.Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize);

            return await Task.FromResult((products.ToList(), totalCOunt));

        } 
     }
}
