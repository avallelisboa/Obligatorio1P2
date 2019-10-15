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

        public bool addCommonClient(string name, string celular, string mail, string address,string user, string password, bool isFromMontevideo)
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

        public bool addCompanyClient(string companyName, string bussinesName, int rut, string mail, string phone, string address, string user, string password, bool isFromMontevideo)
        {
            //TODO controls

            int id = clients.Count;
            Client _client = Company.AddCompanyClient(id, companyName, bussinesName, rut, address, mail,phone, user, password, isFromMontevideo);
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
            addCommonClient("Jorge", "091425631", "jorgito@gmail.com","Bulevar Artigas 87546", "jorge", "jorge", true);
            addCommonClient("Javier", "091879564", "javier@gmail.com", "Bulevar Artigas 97463", "javier", "javier", true);
            addCommonClient("Juan", "091879564", "juan@gmail.com", "Bulevar Artigas 1087465", "juan", "juan", false);

            addCompanyClient("company1", "company1 s.a.", 154684654, "company1@gmail.com", "25842143579", "Luis Alberto de Herrera 154843223", "company1", "company1", true);
            addCompanyClient("company2", "company2 s.a.", 878746845, "company2@gmail.com", "65487651321", "Luis Alberto de Herrera 648948455", "company2", "company2", true);
            addCompanyClient("company3", "company3 s.a.", 346456148, "company3@gmail.com", "324564561551", "Luis Alberto de Herrera 878456456", "company3", "company3", false);

            addProductStock("Frescos"); addProductStock("Congelados"); addProductStock("Hogar"); addProductStock("Téxtiles"); addProductStock("Tecnología");

            catalogue[0].addProduct("Escarola", 59, "Precio por Kg", false);
            catalogue[0].addProduct("Espinaca", 24, "Precio por Kg", false);

            catalogue[1].addProduct("Croquetas", 99, "Precio por Kg", false);
            catalogue[1].addProduct("Buñuelo", 40, "Precio por Kg", false);

            catalogue[2].addProduct("Detergente", 60, "Precio por L", false);
            catalogue[2].addProduct("Jabón de manos", 35,"Precio por unidad", false);

            catalogue[3].addProduct("Toallas", 70, "Precio por unidad", false);
            catalogue[3].addProduct("Sábanas", 150, "Precio por unidad", false);

            catalogue[4].addProduct("PC Gamer", 12500, "Precio por unidad", false);
            catalogue[4].addProduct("Televisor Led", 15000, "Precio por unidad", true);
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

        public string addProductStock(string name)
        {
            int id = catalogue.Count;
            bool wasFounded = false;
            foreach(ProductStock s in catalogue)
            {
                if (s.Name == name) wasFounded = true;
            }
            if (!wasFounded)
            {
                catalogue.Add(new ProductStock(name,id));
                return "The product stock was successfully created";
            }
            else return "The product stock was already created";
        }
    }
}
