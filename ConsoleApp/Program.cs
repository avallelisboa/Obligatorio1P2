using System;
using ShopSystem;

namespace ConsoleApp
{
    class Program
    {
        private const string welcome = "";
        private static bool exit = false;
        static void Main(string[] args)
        {
            SystemControl _system = SystemControl.getSystemControl();
           // _system.preLoad();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(welcome);
                Console.WriteLine("Presione el número de opción en su teclado númerico para realizar la operación correspondiente");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("1 - Iniciar Sesión");
                Console.WriteLine("2 - Registrarse");              
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
            bool loginSuccessful = false;
            while (!loginSuccessful)
            {
                Console.Clear();
                Console.WriteLine("Ingrese su usuario");
                string user = Console.ReadLine();
                Console.WriteLine("Ingrese su contraseña");
                string password = Console.ReadLine();
                bool wasLoginSuccessful = false;
                if (wasLoginSuccessful)
                {

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El usuario o la contraseña no fue correcto");
                    Console.WriteLine("Presione la tecla \'v\' para volver al menú principal o cualquier otra tecla para volver a intentarlo");
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if(key == ConsoleKey.V)
                    {
                        loginSuccessful = true;
                    }
                }

            }
        }

        private static void register()
        {
            bool registerSuccessful = false;
            while (!registerSuccessful)
            {
                Console.Clear();
                Console.WriteLine("Seleccione el tipo de cliente");
                Console.WriteLine("1 - Cliente común");
                Console.WriteLine("2 - Cliente empresa");
                ConsoleKey key  = Console.ReadKey(true).Key;
                if(key == ConsoleKey.NumPad1)
                {

                }
                else if(key == ConsoleKey.NumPad2)
                {

                }
                else
                {

                }
                Console.WriteLine("Ingrese su contraseña");
                string password = Console.ReadLine();
                bool wasLoginSuccessful = false;
                if (wasLoginSuccessful)
                {

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
