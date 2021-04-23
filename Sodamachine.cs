using System;
using System.Collections.Generic;

namespace Sodamachine2
{
    public class Sodamachine
    {
        public List<Soda> Stock = new List<Soda>();
        public bool _machineOn;
        public bool AddCredit;
        public bool BuySoda;

        public Sodamachine()
        {
            
        }
        public void Setup()
        {
            Stock.Add(new Soda("cola",19,50));
            Stock.Add(new Soda("pepsi",14,50));
            Stock.Add(new Soda("urge",21,50));
            Stock.Add(new Soda("monster",31,1));
            Stock.Add(new Soda("singo",9,50));
            Console.WriteLine("For a list of commands, please enter <H> \nPlease enter a command:");
        }

        public void StartMachine()
        {
            _machineOn = true;
            Console.WriteLine("Sodamachine v2.0.0.1a\n");
        }

        // public bool GetStatus()
        // {
        //     return _machineOn;
        // }
        public void HandleCmd(string input, Sodamachine sm, Cashbox cash)
        {
            switch (input)
            {
                case "h":
                    GetHelp();
                    break;
                case "i":
                    AddCredit = true;
                    break;
                case "q":
                    _machineOn = false;
                    Console.WriteLine("shutting down....");
                    break;
                case "b":
                    BuySoda = true;
                    break;
                case "r":
                    cash.returnCred();
                    break;
                case "s":
                    showStock(Stock);
                    break;
                case "c":
                    Console.WriteLine($"you have {cash.getCred()} credit");
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        private void showStock(List<Soda> stock)
        {
            foreach (var drink in stock)
            {
                Console.WriteLine($"{drink._name}: stock: {drink._storage}");
            }
        }

        private void GetHelp()
        {
            Console.WriteLine("Valid commands:");
            Console.WriteLine("H - help");
            Console.WriteLine("I - insert credit");
            Console.WriteLine("B - buy\n" +
                              "     a number 1 - 5 depending on what soda you would like");
            Console.WriteLine("R - return credit");
            Console.WriteLine("S - show current stock");
            Console.WriteLine("C - shows you tour credit");
            Console.WriteLine("Q - quit");
        }

        public void HandleSoda(Sodamachine sm, Cashbox cash)
        {
            Soda.buySoda(Stock, sm, cash);
        }
    }
}