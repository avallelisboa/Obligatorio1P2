using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Purchase
    {
        private Client client;
        private List<ProductStock> productStocks = new List<ProductStock>();
        private List<Product> productsToBuy = new List<Product>();
        private int totalPrice = 0;
        private Purchase(Client client){ this.client = client;}

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
                int id = productsToBuy[i].Id;

            }
            throw new NotImplementedException();
        }

        public void addToPurchase(int stockId, int productId)
        {
           Product _product = productStocks[stockId].ProductsList[productId];
           productsToBuy.Add(_product);
           totalPrice += _product.Price;
        }
    }
}
