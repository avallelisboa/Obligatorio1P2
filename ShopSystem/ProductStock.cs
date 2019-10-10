using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class ProductStock
    {
        private List<Product> products = new List<Product>();
        private int id;
        private int productsQuantity = 0;
        private string name;
        private int price;
        private string description;
        private string category;

        public string Name { get { return name; } }
        public int Price { get { return price; } set { price = value; } }
        public List<Product> ProductsList { get { return products; } }
        public string  Category { get { return category;} set { if (value == "Frescos" || value == "Congelados" || value == "Hogar" || value == "Téxtiles" || value == "Tecnología") category = value; } }
        public int ProductsQuantity { get { return productsQuantity; } }
        public string Description { get {return description } set { description = value; } }

        public void addProducts(int ammount)
        {
            productsQuantity += ammount;
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

        public void deleteProduct(int id)
        {
            products.RemoveAt(id);
        }
    }
}
