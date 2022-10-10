using System;

namespace Bankomat_John_Albrektsson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login();
        }
        public static void Login() //Starts the login process 
        {
            int attempts = 0;
            string[,] accounts = new string[5, 2]; //2D array with usernames and passwords


            accounts[0, 0] = "00"; accounts[0, 1] = "01";
            accounts[1, 0] = "10"; accounts[1, 1] = "11";
            accounts[2, 0] = "20"; accounts[2, 1] = "21";
            accounts[3, 0] = "30"; accounts[3, 1] = "31";
            accounts[4, 0] = "40"; accounts[4, 1] = "41";

            Console.WriteLine("Välkommen!");

            do
            {
                Console.WriteLine("Skriv in ditt användarnamn:");
                string username = Console.ReadLine();
                Console.WriteLine("Skriv in ditt lösenord:");
                string password = Console.ReadLine();
                if (username == accounts[0, 0] && password == accounts[0, 1]) //Checks if user 1s username and password match
                {
                    Menu();
                    
                }
                else if (username == accounts[1, 0] && password == accounts[1, 1]) //Checks if user 2s username and password match
                {
                    Menu();
                }
                else if (username == accounts[2, 0] && password == accounts[2, 1]) //Checks if user 3s username and password match
                {
                    Menu();
                }
                else if (username == accounts[3, 0] && password == accounts[3, 1]) //Checks if user 4s username and password match
                {
                    Menu();
                }
                else if (username == accounts[4, 0] && password == accounts[4, 1]) //Checks if user 5s username and password match
                {
                    Menu();
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen");
                }
            } while (attempts <3);
        }
        public static void Menu() //Opens a menu with different choices for the user
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");
            bool correctinp = false;
            do
            {
                string menuchoice = Console.ReadLine();
                switch (menuchoice)
                {
                    case "1":
                        correctinp = true;
                        break;

                    case "2":
                        correctinp = true;
                        break;
                    case "3":
                        correctinp = true;
                        break;
                    case "4":
                        correctinp = true;
                        Login();

                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;

                }
            } while (correctinp == false);
        }
    }
}
