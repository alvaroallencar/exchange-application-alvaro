using System;

namespace Exchange2
{
    class Program
    {
        static void Main()
        {
            Dollar dollar = new Dollar { Name = "USD", ExchangeRate = 1.08m };
            Euro euro = new Euro { Name = "EUR", ExchangeRate = 0.92m };

            var dollarWallet = new Wallet<Dollar>();
            dollarWallet.AddFunds(500);
            dollarWallet.AddFunds(200);
            Console.WriteLine($"Balance in USD: {dollarWallet.GetBalance()}");

            var euroWallet = new Wallet<Euro>();
            euroWallet.AddFunds(300);
            euroWallet.AddFunds(100);
            Console.WriteLine($"Balance in EUR: {euroWallet.GetBalance()}");

            dollarWallet.ExchangeFunds(50, euro, euroWallet);
            Console.WriteLine($"Updated balance in USD: {dollarWallet.GetBalance()}");
            Console.WriteLine($"Updated balance in EUR: {euroWallet.GetBalance()}");
            
            euroWallet.ExchangeFunds(100, dollar, dollarWallet);
            Console.WriteLine($"Updated balance in EUR: {euroWallet.GetBalance()}");
            Console.WriteLine($"Updated balance in USD: {dollarWallet.GetBalance()}");
        }
    }
}