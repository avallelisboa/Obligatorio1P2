using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSystem
{
    class SystemControl
    {
        private SystemControl() { }        
        private static SystemControl _systemControl = new SystemControl();
        public static SystemControl getSystemControl() { return _systemControl; }
        private List<Client> clients = new List<Client>();
        private List<ProductStock> catalogue = new List<ProductStock>();
        private List<Purchase> purchases = new List<Purchase>();

        public int NumberOfClients { get { return clients.Count; } }
        public List<ProductStock> Catalogue { get { return catalogue; } }

        public bool controlAddCommonClient(string name, string celular, string mail, string address,string user, string password, bool isFromMontevideo)
        {
            Common client = Common.AddCommonClient(name, celular, address, mail, user, password, isFromMontevideo);
            if (client != null)
            {
                clients.Add(client);
                return true;
            }
            else return false;
        }

        public bool controlAddCompanyClient(string companyName, string bussinesName, int rut, string mail, string address, string user, string password, bool isFromMontevideo)
        {
            Company client = Company.AddCompanyClient(companyName, bussinesName, rut, address, mail, user, password, isFromMontevideo);
            if (client != null)
            {
                clients.Add(client);
                return true;
            }
            else return false;
        }

        public void preLoad()
        {
            throw new NotImplementedException();
        }

        public bool findClient(int number)
        {
            bool wasFounded = false;
            foreach(Client client in clients)
            {
                if (client.Number == number)
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

        public void AddToPurchase(int number)
        {
            throw new NotImplementedException();
        }
        public void addProductStock(string name, int price, string description, string category)
        {
            throw new NotImplementedException();
        }
    }
}
