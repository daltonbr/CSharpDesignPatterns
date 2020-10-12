using System;
using ShoppingCart.Commands;
using ShoppingCart.Repositories;

namespace ShoppingCart
{
    class Program
    {
        private static void Main(string[] args)
        {
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product1 = productsRepository.FindBy("SM7B");
            var product2 = productsRepository.FindBy("EOSR1");

            var addProduct1ToCartCommand = new AddToCartCommand(
                shoppingCartRepository,
                productsRepository,
                product1);
            
            var addProduct2ToCartCommand = new AddToCartCommand(
                shoppingCartRepository,
                productsRepository,
                product2);
            
            var increaseProduct1QuantityCommand = new ChangeQuantityCommand(
                ChangeQuantityCommand.Operation.Increase,
                shoppingCartRepository,
                productsRepository,
                product1);

            var manager = new CommandManager();
            manager.Invoke(addProduct1ToCartCommand);
            manager.Invoke(addProduct2ToCartCommand);
            manager.Invoke(increaseProduct1QuantityCommand);
            manager.Invoke(increaseProduct1QuantityCommand);
            manager.Invoke(increaseProduct1QuantityCommand);
            
            shoppingCartRepository.PrintCart();
            
            manager.Undo();
            
            Console.WriteLine("--After Undoing--");
            shoppingCartRepository.PrintCart();
            
            // shoppingCartRepository.Add(product);
            // shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            // shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            // shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            // shoppingCartRepository.IncreaseQuantity(product.ArticleId);

            

        }
    }
    
}
