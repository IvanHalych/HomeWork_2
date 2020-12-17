using System;
using Library;
namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Player player = new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "USD");
            //2
            Console.WriteLine("Login with login {0} and password {1} is {2}", 
                player.Email, 
                "TheP@$$w0rd",
                player.IsPasswordValid("TheP@$$w0rd"));
            //3
            Console.WriteLine("Login with login {0} and password {1} is {2}",
                player.Email,
                "TheP@$$w0r",
                player.IsPasswordValid("TheP@$$w0r"));
            //4
            player.Deposit(100, "USD");
            //5
            player.Withdraw(50, "USD");
            //6
            try
            {
                player.Withdraw(1000, "USD");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //7
            try
            {
                new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "PLN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
