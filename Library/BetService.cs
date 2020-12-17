using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BetService
    {
        decimal Odd;
        public BetService()
        {
            decimal newOdd = new Random().Next(101, 2501);
            Odd = newOdd / 100m;
        }
        public float GetOdds()
        {
            decimal newOdd = new Random().Next(101, 2501);
            Odd = newOdd / 100m;
            return (float)Odd;
        }
        bool IsWon()
        {
            decimal chance = 100m / Odd;
            int x = new Random().Next(1, 101);
            if (x <= chance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal Bet(decimal amount)
        {
            if (IsWon())
            {
                return Odd * amount;
            }
            else
            {
                return 0;
            }
        }
    }
}
