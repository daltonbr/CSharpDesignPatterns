using ShoppingCart.Repositories;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product = productsRepository.FindBy("SM7B");

            shoppingCartRepository.Add(product);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);

            shoppingCartRepository.PrintCart();

        }
    }
    
}
