using System;
using System.Collections.Generic;

namespace Exchange2
{
    public class Wallet<T> where T : Currency
    {
        private readonly Dictionary<Type, decimal> _funds = new Dictionary<Type, decimal>();

        public void AddFunds(decimal amount)
        {
            var currencyType = typeof(T);
            if (!_funds.ContainsKey(currencyType))
            {
                _funds[currencyType] = 0;
            }

            _funds[currencyType] += amount;
        }

        public decimal GetBalance()
        {
            return !_funds.ContainsKey(typeof(T)) ? 0 : _funds[typeof(T)];
        }

        public void ExchangeFunds<U>(decimal amount, U targetCurrency, Wallet<U> targetWallet)
            where U : Currency
        {
            var balanceInTargetCurrency = GetBalance();

            if (balanceInTargetCurrency < amount)
            {
                Console.WriteLine("Insufficient funds for exchange.");
                return;
            }

            _funds[typeof(T)] -= amount;
            targetWallet.AddFunds(amount * targetCurrency.ExchangeRate);
            Console.WriteLine($"{amount} exchanged to {targetCurrency.Name}.");
        }
    }
}