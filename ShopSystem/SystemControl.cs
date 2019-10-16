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
        private List<ProductStock> catalogue = new List<ProductStock>();                             //Lista de productStocks(las categorías). Para cada categoría hay un productStock
        private List<Purchase> purchases = new List<Purchase>();                                     //Purchases list
        private Client loggedClient;
        public int NumberOfClients { get { return clients.Count; } }
        public List<ProductStock> getCatalogue() { return catalogue; }

        public class registerStatus
        {
            public registerStatus(bool wasRegisterSuccessful, string message)
            {
                this.wasRegisterSuccessful = wasRegisterSuccessful;
                this.message = message;
            }
            public bool wasRegisterSuccessful;
            public string message;
        }

        public registerStatus addCommonClient(string name, int identificationCard, string celular, string mail, string address,string user, string password, bool isFromMontevideo)
        {
            int id = clients.Count;
            var isClientInformationCorrect = Client.isInformationCorrect(clients, user, mail);
            bool isMailUsed = isClientInformationCorrect.isMailUsed;
            bool isUserUsed = isClientInformationCorrect.isUserUsed;

            List<Common> commonClientList = new List<Common>();
            foreach(Client c in clients)
            {
                if(c.GetType() == typeof(Common))
                {
                    commonClientList.Add((Common)c);
                }
            }
            var isCommonClientInformationCorrect = Common.isInformationCorrect(commonClientList, identificationCard);
            bool isIdentificationCardUsed = isCommonClientInformationCorrect.isIdentificationCardUsed;
            if (!isMailUsed && !isUserUsed && !isIdentificationCardUsed)
            {
                Client _client = Common.AddCommonClient(id, name, identificationCard, celular, address, mail, user, password, isFromMontevideo);
                clients.Add(_client);
                return new registerStatus(true, "The user was registered successfully");
            }
            else return new registerStatus(false, "The client was not registered");
        }

        public registerStatus addCompanyClient(string companyName, string bussinesName, int rut, string mail, string phone, string address, string user, string password, bool isFromMontevideo)
        {
            int id = clients.Count;
            var isClientInformationCorrect = Client.isInformationCorrect(clients, user, mail);
            bool isMailUsed = isClientInformationCorrect.isMailUsed;
            bool isUserUsed = isClientInformationCorrect.isUserUsed;

            List<Company> companyClientList = new List<Company>();
            foreach (Client c in clients)
            {
                if (c.GetType() == typeof(Company))
                {
                    companyClientList.Add((Company)c);
                }
            }
            var isCompanyClientInformationCorrect = Company.isInformationCorrect(companyClientList,companyName,bussinesName,rut);
            bool isCompanyNameUsed = isCompanyClientInformationCorrect.isCompanyNameUsed;
            bool isBussinesNameUsed = isCompanyClientInformationCorrect.isBussinesNameUsed;
            bool isRutUsed = isCompanyClientInformationCorrect.isRutUsed;
            if (!isMailUsed && !isUserUsed && !isCompanyNameUsed && !isBussinesNameUsed && !isRutUsed)
            {
                Client _client = Company.AddCompanyClient(id, companyName, bussinesName, rut, address, mail, phone, user, password, isFromMontevideo);
                clients.Add(_client);
                return new registerStatus(true,"The user was registered successfully");
            }
            else return new registerStatus(false, "The client was not registered");
        }

        public void preLoad()
        {
            addCommonClient("Jorge",45876212, "091425631", "jorgito@gmail.com","Bulevar Artigas 87546", "jorge", "jorge", true);
            addCommonClient("Javier",54789653, "091879564", "javier@gmail.com", "Bulevar Artigas 97463", "javier", "javier", true);
            addCommonClient("Juan",16549829, "091879564", "juan@gmail.com", "Bulevar Artigas 1087465", "juan", "juan", false);

            addCompanyClient("company1", "company1 s.a.", 154684654, "company1@gmail.com", "25842143579", "Luis Alberto de Herrera 154843223", "company1", "company1", true);
            addCompanyClient("company2", "company2 s.a.", 878746845, "company2@gmail.com", "65487651321", "Luis Alberto de Herrera 648948455", "company2", "company2", true);
            addCompanyClient("company3", "company3 s.a.", 346456148, "company3@gmail.com", "324564561551", "Luis Alberto de Herrera 878456456", "company3", "company3", false);

            addProductStock("Frescos"); addProductStock("Congelados"); addProductStock("Hogar"); addProductStock("Téxtiles"); addProductStock("Tecnología"); //Categorías precargadas

            catalogue[0].addProduct("Escarola", 59, "Precio por Kg", false);            //Nombre, precio, descripción, esDeMontevideo
            catalogue[0].Products[0].addProducts(100);
            catalogue[0].addProduct("Espinaca", 24, "Precio por Kg", false);
            catalogue[0].Products[1].addProducts(100);

            catalogue[1].addProduct("Croquetas", 99, "Precio por Kg", false);
            catalogue[1].Products[0].addProducts(100);
            catalogue[1].addProduct("Buñuelo", 40, "Precio por Kg", false);
            catalogue[1].Products[1].addProducts(100);

            catalogue[2].addProduct("Detergente", 60, "Precio por L", false);
            catalogue[2].Products[0].addProducts(100);
            catalogue[2].addProduct("Jabón de manos", 35,"Precio por unidad", false);
            catalogue[2].Products[1].addProducts(100);

            catalogue[3].addProduct("Toallas", 70, "Precio por unidad", false);
            catalogue[3].Products[0].addProducts(100);
            catalogue[3].addProduct("Sábanas", 150, "Precio por unidad", false);
            catalogue[3].Products[1].addProducts(100);

            catalogue[4].addProduct("PC Gamer", 12500, "Precio por unidad", false);
            catalogue[4].Products[0].addProducts(100);
            catalogue[4].addProduct("Televisor Led", 15000, "Precio por unidad", true);
            catalogue[4].Products[1].addProducts(1);

            login("jorge", "jorge");
            var purchase1 = getPurchase();
            purchase1.addToPurchase(0, 0, 10);
            purchase1.buy();
            var purchase2 = getPurchase();
            purchase2.addToPurchase(0, 1, 10);
            purchase2.buy();
            login("javier", "Javier");
            var purchase3 = getPurchase();
            purchase3.addToPurchase(1, 0, 10);
            purchase3.buy();
            var purchase4 = getPurchase();
            purchase4.addToPurchase(1, 1, 10);
            purchase4.buy();
            login("juan", "juan");
            var purchase5 = getPurchase();
            purchase5.addToPurchase(2, 0, 10);
            purchase5.buy();
            var purchase6 = getPurchase();
            purchase6.addToPurchase(2, 1, 10);
            purchase6.buy();
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
                    loggedClient = client;
                    break;
                }
            }
            if (wasFounded && isPasswordCorrect) return true;
            else return false;
        }

        public Purchase getPurchase()
        {
            if (loggedClient != null)
            {
                Purchase _purchase = Purchase.getPurchase(loggedClient, catalogue);
                purchases.Add(_purchase);
                return _purchase;
            }
            else throw new Exception("There is no logged user");
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
