using System;
using System.Collections.Generic;
using ShopSystem;

namespace ConsoleApp
{
    class Program
    {
        private static bool exit = false;
        private static SystemControl _system; //Variable que contiene la dirección de memoria de la instancia de la clase adeministradora
        static void Main(string[] args)
        {
            _system = SystemControl.getSystemControl(); //Variable de acceso a clase administradora(contiene la instancia de la clase administradora)

            _system.preLoad(); //Ejecuta la precarga

            while (!exit)
            {                
                bool optionNotCorrect = true;
                while (optionNotCorrect)
                {
                    Console.Clear();
                    Console.WriteLine("Presione el número de opción en su teclado númerico para realizar la operación correspondiente");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine("1 - Iniciar Sesión");
                    Console.WriteLine("2 - Registrarse");
                    Console.WriteLine("3 - Sistema"); //Acceso a lista de compras y lista de clientes
                    Console.WriteLine("0 - Salir");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            Console.Clear();
                            signIn();
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.Clear();
                            register();
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Console.Clear();
                            system();
                            break;
                        case ConsoleKey.NumPad0:
                        case ConsoleKey.D0:
                            Console.Clear();
                            optionNotCorrect = false;
                            exit = true;
                            break;
                    }
                }
            }
        }

        private static void register()
        {
            try
            {
                bool registerSuccessful = false;
                while (!registerSuccessful)
                {
                    Console.Clear();
                    Console.WriteLine("Seleccione el tipo de cliente");
                    Console.WriteLine("1 - Cliente común");
                    Console.WriteLine("2 - Cliente empresa");
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese su nombre");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ingrese su número de cédula");
                        int identificationCard = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese su celular");
                        string celular = Console.ReadLine();
                        Console.WriteLine("Ingrese su dirección");
                        string address = Console.ReadLine();
                        Console.WriteLine("Ingrese su mail");
                        string mail = Console.ReadLine();
                        Console.WriteLine("Ingrese su usuario");
                        string user = Console.ReadLine();
                        Console.WriteLine("Ingrese su contraseña");
                        string password = Console.ReadLine();
                        Console.WriteLine("Ingrese su Departamento");
                        string departamento = Console.ReadLine();
                        bool isFromMontevideo = false;
                        if (departamento == "Montevideo" || departamento == "montevideo" || departamento == "MONTEVIDEO")
                        {
                            isFromMontevideo = true;
                        }
                        var result = _system.addCommonClient(name, identificationCard, celular, mail, address, user, password, isFromMontevideo);
                        registerSuccessful = result.wasRegisterSuccessful;
                        string message = result.message;
                        Console.Clear();
                    }

                    else if (key == ConsoleKey.NumPad2 || key == ConsoleKey.D2)     //EJEMPLO DE MENU
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre de su empresa");
                        string companyName = Console.ReadLine();
                        Console.WriteLine("Ingrese su razón social");
                        string bussinesName = Console.ReadLine();
                        Console.WriteLine("Ingrese su rut");
                        int rut = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese su dirección");
                        string address = Console.ReadLine();
                        Console.WriteLine("Ingrese su mail");
                        string mail = Console.ReadLine();
                        Console.WriteLine("Ingrese su número telefónico");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Ingrese su usuario");
                        string user = Console.ReadLine();
                        Console.WriteLine("Ingrese su contraseña");
                        string password = Console.ReadLine();
                        Console.WriteLine("Ingrese su Departamento");
                        string departamento = Console.ReadLine();
                        bool isFromMontevideo = false;
                        Console.WriteLine("Ingrese el descuento de su empresa");
                        int discount = Convert.ToInt32(Console.ReadLine());
                        if (departamento == "Montevideo" || departamento == "montevideo" || departamento == "MONTEVIDEO")
                        {
                            isFromMontevideo = true;
                        }
                        var result = _system.addCompanyClient(companyName, bussinesName, rut, address, mail, phone, user, password, isFromMontevideo, discount);
                        registerSuccessful = result.wasRegisterSuccessful;
                        string message = result.message;
                        Console.Clear();
                    }
                    else
                    {
                        continue;
                    }
                    if (registerSuccessful)
                    {
                        Console.WriteLine("El usuario fue registrado correctamente");
                        Console.WriteLine("Presione una tecla para continuar");
                        ConsoleKey _key = Console.ReadKey(true).Key;
                    }
                    else
                    {
                        Console.WriteLine("Los datos no son correcto");
                        Console.WriteLine("Presione la tecla \'v\' para volver al menú principal o cualquier otra tecla para volver a intentarlo");
                        ConsoleKey _key = Console.ReadKey(true).Key;
                        if (_key == ConsoleKey.V)
                        {
                            registerSuccessful = true;
                        }
                    }
                }
            }
            catch(Exception err)
            {
                errorHandling(err);
            }            
        }
        private static void signIn()
        {
            try
            {
                bool wasLoginSuccessful = false;
                while (!wasLoginSuccessful)
                {
                    Console.WriteLine("Ingrese su usuario");
                    string user = Console.ReadLine();
                    Console.WriteLine("Ingrese su contraseña");
                    string password = Console.ReadLine();
                    wasLoginSuccessful = _system.login(user, password);
                    Console.Clear();
                    if (wasLoginSuccessful)
                    {
                        Console.WriteLine("Los datos son correctos, la sesión ha sido iniciada \n \n Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        clientMenu();
                    }
                    else
                    {
                        Console.WriteLine("El usuario o la contraseña no fueron correctos");
                        Console.WriteLine("Presione una tecla para volver a intentarlo o presione \"v\" para volver al menú principal");
                        ConsoleKey _key = Console.ReadKey(true).Key;
                        if(_key == ConsoleKey.V)
                        {
                            wasLoginSuccessful = true;
                        }
                    }
                }                
            }
            catch (Exception err)
            {
                errorHandling(err);
            }            
        }

        private static void system()
        {
            bool optionIsNotCorrect = true;
            while (optionIsNotCorrect)
            {
                bool _optionNotCorrect = true;
                while (_optionNotCorrect)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Agregar productos");
                    Console.WriteLine("2 - Ver clientes registrados");
                    Console.WriteLine("3 - Compras realizadas");
                    Console.WriteLine("0 - Salir");

                    ConsoleKey _key = Console.ReadKey(true).Key; //Obtiene la tecla presionada por el usuario y la almacena dentro de la variable _key
                    switch (_key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            Console.Clear();
                            _optionNotCorrect = false;
                            AddProducts();
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.Clear();
                            _optionNotCorrect = false;
                            DisplayRegisteredClients();
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            printPurchasesList();
                            break;
                        case ConsoleKey.NumPad0:
                        case ConsoleKey.D0:
                            Console.Clear();
                            _optionNotCorrect = false;
                            optionIsNotCorrect = false;
                            break;
                    }
                }

            }
        }
        private static void AddProducts()
        {
            try
            {
                bool idCorrect = false;
                while (!idCorrect)
                {
                    Console.WriteLine("Presione \"v\" para volver u otra teclar para agregar productos");
                    ConsoleKey _l = Console.ReadKey().Key;
                    if (_l == ConsoleKey.V) break;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Seleccione la góndola en la que desea agregar productos");
                        List<ProductStock> categories = _system.getCatalogue();
                        int l = categories.Count;
                        for (int i = 0; i < l; i++)
                        {
                            Console.WriteLine(i + " - " + categories[i].Name);
                        }
                        int _k; int.TryParse(Console.ReadLine(), out _k);
                        Console.Clear();
                        if (_k < l)
                        {
                            bool parseWasCorrect = false;
                            while (!parseWasCorrect)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese el nombre del producto a agregar");
                                string _name = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio del producto a agregar");
                                int _price; bool wasPriceParseCorrect = int.TryParse(Console.ReadLine(), out _price);
                                Console.WriteLine("Ingrese la descripción del producto a agregar");
                                string _description = Console.ReadLine();
                                Console.WriteLine("Ingrese si es exclusivo");
                                bool _isExclusive; bool wasExclusiveParseCorrect = bool.TryParse(Console.ReadLine(), out _isExclusive);
                                Console.WriteLine("Ingrese la cantidad de productos a agregar");
                                int quantity; bool wasQuantityParseCorrect = int.TryParse(Console.ReadLine(), out quantity); 
                                if (wasPriceParseCorrect && wasExclusiveParseCorrect && wasQuantityParseCorrect)
                                {
                                    string result = categories[_k].addProduct(_name, _price, _description, _isExclusive, quantity);
                                    Console.Clear();
                                    Console.WriteLine(result);
                                    parseWasCorrect = true;
                                    idCorrect = true;
                                }
                                else
                                {
                                    Console.WriteLine("Los datos no son correctos.... Presione una tecla para continuar");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Id de catálogo incorrecto, presione un tecla y vuelva a seleccionar el catálogo");
                            Console.ReadKey();
                        }
                    }
                }               
            }
            catch(Exception err)
            {
                errorHandling(err);
            }
        }

        private static void DisplayRegisteredClients()
        {
            bool wasDateEnteredCorrect = false;
            while (!wasDateEnteredCorrect)
            {
                Console.WriteLine("Ingrese la fecha de límite de registro");
                string dateToParse = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParse(dateToParse, out date))
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("|Nombre        |            Mail             |                 Tipo de cliente|");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    wasDateEnteredCorrect = true;
                    var clients = _system.getClientsByDate(date);
                    if (clients.Count > 0)
                    {
                        foreach (Client c in clients)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------");
                            Console.WriteLine("|" + c.getName() + "         |          " + c.Mail + "           |          " + c.ToString() + "         |");
                            Console.WriteLine("-------------------------------------------------------------------------------");
                        }
                    }
                    else Console.WriteLine("No hay clientes registrados antes de la fecha");
                }
                else Console.WriteLine("Ingrese una fecha válida");
            }
            Console.ReadKey();            
        }

        private static void clientMenu()
        {
            bool isLogged = true;
            while (isLogged)
            {
                Console.Clear();
                Console.WriteLine("Presione el número de opción en su teclado númerico para realizar la operación correspondiente");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("1 - Ver catálogo de productos");
                Console.WriteLine("2 - Configuraciones");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

                ConsoleKey _key = Console.ReadKey(true).Key; //Guarda la tecla presionada
                switch (_key)

                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        try
                        {
                            var purchase = _system.getPurchase();
                            bool hasPurchaseEnded = false;
                            while (!hasPurchaseEnded)
                            {                                
                                Console.Clear();
                                Console.WriteLine("Seleccione la categoría");
                                Console.WriteLine("0 - Todas");
                                Console.WriteLine("1 - Frescos");
                                Console.WriteLine("2 - Congelados");
                                Console.WriteLine("3 - Hogar");
                                Console.WriteLine("4 - Textiles");
                                Console.WriteLine("5 - Tecnología");
                                ConsoleKey k = Console.ReadKey(true).Key;
                           

                                Console.Clear();
                                List<ProductStock> productStocks = _system.getCatalogue();
                                string line = "-----------------------------------------------------------------------------------------------";
                                Console.WriteLine(line);
                                Console.WriteLine("|Nombre       |       Precio       Cantidad      |   StockId    |   ProductId|");
                                Console.WriteLine(line);
                                switch (k)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            if (_productStock.Name == "Frescos")
                                            {
                                                List<Product> _products = _productStock.Products;
                                                foreach (Product p in _products)
                                                {
                                                    Console.WriteLine(line);
                                                    Console.WriteLine("|" + p.Name + "       |       " + p.Price + "      |       " + p.Quantity + "      |    " + p.StockId + "      |       " + p.Id);
                                                    Console.WriteLine(line);
                                                }
                                            }
                                        }
                                        break;
                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            if (_productStock.Name == "Congelados")
                                            {
                                                List<Product> _products = _productStock.Products;
                                                foreach (Product p in _products)
                                                {
                                                    Console.WriteLine(line);
                                                    Console.WriteLine("|" + p.Name + "       |       " + p.Price + "        |       " + p.Quantity + "        |      " + p.StockId + "    |      " + p.Id);
                                                    Console.WriteLine(line);
                                                }
                                            }
                                        }
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            if (_productStock.Name == "Hogar")
                                            {
                                                List<Product> _products = _productStock.Products;
                                                foreach (Product p in _products)
                                                {
                                                    Console.WriteLine(line);
                                                    Console.WriteLine("|" + p.Name + "       |       " + p.Price + "       |    " + p.Quantity + "        |       " + p.StockId + "        |       " + p.Id);
                                                    Console.WriteLine(line);
                                                }
                                            }
                                        }
                                        break;
                                    case ConsoleKey.NumPad4:
                                    case ConsoleKey.D4:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            if (_productStock.Name == "Téxtiles")
                                            {
                                                List<Product> _products = _productStock.Products;
                                                foreach (Product p in _products)
                                                {
                                                    Console.WriteLine(line);
                                                    Console.WriteLine("|" + p.Name + "       |       " + p.Price + "          |         " + p.Quantity + "         |     " + p.StockId + "         |       " + p.Id);
                                                    Console.WriteLine(line);
                                                }
                                            }
                                        }
                                        break;
                                    case ConsoleKey.NumPad5:
                                    case ConsoleKey.D5:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            if (_productStock.Name == "Tecnología")
                                            {
                                                List<Product> _products = _productStock.Products;
                                                foreach (Product p in _products)
                                                {
                                                    Console.WriteLine(line);
                                                    Console.WriteLine("|" + p.Name + "       |       " + p.Price + "       |       " + p.Quantity + "       |       " + p.StockId + "      |      " + p.Id);
                                                    Console.WriteLine(line);
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        foreach (ProductStock _productStock in productStocks)
                                        {
                                            List<Product> _products = _productStock.Products;
                                            foreach (Product p in _products)
                                            {
                                                Console.WriteLine(line);
                                                Console.WriteLine("|" + p.Name + "         |          " + p.Price + "      |        " + p.Quantity + "        |        " + p.StockId + "       |        " + p.Id);
                                                Console.WriteLine(line);
                                            }
                                        }
                                        break;
                                }
                                Console.WriteLine("presione \"a\" para agregar productos al carrito");
                                Console.WriteLine("presione \"v\" para volver");
                                bool optionCorrect = false;
                                while (!optionCorrect)
                                {
                                    ConsoleKey o = Console.ReadKey(true).Key;
                                    if (o == ConsoleKey.A)
                                    {
                                        optionCorrect = true;
                                        Console.WriteLine("Ingrese el Id del stock del producto que desea agregar");
                                        int stockId = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Ingrese el Id del producto que desea agregar");
                                        int productId = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Ingrese la cantidad de productos que desea agregar");
                                        int quantity = Convert.ToInt32(Console.ReadLine());
                                        string message = purchase.addToPurchase(stockId, productId, quantity);
                                        Console.Clear();
                                        Console.WriteLine(message);
                                        Console.WriteLine("Precione \"c\" para finalizar la compra o cualquier otra tecla para continuar comprando");
                                        ConsoleKey _k = Console.ReadKey(true).Key;
                                        if (_k == ConsoleKey.C)
                                        {
                                            bool _optionCorrect = false; bool paysByCash = false; bool toDeliver = false;
                                            while (!_optionCorrect)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Elija su forma de pago");
                                                Console.WriteLine("1 - Efectivo");
                                                Console.WriteLine("2 - Tarjeta");
                                                ConsoleKey __k = Console.ReadKey(true).Key;
                                                switch (__k)
                                                {
                                                    case ConsoleKey.NumPad1:
                                                    case ConsoleKey.D1:
                                                        paysByCash = true;
                                                        _optionCorrect = true;
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                    case ConsoleKey.D2:
                                                        paysByCash = false;
                                                        _optionCorrect = true;
                                                        break;
                                                }
                                            }
                                            _optionCorrect = false;
                                            while (!_optionCorrect)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Especifique si pasará a retirar el producto o quiere que se lo envíen");
                                                Console.WriteLine("1 - Retiro");
                                                Console.WriteLine("2 - Envío");
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch (key)
                                                {
                                                    case ConsoleKey.NumPad1:
                                                    case ConsoleKey.D1:
                                                        toDeliver = false;
                                                        _optionCorrect = true;
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                    case ConsoleKey.D2:
                                                        toDeliver = true;
                                                        _optionCorrect = true;
                                                        break;
                                                }
                                            }

                                            purchase.PaysByCash = paysByCash;
                                            purchase.ToDeliver = toDeliver;
                                            message = purchase.buy();
                                            Console.WriteLine(message);
                                            Console.WriteLine("Presione una tecla para continuar");
                                            Console.ReadKey();
                                            hasPurchaseEnded = true;
                                        }
                                    }
                                    else
                                    {
                                        optionCorrect = true;
                                    }
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            errorHandling(err);
                        }
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        settings();
                        break;
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        isLogged = false;
                        break;
                }
            }            
        }

        private static void printPurchasesList()
        {
            bool datesWereCorrect = false;
            while (!datesWereCorrect)
            {
                Console.Clear();
                Console.WriteLine("Ingrese la fecha inicial");
                string d1ToParse = Console.ReadLine();
                DateTime d1;
                Console.WriteLine("Ingrese la fecha final");
                string d2ToParse = Console.ReadLine();
                DateTime d2;
                Console.Clear();
                if (DateTime.TryParse(d1ToParse, out d1) && DateTime.TryParse(d2ToParse, out d2))
                {
                    var purchases = _system.getPurchasesBetweenDates(d1, d2);
                    Console.WriteLine("|  Nombre de cliente           |          fecha de compra                 |             cantidad total de productos  |");
                    if (purchases.Count == 0) Console.WriteLine("No hay compras entre las fechas indicadas");
                    else
                    {
                        foreach (Purchase p in purchases)
                        {
                            if (p.Client.GetType() == typeof(Common))
                            {
                                Console.WriteLine("|  " + ((Common)p.Client).Name + "           |            " + p.Date + "                 |                  " + p.ProductsQuantity + "  |");
                            }
                            if (p.Client.GetType() == typeof(Company))
                            {
                                Console.WriteLine("|  " + ((Company)p.Client).CompanyName + "           |            " + p.Date + "                 |                  " + p.ProductsQuantity + "  |");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese fechas correctas");
                }
                Console.WriteLine("presione \"v\" para volver al menú o presione cualquier tecla para volver a ingresar una fecha");
                ConsoleKey _k = Console.ReadKey(true).Key;
                if (_k == ConsoleKey.V) datesWereCorrect = true;
            }            
        }

        private static void settings() //User settings
        {
            throw new NotImplementedException();
        }        
        
        private static void errorHandling(Exception err)
        {
            Console.Clear();            
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(err.Message);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
    }
}
