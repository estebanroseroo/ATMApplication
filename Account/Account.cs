using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Account
{
    public class Account
    {
        private List<string> transactions = new List<string>();
        private int accountNumber;
        private float balance;
        private float interestRate = 3.0f;
        private string accountHolderName;
        private string password;

        public Account(int accountNumber, float balance, string accountHolderName, string password)
        {   
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountHolderName = accountHolderName;
            this.password = password;
        }

        public int AccountNumber => accountNumber;
        public float Balance => balance;
        public float InterestRate => interestRate;
        public string AccountHolderName => accountHolderName;

        public List<string> GetTransactions() => transactions;

        public void Deposit(float amount)
        {
            if (amount > 0)
            {
                balance += amount;
                transactions.Add($"Deposit: {amount:C}");
            }
        }

        public bool Withdraw(float amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                transactions.Add($"Withdrawal: {amount:C}");
                return true;
            }
            return false;
        }

        public bool VerifyPassword(string userPassword)
        {
            return password == userPassword;
        }
    }
}
