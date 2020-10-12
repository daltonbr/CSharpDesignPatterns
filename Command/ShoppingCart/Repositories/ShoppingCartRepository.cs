using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    class ShoppingCartRepository : IShoppingCartRepository
    {
        private Dictionary<string, (Product Product, int Quantity)> _products { get; }

        public ShoppingCartRepository()
        {
            _products = new Dictionary<string, (Product Product, int Quantity)>();    
        }
 
        public void Add(Product product)
        {
            if (_products.ContainsKey(product.ArticleId))
            {
                return;
            }
            _products.Add(product.ArticleId, (product, 1));
        }

        public void Remove(Product product)
        {
            if (_products.ContainsKey(product.ArticleId))
            {
                _products.Remove(product.ArticleId);
            }
        }

        public void RemoveAll(string articleId)
        {
            if (_products.ContainsKey(articleId))
            {
                _products.Remove(articleId);
            }
        }

        public void IncreaseQuantity(string articleId, int quantityToIncrease = 1)
        {
            if (quantityToIncrease <= 0)
            {
                throw new ArgumentException("QuantityToIncrease must be a positive integer value");
            }
            if (!_products.ContainsKey(articleId))
            {
                return;
            }
            _products[articleId] = (_products[articleId].Product, _products[articleId].Quantity + quantityToIncrease);
        }

        public void DecreaseQuantity(string articleId, int quantityToDecrease = 1)
        {
            if (quantityToDecrease <= 0)
            {
                throw new ArgumentException("QuantityToDecrease must be a positive integer value");
            }
            if (!_products.ContainsKey(articleId))
            {
                return;
            }
            _products[articleId] = (_products[articleId].Product, _products[articleId].Quantity - quantityToDecrease);
        }

        public (Product product, int Quantity) Get(string articleId)
        {
            if (_products.ContainsKey(articleId))
            {
                return (_products[articleId].Product, _products[articleId].Quantity);
            }
            return (null, 0);
        }

        public void PrintCart()
        {
            // we want something like this
            
            //SM7B $399 x 5 = $1995
            //Total price:    $1995
            
            int cartTotalPrice = 0;
            foreach (var product in _products)
            {
                var p = product.Value.Product;
                var q = product.Value.Quantity;
                var productTotal = p.Price * q;
                cartTotalPrice += productTotal;

                System.Console.WriteLine($"{p.ArticleId} \t\t ${p.Price} x {q} = \t${productTotal}");
            }
            System.Console.WriteLine($"Total price: \t\t\t${cartTotalPrice}");            
        }        

    }
}
