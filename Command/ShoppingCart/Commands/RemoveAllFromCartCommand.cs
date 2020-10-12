using System.Linq;
using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCart.Commands
{
    public class RemoveAllFromCartCommand
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly Product _product;

        public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCartRepository,
                                        IProductRepository productRepository,
                                        Product product)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _product = product;
        }
        
        public void Execute()
        {
            var items = _shoppingCartRepository.All().ToArray(); // Cache

            foreach (var lineItem in items)
            {
                _productRepository.IncreaseStockBy(lineItem.product.ArticleId, lineItem.quantity);
                _shoppingCartRepository.RemoveAll(lineItem.product.ArticleId);
            }
        }

        public bool CanExecute()
        {
            return _shoppingCartRepository.All().Any();
        }

        public void Undo()
        {
            // we could cache the lineItem from Execute() so we can have some cache to Undo
            throw new System.NotImplementedException();
        }
    }
}