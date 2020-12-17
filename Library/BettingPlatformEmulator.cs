using System;
using System.Collections.Generic;
using System.Text;
using Library.Exceptions; 

namespace Library
{
    public class BettingPlatformEmulator
    {
        List<Player> Players;
        Player ActivePlayer;
        Account Account;
        BetService betService;
        PaymentService paymentService;
        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
            Players = new List<Player>();
            betService = new BetService();
            paymentService = new PaymentService();
        }
        public void Start ()
        {
            while (true)
            {
                string command;
                if (ActivePlayer == null)
                {
                    Console.WriteLine("1.Register");
                    Console.WriteLine("2.Login");
                    Console.WriteLine("3.Stop");
                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "Register":
                            Register();
                            break;
                        case "Login":
                            Login();
                            break;
                        case "Stop":
                            Exit();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("1.Deposit");
                    Console.WriteLine("2.Withdraw");
                    Console.WriteLine("3.GetOdds");
                    Console.WriteLine("4.Bet");
                    Console.WriteLine("5.Logout");
                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "GetOdds":
                            GetOdd();
                            break;
                        case "Bet":
                            Bet();
                            break;
                        case "Deposit":
                            Deposit();
                            break;
                        case "Withdraw":
                            Withdraw();
                            break;
                        case "Logout":
                            Logout();
                            break;
                    }
                }
            }
        }

        private void Bet()
        {
            try
            {
                decimal amount = EnterConsoleValue.GetDecimal("Enter your Amount, please");
                Console.WriteLine("Enter your Currency, please");
                string currency = Console.ReadLine();
                if (currency == "Stop")
                    throw new StopException();
                ActivePlayer.Withdraw(amount, currency);
                decimal result = betService.Bet(amount);
                if (result != 0)
                {
                    ActivePlayer.Deposit(result, currency);
                    Console.WriteLine("You win: {0} {1}", result, currency);
                }
                else
                {
                    Console.WriteLine("You lose");
                }
            }
            catch (StopException)
            {

            }
        }

        void Exit()
        {
            Environment.Exit(0);
        }
        void Register()
        {
            try
            {
                string firstname = EnterConsoleValue.GetName("Enter your name, please");
                string lastname = EnterConsoleValue.GetName("Enter your Last name, please");
                string login = EnterConsoleValue.GetEmail("Enter your login, please");
                string password = EnterConsoleValue.GetPassword("Enter your password, please");
                while (true)
                {
                    Console.WriteLine("Enter your Currency, please");
                    string currency = Console.ReadLine();
                    if (currency == "Stop")
                        throw new StopException();
                    try
                    {
                        Players.Add(new Player(firstname, lastname, login, password, currency));
                        break;
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Enter your Currency again, please");
                    }
                }
            }
            catch (StopException)
            {

            }

        }
        void Login()
        {
            try
            {
                string login = EnterConsoleValue.GetEmail("Enter your login, please");
                string password = EnterConsoleValue.GetPassword("Enter your password, please");
                foreach (Player player in Players)
                {
                    if (player.Email == login && player.IsPasswordValid(password))
                    {
                        ActivePlayer = player;
                        break;
                    }
                }
            }
            catch (StopException)
            {

            }
        }
        void Logout()
        {
            ActivePlayer = null;
        }
        void Deposit()
        {
            try {
                decimal amount = EnterConsoleValue.GetDecimal("Enter your Amount, please");
                Console.WriteLine("Enter your Currency, please");
                string currency = Console.ReadLine();
                if (currency == "Stop")
                    throw new StopException();
                paymentService.StartDeposit(amount, currency);
                ActivePlayer.Deposit(amount, currency);
                Account.Deposit(amount, currency); }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("Insufficient Funds");
                Console.WriteLine("Please, try to make a transaction with lower amount or change the payment method");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Exceeding the transaction limit");
                Console.WriteLine("Please, try to make a transaction with lower amount");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Something went wrong.Try again later...");
            }
            catch (StopException)
            {

            }

        }
        void Withdraw()
        {
            try
            {
                decimal amount = EnterConsoleValue.GetDecimal("Enter your Amount, please");
                Console.WriteLine("Enter your Currency, please");
                string currency = Console.ReadLine();
                if (currency == "Stop")
                    throw new StopException();
                paymentService.StartWithdrawal(amount, currency);
                try
                {
                    ActivePlayer.Withdraw(amount, currency);
                    try
                    {
                        Account.Withdraw(amount, currency);
                    }
                    catch (InvalidOperationException)
                    {
                        ActivePlayer.Deposit(amount, currency);
                        Console.WriteLine("There is some problem on the platform side. Please try it later");
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("There is insufficient funds on your account");
                }
            }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("Insufficient Funds");
                Console.WriteLine("Please, try to make a transaction with lower amount or change the payment method");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Exceeding the transaction limit");
                Console.WriteLine("Please, try to make a transaction with lower amount");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Something went wrong.Try again later...");
            }
            catch (StopException)
            {

            }

        }
        void GetOdd()
        {
            Console.WriteLine("Actual ratio : {0}",betService.GetOdds());
        }


    }
}
