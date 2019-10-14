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
        private string category;
        private bool isExclusive;

        public int Id{ get { return id; } set { id = value; } }
        public int StockId{get{return stockId;}}
        public string Name{get{return name;}}
        public int Price{get{return price;}}
        public string Description { get { return description; } }
        public string Category {
            get { return category; }
            set {
                if (value == "Frescos" || value == "Congelados" || value == "Hogar" || value == "Téxtiles" || value == "Tecnología") category = value;
            }
        }
        private bool IsExclusive{get{return isExclusive;}}

        private Product(int id, int stockId, string name, int price, string description,string category, bool isExclusive)
        {
            this.id = id;
            this.stockId = stockId;
            this.name = name;
            this.price = price;
            this.description = description;
            this.category = category;
            this.isExclusive = isExclusive;
        }

        public static Product createProduct(int id, int stockId,string name, int price, string description, string category, bool isExclusive)
        {
            Product product = new Product(id,stockId, name, price, description, category, isExclusive);
            return product;
        }
    }
}
