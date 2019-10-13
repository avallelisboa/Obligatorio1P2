using System;
using ShopSystem;

namespace ConsoleApp
{
    class Program
    {
        private const string welcome = "";
        private static bool exit = false;
        private static SystemControl _system;
        static void Main(string[] args)
        {
            _system = SystemControl.getSystemControl();
            //_system.preLoad();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(welcome);
                Console.WriteLine("Presione el número de opción en su teclado númerico para realizar la operación correspondiente");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("1 - Iniciar Sesión");
                Console.WriteLine("2 - Registrarse");
                Console.WriteLine("3 - Configuraciones");
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
                            setUp();
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

        private static void setUp()
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

        private static void clientMenu()
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
