using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class ProductStock
    {
        private List<Product> products = new List<Product>();
        private int stockId;
        private string name;
        private int price;

        public int StockId { get { return stockId; } }
        public string Name { get { return name; } }
        public int Price { get { return price; } set { price = value; } }
        public List<Product> ProductsList { get { return products; } }
        public int ProductsQuantity { get { return products.Count; } }

        public void addProduct(string name,int price, string description, bool isExclusive)
        {
            int id = products.Count;
            products.Add(Product.createProduct(name, id, stockId, price, description, isExclusive));
        }

        public List<Product> addToPurchase(int quantity)
        {
            List<Product> productsAdded = new List<Product>();
            for(int i=0; i < quantity; i++)
            {
                productsAdded.Add(products[i]);
            }
            return productsAdded;
        }

        public ProductStock(string name, int id)
        {
            this.name = name;
            this.stockId = id;
        }

        public string removeProduct(int id, int quantity)
        {
            int productsNumber = ProductsList.Count;
            if (quantity > productsNumber) return "There are not enough products";
            else
            {
                for (int i = 0; i < productsNumber; i++)
                {
                    if (ProductsList[i].Id == id) ProductsList.RemoveAt(i);
                }
                return "Products added";
            }
        }
    }
}
