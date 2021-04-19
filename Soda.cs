using System;
using System.Collections.Generic;

namespace Sodamachine2
{
    public class Soda
    {
        public string _name { get; private set; }
        public int _price{ get; private set; }
        public int _storage{ get; private set; }

        public Soda(string name, int price, int storage)
        {
            _name = name;
            _price = price;
            _storage = storage;
        }
        
        public static void buySoda(List<Soda> stock, Sodamachine sm, Cashbox cash)
        {
            Console.WriteLine("what soda would you like?");
            int num = 1;
            foreach (var drink in stock)
            {
                Console.WriteLine($"{num}: {drink._name} Price: {drink._price}.- {getStock(drink)}");
                num++;
            }
            string input = Console.ReadLine();
            if (int.TryParse(input,out var index))
            {
                int i = index - 1;
                Console.WriteLine($"you have chosen: {stock[i]._name}");
                if (stock[i]._price > cash.getCred())
                {
                    Console.WriteLine("you dont have enough credit.\n" +
                                      " please add some by using command <i> followed by desired amount.");
                }
                if (stock[i]._storage != 0)
                {
                    cash.purchase(stock[i]._price, stock[i]._name);
                    stock[i]._storage--;
                }
                else Console.WriteLine($"{stock[i]._name} is out of stock.");
                
            }
            else Console.WriteLine("invalid input\n");

            sm.BuySoda = false;
        }

        private static string getStock(Soda drink)
        {
            return drink._storage != 0 ? "" : "|-- OUT OF STOCK";
        }
    }
}