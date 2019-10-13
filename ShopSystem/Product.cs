using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class Product
    {
        private int id;
        private int stockId;
        private string name;
        private int price;
        private string description;
        private bool isExclusive;

        public int Id{ get { return id; } set { id = value; } }
        public int StockId{get{return stockId;}}
        public string Name{get{return name;}}
        public int Price{get{return price;}}
        public string Description { get { return description; } }
        private bool IsExclusive{get{return isExclusive;}}

        private Product(int id, int stockId, string name, int price, string description,string category, bool isExclusive)
        {
            this.id = id;
            this.stockId = stockId;
            this.name = name;
            this.price = price;
            this.description = description;
            this.isExclusive = isExclusive;
        }

        public static Product createProduct(int id, int stockId,string name, int price, string description, string category, bool isExclusive)
        {
            Product product = new Product(id,stockId, name, price, description, category, isExclusive);
            return product;
        }
    }
}
