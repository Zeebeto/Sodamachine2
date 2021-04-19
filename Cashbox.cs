using System;

namespace Sodamachine2
{
    public class Cashbox
    {
        private int _credit;

        public Cashbox(int credit)
        {
            _credit = credit;
        }

        public int getCred()
        {
            return _credit;
        }
        public void addCredit(Sodamachine sm)
        {
            Console.WriteLine("amount:");
            string input = Console.ReadLine();
            int amount;
            if (int.TryParse(input,out amount))
            {
                _credit += amount;
                Console.WriteLine($"you have {_credit} credit.\n");
            }
            else Console.WriteLine("invalid input\n");
            sm.AddCredit = false;
        }

        public void returnCred()
        {
            Console.WriteLine("do you want to return your credit?\n" +
                              $"current credit = {_credit}\n" +
                              $"Y/N\n");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                int precred = _credit;
                Console.WriteLine($"returning {precred} credits.");
                _credit = _credit - precred;
            }
            Console.WriteLine($"you have {_credit} credit\n");
        }

        public void purchase(int price, string item)
        {
            Console.WriteLine($"you purchased {item} for {price} credits");
            _credit = _credit - price;
            Console.WriteLine($"your credit is: {_credit}");
        }
    }
}