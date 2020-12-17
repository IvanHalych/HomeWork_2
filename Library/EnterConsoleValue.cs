using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Library.Exceptions;

namespace Library
{
    public static class EnterConsoleValue
    {
        public static decimal GetDecimal(string description)
        {
            while (true)
            {
                Console.WriteLine(description);
                decimal result;
                string strResult = Console.ReadLine();
                if (strResult == "Stop")
                    throw new StopException();
                if (decimal.TryParse(strResult, out result))
                {
                    if(result >=0)
                    return result;
                } 
                Console.WriteLine("Invalid format input");
            }
           
        }
        public static string GetNumberCard(string description)
        {
            Regex regex = new Regex(@"(^[4-5][0-9]{3} [0-9]{4} [0-9]{4} [0-9]{4}$)|(^[4-5][0-9]{3}[0-9]{4}[0-9]{4}[0-9]{4}$)");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    result = result.Replace(" ","");
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetName(string description)
        {
            Regex regex = new Regex(@"^[A-Z][A-Za-z]*$");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetPassword(string description)
        {
            Regex regex = new Regex(@"^.*(?=.{6,})(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*? ]).*$");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetEmail(string description)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetExpiryDate(string description)
        {
            Regex regex = new Regex(@"^(0[1-9])|(1[0-2])/\d{2}$");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetCVV(string description)
        {
            Regex regex = new Regex(@"^\d{3}$");
            while (true)
            {
                Console.WriteLine(description);
                string result = Console.ReadLine();
                if (result == "Stop")
                    throw new StopException();
                if (regex.IsMatch(result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format input");
            }
        }
        public static string GetCreditCardInBank(string description, string[] Cards)
        {
            while (true)
            {
                Console.WriteLine(description);
                string input = Console.ReadLine();
                if (input == "Stop")
                    throw new StopException();
                foreach (string card in Cards)
                {
                    if(card == input)
                    {
                        return input;
                    }

                }
                Console.WriteLine("This card is unavailable.");
            }
        }
        public static string GetGiftCardNumber()
        {
            while (true)
            {
                Console.WriteLine("Enter 10 digit gift card number");
                Regex regex = new Regex(@"^\d{10}$");
                string input = Console.ReadLine();
                if (input == "Stop")
                    throw new StopException();
                if (regex.IsMatch(input))
                    return input;
                Console.WriteLine("Invalid format input");
            }
        }
    }
}
