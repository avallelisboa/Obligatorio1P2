using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class SystemControl
    {
        private SystemControl() { }        
        private static SystemControl _systemControl = new SystemControl();
        public static SystemControl getSystemControl() { return _systemControl; }
        private List<Client> clients = new List<Client>();
        private List<ProductStock> catalogue = new List<ProductStock>();
        private List<Purchase> purchases = new List<Purchase>();

        public int NumberOfClients { get { return clients.Count; } }
        public List<ProductStock> getCatalogue() { return catalogue; }

        public void controlAddCommonClient(string name, string celular, string mail, string address,string user, string password, bool isFromMontevideo)
        {
            int id = clients.Count;
            clients.Add(Common.AddCommonClient(id ,name, celular, address, mail, user, password, isFromMontevideo));
        }

        public void controlAddCompanyClient(string companyName, string bussinesName, int rut, string mail, string address, string user, string password, bool isFromMontevideo)
        {
            int id = clients.Count;
            clients.Add(Company.AddCompanyClient(id,companyName, bussinesName, rut, address, mail, user, password, isFromMontevideo));               
        }

        public void preLoad()
        {
            throw new NotImplementedException();
        }

        public bool findClient(int id)
        {
            bool wasFounded = false;
            foreach(Client client in clients)
            {
                if (client.Id == id)
                {
                    wasFounded = true;
                    break;
                }                
            }
            if (wasFounded) return true;
            else return false;
        }

        public bool login(string user, string password)
        {
            bool wasFounded = false;
            bool isPasswordCorrect = false;
            foreach (Client client in clients)
            {
                if (client.User == user)
                {
                    wasFounded = true;
                    if (client.Password == password) isPasswordCorrect = true;
                    break;
                }
            }
            if (wasFounded && isPasswordCorrect) return true;
            else return false;
        }

        public void getPurchase(Client client)
        {
            if (findClient(client.Id))
            {
                Purchase _purchase = Purchase.getPurchase(client);
            }           

        }

        public void addProductStock(string name, string description)
        {
            int id = catalogue.Count;
            catalogue.Add(new ProductStock(name,id,description));
        }

        public void addProduct(ProductStock productStock, string name, int price, string description, bool isExclusive)
        {
            int productStockId = productStock.StockId;
            productStock.addProduct(price, description, isExclusive);
        }
    }
}
