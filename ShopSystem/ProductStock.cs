using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class ProductStock
    {
        private List<Product> products = new List<Product>();
        private int stockId;
        private int productsQuantity = 0;
        private string name;
        private int price;
        private string category;

        public int StockId { get { return stockId; } }
        public string Name { get { return name; } }
        public int Price { get { return price; } set { price = value; } }
        public List<Product> ProductsList { get { return products; } }
        public string  Category { get { return category;} set { if (value == "Frescos" || value == "Congelados" || value == "Hogar" || value == "Téxtiles" || value == "Tecnología") category = value; } }
        public int ProductsQuantity { get { return productsQuantity; } }

        public void addProduct(int price, string description, bool isExclusive)
        {
            int id = products.Count;
            products.Add(Product.createProduct(id, stockId, name, price, description, isExclusive));
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

        public ProductStock(string name, int stockId, string category)
        {
            this.name = name;
            this.stockId = stockId;
            this.category = category;
        }

        public void deleteProduct(int id)
        {
            products.RemoveAt(id);
            int productsNumber = ProductsList.Count;
            for(int i =0; i< productsNumber; i++)
            {
                ProductsList[i].Id = i;
            }
        }
    }
}
