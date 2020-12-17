using System;
using Library;
namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BetService betService = new BetService();

            for (int i = 0; i < 100; i++) {
                Console.WriteLine("I’ve bet 100 USD with the odd {0} and I’ve earned {1}", betService.GetOdds(), betService.Bet(100));
            }
            Console.WriteLine();

            int j = 0;
            while (j != 3)
            {
                float odd = betService.GetOdds();
                if (odd > 12)
                {
                    Console.WriteLine("I’ve bet 100 USD with the odd {0} and I’ve earned {1}",odd,betService.Bet(100));
                    j++;
                }
            }
            Console.WriteLine();

            decimal amount = 10_000;
            while (true)
            {
                if ((amount <= 0) || (amount >= 15_000))
                {
                    Console.WriteLine("Game over. My balance is {0}", amount);
                    break;
                }
                if(betService.GetOdds() <= 1.09)
                {
                    if(amount < 1000)
                    {
                        decimal bet = amount;
                        amount = 0;
                        amount += (decimal) betService.Bet(bet);
                    }
                    else
                    {
                        decimal bet = amount / 10;
                        amount -= bet;
                        amount += (decimal)betService.Bet(bet);
                    }
                    Console.WriteLine(amount);
                }

            }
        }
    }
}
