using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    public class SystemControl
    {
        private SystemControl() { }                                                                  //Private constructor
        private static SystemControl _systemControl = new SystemControl();                           //Just one instance
        public static SystemControl getSystemControl() { return _systemControl; }                    //Get the instance
        private List<Client> clients = new List<Client>();                                           //Clients list
        private List<ProductStock> catalogue = new List<ProductStock>();                             //Catalogue list
        private List<Purchase> purchases = new List<Purchase>();                                     //Purchases list

        public int NumberOfClients { get { return clients.Count; } }
        public List<ProductStock> getCatalogue() { return catalogue; }

        public bool controlAddCommonClient(string name, string celular, string mail, string address,string user, string password, bool isFromMontevideo)
        {
            int id = clients.Count;
            Client _client = Common.AddCommonClient(id, name, celular, address, mail, user, password, isFromMontevideo);
            if (_client != null)
            {
                clients.Add(_client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool controlAddCompanyClient(string companyName, string bussinesName, int rut, string mail, string address, string user, string password, bool isFromMontevideo)
        {
            //TODO controls

            int id = clients.Count;
            Client _client = Company.AddCompanyClient(id, companyName, bussinesName, rut, address, mail, user, password, isFromMontevideo);
            if(_client != null)
            {
                clients.Add(_client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void preLoad()
        {
            controlAddCommonClient("Jorge", "091425631", "jorgito@gmail.com","Bulevar Artigas 87546", "jorge", "jorge", true);
            controlAddCommonClient("Javier", "091879564", "javier@gmail.com", "Bulevar Artigas 97463", "javier", "javier", true);
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

        public void addProduct(ProductStock productStock, string name, int price, string description, string category, bool isExclusive)
        {
            int productStockId = productStock.StockId;
            productStock.addProduct(price, description, category, isExclusive);
        }
    }
}
