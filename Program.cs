using System;
using System.Collections.Generic;
using System.Linq;

namespace Atm
{
    class Program
    {
        static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ would you like to deposit? ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit);
                Console.WriteLine("Thank you for your $$. Your new balance is:" + currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ would you like to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());
                //Check if the user has not enough money
                if (currentUser.getBalance() > withdrawal)
                {
                    Console.WriteLine("Insufficient balance: :( ");
                }
                else 
                {
                   currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("You are good to go! Thank you :) ");
                };

            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4532777586896804630", 1234, "John", "Griffin", 150.31));
            cardHolders.Add(new cardHolder("4532777586896804612", 4321, "Ashley", "Jones", 321.13));
            cardHolders.Add(new cardHolder("4532777586896804644", 9999, "Frida", "Dickerson", 105.59));
            cardHolders.Add(new cardHolder("4532777586896804650", 2468, "Muneeb", "Harding", 851.84));
            cardHolders.Add(new cardHolder("4532777586896804655", 4826, "Dawn", "Smith", 54.27));

            //Prompt
            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // check against our db
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else {
                        Console.WriteLine("Card not recognized. Please try again");

                    }
                }
                catch {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else
                    {
                        Console.WriteLine("Incorrect pin. Please try again. ");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());

                }
                catch { }
                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2)
                {
                    withdraw(currentUser);
                }
                else if (option == 3)
                {
                    balance(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else {
                    option = 0;
                }

            }
            while (option != 4);
            Console.WriteLine("Thank you! Have a nice day :)");
        }
        public class cardHolder 
        {
            string cardNum;
            int pin;
            string firstName;
            string lastName;
            double balance;

            public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
            {
                this.cardNum = cardNum;
                this.pin = pin;
                this.firstName = firstName;
                this.lastName = lastName;
                this.balance = balance;

            }

            public string getNum()
            {
                return cardNum;
            }

            public int getPin()
            {
                return pin;
            
            }

            public string getFirstName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public double getBalance()
            {
                return balance;
            }

            public void setNum(string newCardNum)
            {
                cardNum = newCardNum;
            }

            public void setPin(int newPin)
            {
                pin = newPin;
            }

            public void setFirstName(string newFirstName)
            {
                firstName = newFirstName;
            }

            public void setLastName(string newLastName)
            {
                lastName = newLastName;  
            }

            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }
        }
    }
}
