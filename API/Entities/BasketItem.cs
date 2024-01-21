using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        public int Id { get; set; } // primary key
        public int Quantity { get; set; } // quantity of products in basket

        // navigation properties
        public int ProductId { get; set; } // foreign key to Product table
        public Product Product { get; set; } // Product

        public int BasketId { get; set; } // foreign key to Basket table
        public Basket Basket { get; set; }
    }
}