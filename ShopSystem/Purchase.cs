using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Purchase
    {
        private Client client;
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
            
        }

        public string addToPurchase(ProductStock productStock, Product product, int quantity)
        {
            bool wasFounded = false;
            List<Product> products = productStock.ProductsList;
            int productsNumber = productStock.ProductsQuantity;
            int productsAdded = 0;
            if(quantity <= productsNumber)
            {
                for(int i=0;i<productsNumber;i++)
                {
                    if(products[i] == product)
                    {
                        productsToBuy.Add(products[i]);
                        productsAdded++;
                        totalPrice += products[i].price;
                    }
                    if(productsAdded == quantity) break;
                }
                return "The products were added successfully";
            }
            else
            {
                return "The are not enough products in stock to add";
            }           
        }
    }
}
