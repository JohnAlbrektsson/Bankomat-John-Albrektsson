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
            bankaccounts[4, 1] = 7604.12m;
            Login(bankaccounts);

        }
        public static void Login(decimal[,] bankaccounts) //Starts the login process 
        {
            int attempts = 0;
            int id;
            string[,] accounts = new string[5, 2]; //2D array with usernames and passwords


            accounts[0, 0] = "JOHN"; accounts[0, 1] = "1475";
            accounts[1, 0] = "HANNA"; accounts[1, 1] = "1999";
            accounts[2, 0] = "SVEN"; accounts[2, 1] = "1341";
            accounts[3, 0] = "ANETTE"; accounts[3, 1] = "8282";
            accounts[4, 0] = "SIMON"; accounts[4, 1] = "7423";

            Console.WriteLine("Välkommen!");

            do
            {
                Console.WriteLine("Skriv in ditt användarnamn:");
                string username = Console.ReadLine();
                Console.WriteLine("Skriv in ditt lösenord:");
                string password = Console.ReadLine();
                if (username.ToUpper() == accounts[0, 0] && password == accounts[0, 1]) //Checks if user 1s username and password match
                {
                    id = 0;
                    Menu(id, accounts, bankaccounts);
                }
                else if (username.ToUpper() == accounts[1, 0] && password == accounts[1, 1]) //Checks if user 2s username and password match
                {
                    id = 1;
                    Menu(id, accounts, bankaccounts);
                }
                else if (username.ToUpper() == accounts[2, 0] && password == accounts[2, 1]) //Checks if user 3s username and password match
                {
                    id = 2;
                    Menu(id, accounts, bankaccounts);
                }
                else if (username.ToUpper() == accounts[3, 0] && password == accounts[3, 1]) //Checks if user 4s username and password match
                {
                    id = 3;
                    Menu(id, accounts, bankaccounts);
                }
                else if (username.ToUpper() == accounts[4, 0] && password == accounts[4, 1]) //Checks if user 5s username and password match
                {
                    id = 4;
                    Menu(id, accounts, bankaccounts);
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen");
                }
            } while (attempts <3);
        }
        public static void Menu(int id, string[,] accounts, decimal[,] bankaccounts) //Opens a menu with different choices for the user
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            bool correctinp = false;
            do // do/while to make sure
            {
                string menuchoice = Console.ReadLine();
                switch (menuchoice) // Switch to check which menu choice the user made
                {
                    case "1":
                        correctinp = true;

                        Showusermoney(id, accounts, bankaccounts);
                        break;

                    case "2":
                        correctinp = true;

                        Transfermoney(id, accounts, bankaccounts);
                        break;
                    case "3":
                        correctinp = true;
                        Withdrawmoney(id, accounts, bankaccounts);
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

        public static void Showusermoney(int id, string[,] accounts, decimal[,]bankaccounts) //Shows the users bankaccounts
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
            Menu(id, accounts, bankaccounts);
        }
        public static void Transfermoney(int id,string [,]accounts, decimal[,]bankaccounts) //Starts method to transfer money from one account to another
        {
            string[] accounttype = new string[4];
            accounttype[0] = "Kort";
            accounttype[1] = "Sparkonto";
            accounttype[2] = "Lönekonto";
            accounttype[3] = "Pensionskonto";
            Console.Clear();

            for (int i = 0; i < bankaccounts.GetLength(0); i++) //Lists the accounts that the user can transfer from and to
            {
                if (bankaccounts[id, i] !=0)
                {
                    Console.WriteLine("{0}: {1} {2} kr",i + 1 ,accounttype[i], bankaccounts[id, i]);
                }
            }
            try
            {
                Console.WriteLine("Vilket konto vill du överföra från?");
                int transferfrom = int.Parse(Console.ReadLine());
                Console.WriteLine("Vilket konto vill du överföra till?");
                int transferto = int.Parse(Console.ReadLine());
                Console.WriteLine("Hur mycket vill du överföra?");
                decimal ammount = decimal.Parse(Console.ReadLine());

                if (ammount > bankaccounts[id, transferfrom -1]) //Checks if the user input is higher than what exists
                {
                    Console.WriteLine("Det finns inte så mycket pengar på ditt {0}, försök igen", accounttype[transferfrom -1]);
                    Transfermoney(id,accounts, bankaccounts);
                    Console.Clear();
                }
                if (transferfrom -1 > 4 || transferto -1 >4) //checks if the bankaccounts exists
                {
                    Console.WriteLine("Detta konto existerar inte, försök igen");
                    Transfermoney(id, accounts, bankaccounts);
                    Console.Clear();
                }
                else
                {
                    bankaccounts[id, transferfrom-1] = bankaccounts[id, transferfrom -1] - ammount; //subtracts the specified ammount 
                    bankaccounts[id, transferto-1] = bankaccounts[id, transferto-1] + ammount; //adds the specified ammount

                    Console.WriteLine("Du har nu {0} kr på ditt {1} och {2} kr på ditt {3}", bankaccounts[id, transferfrom - 1], accounttype[transferfrom -1], bankaccounts[id, transferto-1], accounttype[transferto -1]);
                }
            }
            catch(Exception) 
            {
                Console.WriteLine("Ogiltigt input, klicka enter för att försöka igen");
                Console.ReadKey();
                Transfermoney(id,accounts, bankaccounts);
            }


           
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
            Menu(id, accounts ,bankaccounts);
        }
        public static void Withdrawmoney(int id,string [,]accounts, decimal[,] bankaccounts) //Method for withdrawing money
        {
            string[] accounttype = new string[4];
            accounttype[0] = "Kort";
            accounttype[1] = "Sparkonto";
            accounttype[2] = "Lönekonto";
            accounttype[3] = "Pensionskonto";
            Console.Clear();

            for (int i = 0; i < bankaccounts.GetLength(0); i++) //Lists the accounts that the user can transfer from and to
            {
                if (bankaccounts[id, i] !=0)
                {
                    Console.WriteLine("{0}: {1} {2} kr", i + 1, accounttype[i], bankaccounts[id, i]);
                }
            }
            
            try
            {
                Console.WriteLine("Vilket konto vill du ta ut från?");
                int withdrawfrom = int.Parse(Console.ReadLine());
                Console.WriteLine("Hur mycket vill du ta ut?");
                decimal ammount = decimal.Parse(Console.ReadLine());
                
                if (ammount > bankaccounts[id, withdrawfrom -1]) //Checks if the user input is higher than what exists
                {
                    Console.WriteLine("Det finns inte så mycket pengar att ta ut på ditt {0}, klicka på enter för att försöka igen", accounttype[withdrawfrom -1]);
                    Console.ReadKey();
                    Transfermoney(id, accounts, bankaccounts);
                    
                }
                if(withdrawfrom -1 >4) //Checks if the bankaccount the user input exists
                {
                    Console.WriteLine("Det angivna kontot existerar inte, klicka på enter för att försöka igen");
                    Console.ReadKey();
                    Transfermoney(id, accounts, bankaccounts);
                    
                }
                else
                {
                    Console.WriteLine("Skriv in din pinkod för att genomföra ditt uttag");
                    for (int i = 2; i>=0; i--) //For loop to give the user 3 attemps to write the correct pin
                    {
                        string pass = Console.ReadLine();
                        if (pass == accounts[id, 1]) //Checks if the pin is correct
                        {
                            bankaccounts[id, withdrawfrom -1] = bankaccounts[id, withdrawfrom -1] - ammount; //withdraws the specified ammount
                            Console.WriteLine("{0} kr har tagits ut från {1}", ammount, accounttype[withdrawfrom -1]);
                            Console.WriteLine("Du har nu {0} kr kvar på ditt {1}", bankaccounts[id,withdrawfrom -1], accounttype[withdrawfrom-1]);
                            Console.WriteLine("Klicka enter för att komma tillbaka till menyn");
                            Console.ReadKey();
                            Menu(id, accounts, bankaccounts);
                        }
                        else
                        {
                            Console.WriteLine("Fel pinkod, du har {0} försök kvar",i);
                        }
                        if(i == 0) //if all the attempts to write pin is used, the user is sent to the menu
                        {
                            Console.Clear();
                            Console.WriteLine("Du har angivit fel pinkod för många gånger, klicka enter för att gå tillbaka till menyn");
                            Console.ReadKey();
                            Menu(id, accounts, bankaccounts);
                        }
                    }
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltigt input, klicka enter för att försöka igen");
                Console.ReadKey();
                Withdrawmoney(id, accounts ,bankaccounts);
            }
            Console.WriteLine("Klicka enter för att komma till huvudmenyn");
            Console.ReadKey();
            Menu(id, accounts, bankaccounts);
        }
    }
}
