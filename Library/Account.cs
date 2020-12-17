using System;
using System.Collections.Generic;
using Library.Exceptions;
namespace Library
{
    public class Account
    {
        static List<int> listUsedId;
        const decimal USDtoUAH = 28.36m;
        const decimal EURtoUAH = 33.63m;
        const decimal EURtoUSD = 1.19m;
        readonly static string[] supportedСurrency = { "EUR", "USD", "UAH" };
        public int Id { get; }
        decimal Amount;
        public string Currency { get; }
        public Account(string Currency)
        {
            if (listUsedId == null)
                listUsedId = new List<int>();
            while (true)
            {
                int id = new Random().Next(100_000, 1_000_000_000);
                foreach(int someId in listUsedId)
                {
                    if (someId == id)
                        continue;
                }
                listUsedId.Add(id);
                Id = id;          
                break;
            }
            Amount = 0;

            if (IsCurrencySupported(Currency))
            {
                this.Currency = Currency;
            }
            else
            {                
                throw new NotSupportedException($"{Currency} is not supported");
            }
        }
        public void Deposit(decimal amount, string Currency)
        {
            switch (this.Currency)
            {
                case "EUR":
                    Amount += ConvertToEUR(amount, Currency);
                    break;
                case "USD":
                    Amount += ConvertToUSD(amount, Currency);
                    break;
                case "UAH":
                    Amount += ConvertToUAH(amount, Currency);
                    break;
            }
        }
        public void Withdraw(decimal amount, string Currency)
        {
            decimal value;
            switch (this.Currency)
            {   
                case "EUR":
                    value = ConvertToEUR(amount, Currency);
                    if (Amount >= value)
                        Amount -= value;
                    else
                        throw new InsufficientFundsException();
                    break;
                case "USD":
                    value = ConvertToUSD(amount, Currency);
                    if (Amount >= value)
                        Amount -= value;
                    else
                        throw new InsufficientFundsException();
                    break;
                case "UAH":
                    value = ConvertToUAH(amount, Currency);
                    if (Amount >= value)
                        Amount -= value;
                    else
                        throw new InsufficientFundsException();
                    break;       
            }
        }
        public decimal GetBalance(string currency)
        {
            switch (currency)
            {
                case "EUR":
                    return ConvertToEUR(Amount,Currency);
                case "USD":
                    return ConvertToUSD(Amount, Currency);
                case "UAH":
                    return ConvertToUAH(Amount, Currency);
                default:
                    throw new NotSupportedException($"{Currency} is not supported");
            }
        }
        static decimal ConvertToEUR(decimal amount, string Currency)
        {
            switch (Currency)
            {
                case "EUR":
                    return amount;
                case "USD":
                    return amount /EURtoUSD ;
                case "UAH":
                    return amount / EURtoUAH;
                default:
                    throw new NotSupportedException($"{Currency} is not supported");
            }
        }
        static decimal ConvertToUSD(decimal amount, string Currency)
        {
            switch (Currency)
            {
                case "EUR":
                    return amount * EURtoUSD;
                case "USD":
                    return amount;
                case "UAH":
                    return amount /EURtoUAH;
                default:
                    throw new NotSupportedException($"{Currency} is not supported");
            }
        }
        public static decimal ConvertToUAH(decimal amount, string Currency)
        {
            switch (Currency)
            {
                case "EUR":
                    return amount * EURtoUAH;
                case "USD":
                    return amount * USDtoUAH;
                case "UAH":
                    return amount;
                default:
                    throw new NotSupportedException($"{Currency} is not supported");
            }
        }

        public static Account[] GetSortedAccounts( Account[] accounts)
        {
            Account[] sortAccounts = (Account[])accounts.Clone();
            for(int i=sortAccounts.Length-1; i >0; i--)
            {
                for(int j=0; j < i; j++)
                {
                    if (sortAccounts[j].Id > sortAccounts[j + 1].Id)
                    {
                        Account account = sortAccounts[j];
                        sortAccounts[j] = sortAccounts[j + 1];
                        sortAccounts[j + 1] = account;
                    }
                }
            }
            return sortAccounts;
        }
        public static void GetAccount(int Id, Account[] accounts)
        {
            int tries = 0;
            int index = BinarySearch(accounts, Id, 0, accounts.Length - 1, ref tries);
            if (index == -1)
            {
                Console.WriteLine("There is no account {0} in the list", Id);
            }
            else
            {
                Console.WriteLine("{0} was found at index {1} by {2} tries",Id,index,tries);
            }
        }
        static int BinarySearch(Account[] array, int searchedValue, int first, int last, ref int tries)
        {
            tries++;
            if (first > last)
            {
                return -1;
            }
            var middle = (first + last) / 2;
            var middleValue = array[middle];
            if (middleValue.Id == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue.Id > searchedValue)
                {
                    return BinarySearch(array, searchedValue, first, middle - 1, ref tries);
                }
                else
                {
                    return BinarySearch(array, searchedValue, middle + 1, last, ref tries);
                }
            }
        }
        static void Swap(ref Account x, ref Account y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(Account[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].Id < array[maxIndex].Id)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static Account[] QuickSort(Account[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static Account[] GetSortedAccountsByQuickSor(Account[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        static bool IsCurrencySupported(string Currency)
        {
            foreach (string currency in supportedСurrency)
            {
                if (currency == Currency)
                    return true;
            }
            return false;
        }
    }
}
