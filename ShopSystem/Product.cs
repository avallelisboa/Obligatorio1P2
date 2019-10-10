using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Product
    {
        private int id;
        private int stockId;
        private string name;
        private int price;
        private bool isExclusive;

        public int Id{get{return id;}}
        public int stockId{get{return stockId;}}
        public string Name{get{return name;}}
        public int Price{get{return price;}}
        private bool IsExclusive{get{return isExclusive;}}

        private Product(int id, int stockId, string name, int price, bool isExclusive)
        {
            this.id = id;
            this.stockId = stockId;
            this.name = name;
            this.price = price;
            this.isExclusive = isExclusive;
        }

        public Product createProduct(int id,string name, int price, bool isExclusive)
        {
            Product product = new Product(id, name,price, isExclusive);
            return product;
        }
    }
}
