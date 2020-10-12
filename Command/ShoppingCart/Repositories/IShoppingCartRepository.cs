using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public interface IShoppingCartRepository
    {
        void Add(Product product);
        void Remove(Product product);
        void RemoveAll(string articleId);
        void IncreaseQuantity(string articleId, int quantityToIncrease);        
        void DecreaseQuantity(string articleId, int quantityToDecrease);
        (Product product, int Quantity) Get(string  articleId);
        void PrintCart();
                   
    }
}
