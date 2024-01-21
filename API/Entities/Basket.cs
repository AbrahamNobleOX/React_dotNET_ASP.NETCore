namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>(); // list of items in the basket (initialized to empty list)

        // add an item to the basket or update the quantity if it already exists
        public void AddItem(Product product, int quantity)
        {
            // if the product is not already in the basket, add it
            if (Items.All(item => item.ProductId != product.Id))
            {
                // add the product to the basket
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
                return;
            }

            // if the product is already in the basket, update the quantity
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null) existingItem.Quantity += quantity;
        }

        // remove an item from the basket or update the quantity if it already exists
        public void RemoveItem(int productId, int quantity = 1)
        {
            var item = Items.FirstOrDefault(basketItem => basketItem.ProductId == productId); // find the item in the basket

            if (item == null) return; // if the item is not in the basket, return

            item.Quantity -= quantity; // update the quantity of the item

            if (item.Quantity == 0) Items.Remove(item); // if the quantity is 0, remove the item from the basket
        }
    }
}