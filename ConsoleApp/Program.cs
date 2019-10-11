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
                            login();
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
        private static void login()
        {
            try
            {
                _system = SystemControl.getSystemControl();
                bool loginSuccessful = false;
                while (!loginSuccessful)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese su usuario");
                    string user = Console.ReadLine();
                    Console.WriteLine("Ingrese su contraseña");
                    string password = Console.ReadLine();
                    bool wasLoginSuccessful = _system.login(user, password);
                    if (wasLoginSuccessful)
                    {
                        Console.Clear();
                        signIn();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("El usuario o la contraseña no fue correcto");
                        Console.WriteLine("Presione la tecla \'v\' para volver al menú principal o cualquier otra tecla para volver a intentarlo");
                        ConsoleKey key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.V)
                        {
                            loginSuccessful = true;
                        }
                    }

                }
            }
            catch (Exception err)
            {
                errorHandling(err);
            }
            
        }

        private static void register()
        {
            try
            {
                throw new NotImplementedException();

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
                        //TODO
                    }
                    else if (key == ConsoleKey.NumPad2)
                    {
                        //TODO
                    }
                    else
                    {
                        continue;
                    }
                    bool wasRegisterSuccessful = false;
                    if (wasRegisterSuccessful)
                    {
                        registerSuccessful = true;
                        Console.Clear();
                        Console.WriteLine("El usuario fue registrado correctamente");
                        Console.WriteLine("Presione una tecla para continuar");
                        ConsoleKey _key = Console.ReadKey(true).Key;
                    }
                    else
                    {
                        Console.Clear();
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
                throw new NotImplementedException();
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
