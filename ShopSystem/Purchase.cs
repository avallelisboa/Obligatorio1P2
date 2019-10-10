using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class Purchase
    {
        private Client client;
        List<Product> productsToBuy = new List<Product>();

        private Purchase(Client client){ this.client = client}

        public static Purchase getPurchase(Client client)
        {
            return new Purchase(client);
        }

        public bool buy()
        {
            throw new NotImplementedException();
        }

        
    }
}
