using System;
using System.Collections.Generic;
using ShopSystem;

namespace ConsoleApp
{
    class Program
    {
        private static bool exit = false;
        private static SystemControl _system;
        static void Main(string[] args)
        {
            _system = SystemControl.getSystemControl();
            _system.preLoad();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Presione el número de opción en su teclado númerico para realizar la operación correspondiente");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("1 - Iniciar Sesión");
                Console.WriteLine("2 - Registrarse");
                Console.WriteLine("3 - Sistema");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                bool optionNotCorrect = true;
                while (optionNotCorrect)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.NumPad1:
                            outLoop();
                            signIn();
                            break;
                        case ConsoleKey.NumPad2:
                            outLoop();
                            register();
                            break;
                        case ConsoleKey.NumPad3:
                            outLoop();
                            system();
                            break;
                        case ConsoleKey.NumPad0:
                            outLoop();
                            exit = true;
                            break;
                    }
                }
                void outLoop()
                {
                    Console.Clear();
                    optionNotCorrect = false;
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
                    if (key == ConsoleKey.NumPad1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese su nombre");
                        string name = Console.ReadLine();
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
                        registerSuccessful = _system.controlAddCommonClient(name, celular, mail, address, user, password, isFromMontevideo);
                        Console.Clear();
                    }

                    else if (key == ConsoleKey.NumPad2)
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
                        registerSuccessful = _system.controlAddCompanyClient(companyName, bussinesName, rut, address, mail, user, password, isFromMontevideo);
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
                        Console.WriteLine("Los datos son correctos, la sesión ha sido iniciada \n Presione una tecla para continuar");
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
                Console.Clear();

                /*TODO
                    - Dada una fecha indicar los clientes registrados en esa fecha(Nombre, Email y tipo de cliente)
                    - Alta de productos en el catálogo
                */
            }
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
                Console.WriteLine("2 - Ver carrito de compras");
                Console.WriteLine("3 - Configuraciones");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                ConsoleKey _key = Console.ReadKey(true).Key;
                switch (_key)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("Seleccione la categoría");
                        Console.WriteLine("0 - Todas");
                        Console.WriteLine("1 - Frescos");
                        Console.WriteLine("2 - Congelados");
                        Console.WriteLine("3 - Hogar");
                        Console.WriteLine("4 - Textiles");
                        Console.WriteLine("5 - Tecnología");
                        ConsoleKey k = Console.ReadKey(true).Key;
                        productsCatalogue(k);
                        break;
                    case ConsoleKey.NumPad2:
                        purchase();
                        break;
                    case ConsoleKey.NumPad3:
                        settings();                        
                        break;
                    case ConsoleKey.NumPad0:
                        isLogged = false;
                        break;
                }
            }
            
        }

        private static void productsCatalogue(ConsoleKey k)
        {
            try
            {
                List<ProductStock> productStocks = _system.getCatalogue();
                Console.WriteLine("Nombre              Precio       Cantidad        StockId");
                switch (k)
                {
                    case ConsoleKey.NumPad1:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            if (_productStock.Category == "Frescos") Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
                        }
                        break;
                    case ConsoleKey.NumPad2:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            if (_productStock.Category == "Congelados") Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
                        }
                        break;
                    case ConsoleKey.NumPad3:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            if (_productStock.Category == "Hogar") Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
                        }
                        break;
                    case ConsoleKey.NumPad4:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            if (_productStock.Category == "Téxtiles") Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
                        }
                        break;
                    case ConsoleKey.NumPad5:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            if (_productStock.Category == "Tecnología") Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
                        }
                        break;
                    default:
                        foreach (ProductStock _productStock in productStocks)
                        {
                            Console.WriteLine(_productStock.Name + "              " + _productStock.Price + "       " + _productStock.ProductsQuantity + "        " + _productStock.StockId);
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
                        Console.WriteLine("Ingrese la cantidad de productos que desea agregar");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        //To Finish
                    }
                    else if (o == ConsoleKey.V)
                    {
                        optionCorrect = true;
                    }
                }
            }
            catch(Exception err)
            {
                errorHandling(err);
            }
        }

        private static void purchase()
        {
            try
            {
                throw new NotImplementedException();
            }

            catch (Exception err)
            {
                errorHandling(err);
            }
        }

        private static void settings()
        {
            try
            {
                throw new NotImplementedException();
            }
            
            catch(Exception err)
            {
                errorHandling(err);
            }
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
