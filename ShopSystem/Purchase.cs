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
        private DateTime date;
        private bool toDeliver;
        private bool paysByCash;
        private Purchase(Client client, List<ProductStock>productStocks)
        {
            this.client = client;
            this.productStocks = productStocks;
            this.date = DateTime.Today;
        }
        private class _product
        {
            public int productId;
            public int stockId;
            public int quantity;
        }

        public bool ToDeliver { get { return toDeliver; } set { toDeliver = value; } }
        public bool PaysByCash { get { return paysByCash; } set { paysByCash = value; } }
        public DateTime Date { get { return date; } }
        
        private int calculatePurchasePrice()
        {
            return totalPrice;
        }

        public static Purchase getPurchase(Client client, List<ProductStock> productStocks)
        {
            return new Purchase(client, productStocks);
        }
   
        public string buy()
        {
            int productsToBuyNumber = productsToBuy.Count;
            int discount = 0;
            for(int i =0 ; i< productsToBuyNumber; i++)
            {
                int productId = productsToBuy[i].productId;
                int stockId = productsToBuy[i].stockId;
                int quantity = productsToBuy[i].quantity;
                productStocks[stockId].removeProduct(productId,quantity);
            }
            if (paysByCash && totalPrice > 5000) discount += 4;
            if (((client.RegisterDate - DateTime.Today).TotalDays / 365) > 2) discount += 5;
            if (client.GetType() == typeof(Common) && !(client.IsFromMontevideo)) discount += 5;
            if (client.GetType() == typeof(Company) && ((client.RegisterDate - DateTime.Today).TotalDays / 365) > 5) discount += ((Company)client).Discount * 2;
            else if (client.GetType() == typeof(Company)) discount += ((Company)client).Discount;
            totalPrice = (100 - discount) * totalPrice / 100;
            if (!(client.IsFromMontevideo) && toDeliver) totalPrice += 1000;
            return "You must pay $" + totalPrice;
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
                if (productStocks[stockId].Products[productId].IsExclusive && _product.quantity > 1)
                {
                    if(_product.quantity > 1) totalPrice += (_product.price) * (_product.quantity - 1);
                }
                else totalPrice += (_product.price) * (_product.quantity);
                return "The products were added correctly";
            }
            else return "The product could not be added";
        }
    }
}
