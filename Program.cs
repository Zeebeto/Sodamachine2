using System;

namespace Sodamachine2
{
    class Program
    {
        static void Main()
        {
            var sm = new Sodamachine();
            var cash = new Cashbox(0);
            sm.StartMachine();
            sm.Setup();
            while (sm._machineOn)
            {
                var input = Console.ReadLine();
                if (input != null) sm.HandleCmd(input.ToLower(), sm, cash);
                if (sm.AddCredit) cash.addCredit(sm);
                if (sm.BuySoda) sm.HandleSoda(sm, cash);
            }
            
        }
    }
}
/* fix negative credit bug - fixed
 * add functionalty to buy several sodas at once
 * bulk discount?
 * admin access to restock
 */