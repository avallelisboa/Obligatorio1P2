using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Purchase
    {
        private Client client;
        private List<ProductStock> productStocks = new List<ProductStock>();
        private List<_product> productsToBuy = new List<_product>();
        private int totalPrice = 0;
        private Purchase(Client client){ this.client = client;}
        private class _product
        {
            public int productId;
            public int stockId;
            public int quantity;
        }


        private int calculatePurchasePrice()
        {
            return totalPrice;
        }

        public static Purchase getPurchase(Client client)
        {
            return new Purchase(client);
        }

        public string buy()
        {
            int productsToBuyNumber = productsToBuy.Count;
            for(int i =0 ; i< productsToBuyNumber; i++)
            {
                int productId = productsToBuy[i].productId;
                int stockId = productsToBuy[i].stockId;
                int quantity = productsToBuy[i].quantity;
                productStocks[stockId].removeProduct(productId,quantity);
            }
            return "Debe pagar $" + totalPrice;
        }

        public string addToPurchase(int stockId, int productId, int quantity)
        {
           var _product = productStocks[stockId].addToPurchase(quantity, productId);
            if (_product.wasAdded)
            {
                _product p = new _product();
                p.productId = _product.id;
                p.stockId = stockId;
                p.quantity = _product.quantity;
                productsToBuy.Add(p);
                totalPrice += _product.price;
                return "The products were added correctly";
            }
            else return "The product could not be added";
        }
    }
}
