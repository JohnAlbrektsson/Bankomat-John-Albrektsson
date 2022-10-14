using System;
using System.ComponentModel;

namespace Bankomat_John_Albrektsson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            decimal[,] bankaccounts = new decimal[5, 5];
            bankaccounts[0, 0] = 200m;
            bankaccounts[0, 1] = 230.35m;
            bankaccounts[0, 2] = 330.70m;

            bankaccounts[1, 0] = 700;
            bankaccounts[1, 1] = 300.57m;

            bankaccounts[2, 0] = 236m;
            bankaccounts[2, 1] = 2360m;
            bankaccounts[2, 2] = 2570.13m;
            bankaccounts[2, 3] = 1230.50m;

            bankaccounts[3, 0] = 750.34m;
            bankaccounts[3, 1] = 7800.4m;
            bankaccounts[3, 2] = 1230m;

            bankaccounts[4, 0] = 1230m;
            bankaccounts[4, 1] = 1230m;
            Login(bankaccounts);
            
        }
        public static void Login(decimal [,]bankaccounts) //Starts the login process 
        {
            int attempts = 0;
            int id;
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
                    id = 0;
                    Menu(id, bankaccounts);
                }
                else if (username == accounts[1, 0] && password == accounts[1, 1]) //Checks if user 2s username and password match
                {
                    id = 1;
                    Menu(id, bankaccounts);
                }
                else if (username == accounts[2, 0] && password == accounts[2, 1]) //Checks if user 3s username and password match
                {
                    id = 2;
                    Menu(id, bankaccounts);
                }
                else if (username == accounts[3, 0] && password == accounts[3, 1]) //Checks if user 4s username and password match
                {
                    id = 3;
                    Menu(id, bankaccounts);
                }
                else if (username == accounts[4, 0] && password == accounts[4, 1]) //Checks if user 5s username and password match
                {
                    id = 4;
                    Menu(id, bankaccounts);
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen");
                }
            } while (attempts <3);
        }
        public static void Menu(int id, decimal [,]bankaccounts) //Opens a menu with different choices for the user
        {
            Console.Clear();
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
                        
                        Showusermoney(id, bankaccounts);
                        break;

                    case "2":
                        correctinp = true;
                        
                        Transfermoney(id, bankaccounts);
                        break;
                    case "3":
                        correctinp = true;
                        break;
                    case "4":
                        correctinp = true;
                        Login(bankaccounts);

                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;

                }
            } while (correctinp == false);
        }

        public static void Showusermoney(int id, decimal[,]bankaccounts) //Shows the users bankaccounts
        {
            string[] accounttype = new string[4];
            accounttype[0] = "Kort";
            accounttype[1] = "Sparkonto";
            accounttype[2] = "Lönekonto";
            accounttype[3] = "Pensionskonto";
            Console.Clear();
            for (int i = 0; i < bankaccounts.GetLength(0); i++) // Writes out all accounts the user has
            {
                if (bankaccounts[id, i] !=0)
                {
                    Console.WriteLine("Du har {0} kr på ditt {1}",bankaccounts[id, i], accounttype[i]);
                }
            }

            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
            Menu(id, bankaccounts);
        }
        public static void Transfermoney(int id, decimal[,]bankaccounts) //Starts method to transfer money from one account to another
        {
            string[] accounttype = new string[4];
            accounttype[0] = "Kort";
            accounttype[1] = "Sparkonto";
            accounttype[2] = "Lönekonto";
            accounttype[3] = "Pensionskonto";

            for (int i = 0; i < bankaccounts.GetLength(0); i++) //Lists the accounts that the user can transfer from and to
            {
                if (bankaccounts[id, i] !=0)
                {
                    Console.WriteLine("{0}: {1} {2} kr",i, accounttype[i], bankaccounts[id, i]);
                }
            }

            Console.WriteLine("Vilket konto vill du överföra från?");
            int transferfrom = int.Parse(Console.ReadLine());
            Console.WriteLine("Vilket konto vill du överföra till?");
            int transferto = int.Parse(Console.ReadLine());
            Console.WriteLine("Hur mycket vill du överföra?");
            decimal ammount = decimal.Parse(Console.ReadLine());

         

            bankaccounts[id, transferfrom] = bankaccounts[id, transferfrom] - ammount; //subtracts the specified ammount 
            bankaccounts[id, transferto] = bankaccounts[id, transferto] + ammount; //adds the specified ammount

           
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
            Menu(id, bankaccounts);
        }
    }
}
