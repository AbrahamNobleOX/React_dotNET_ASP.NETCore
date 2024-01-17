namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Product name
        public string Description { get; set; } // Product description
        public long Price { get; set; } // Product price in cents
        public string PictureUrl { get; set; } // URL of the product image
        public string Type { get; set; } // Product type
        public string Brand { get; set; } // Product brand
        public int QuantityInStock { get; set; } // Quantity of the product in stock
        public string PublicId { get; set; } // Public ID of the product image
    }
}