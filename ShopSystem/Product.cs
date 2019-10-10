using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Product
    {
        private int id;
        private string name;
        private int price;
        private bool isExclusive;

        private Product(int id, string name, int price, bool isExclusive)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.isExclusive = isExclusive;
        }

        ~Product(){}


        public Product createProduct(string name, int price, bool isExclusive)
        {
            Product product = new Product(489465, name,price, isExclusive);
            return product;
        }
    }
}
