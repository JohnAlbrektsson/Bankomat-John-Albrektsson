using System;

namespace Bankomat_John_Albrektsson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login();
        }
        public static void Login()
        {
            int attempts = 0;
            string[,] accounts = new string[5, 2];
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
                if (username == accounts[0, 0] && password == accounts[0, 1])
                {
                    
                    
                }
                else if (username == accounts[1, 0] && password == accounts[1, 1])
                {
                    
                }
                else if (username == accounts[2, 0] && password == accounts[2, 1])
                {
                    
                }
                else if (username == accounts[3, 0] && password == accounts[3, 1])
                {
                    
                }
                else if (username == accounts[4, 0] && password == accounts[4, 1])
                {
                    
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen");
                }
            } while (attempts <3);
        }
    }
}
