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
            listSoda(stock);
            Console.WriteLine("bulk: type <bulk> top buy several sodas");
            string input = Console.ReadLine();
            if (int.TryParse(input,out var index))
            {
                if (index >= stock.Count +1)
                {
                    Console.WriteLine("invalid input\n");
                    return;
                }
                int i = index - 1;
                Console.WriteLine($"you have chosen: {stock[i]._name}");
                if (stock[i]._price > cash.getCred())
                {
                    Console.WriteLine("you dont have enough credit.\n" +
                                      " please add some by using command <i> followed by desired amount.");
                }
                if (stock[i]._storage == 0)
                {
                    Console.WriteLine($"{stock[i]._name} is out of stock.");
                }
                if (cash.getCred()>= stock[i]._price && stock[i]._storage != 0)
                {
                    cash.purchase(stock[i]._price, stock[i]._name, 1);
                    stock[i]._storage--;
                }
                else Console.WriteLine("invalid input\n");
            }
            if (input.ToLower() == "bulk") bulkBuy(stock, cash);
            

            sm.BuySoda = false;
        }

        private static void listSoda(List<Soda> stock)
        {
            Console.WriteLine("what soda would you like?");
            int num = 1;
            foreach (var drink in stock)
            {
                Console.WriteLine($"{num}: {drink._name} Price: {drink._price}.- {getStock(drink)}");
                num++;
            }
        }

        private static void bulkBuy(List<Soda> stock, Cashbox cash)
        {
            listSoda(stock);
            string input = Console.ReadLine();
            if (int.TryParse(input, out var index))
            {
                if (index >= stock.Count +1)
                {
                    Console.WriteLine("invalid input\n");
                    return;
                }
                int i = index - 1;
                Console.WriteLine($"how many {stock[i]._name} would you like?");
                string input2 = Console.ReadLine();
                if (int.TryParse(input2, out var amount))
                {
                    if (stock[i]._storage < amount)
                    {
                        Console.WriteLine($"{stock[i]._name} does not have enough in stock");
                        return;
                    }
                    if (stock[i]._price*amount > cash.getCred())
                    {
                        Console.WriteLine("you dont have enough credit.\n" +
                                          " please add some by using command <i> followed by desired amount.");
                    }
                    if (stock[i]._storage == 0)
                    {
                        Console.WriteLine($"{stock[i]._name} is out of stock.");
                    }
                    if (cash.getCred()>= stock[i]._price*amount && stock[i]._storage != 0)
                    {
                        cash.purchase(stock[i]._price*amount, stock[i]._name, amount);
                        stock[i]._storage -= amount;
                    }
                }
            }
            else Console.WriteLine("invalid input\n");
        }

        private static string getStock(Soda drink)
        {
            return drink._storage != 0 ? "" : "|-- OUT OF STOCK";
        }
    }
}