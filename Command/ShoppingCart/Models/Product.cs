namespace ShoppingCart.Models
{
    public class Product
    {
        public string ArticleId;
        public string Description;
        public int Price;

        public Product(string articleId, string description, int price)
        {
            ArticleId = articleId;
            Description = description;
            Price = price;
        }
    }
}