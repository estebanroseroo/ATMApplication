using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Bank
{
    class Bank
    {
        private List<Account.Account> accounts = new List<Account.Account>();

        public Bank()
        {
            CreateDefaultAccounts();
        }

        public void CreateDefaultAccounts()
        {
            for (int i = 100; i <= 1000; i += 100)
            {
                accounts.Add(new Account.Account(i, 1000, $"user{i}", $"password{i}"));
            }
        }

        public List<Account.Account> GetAccounts() => accounts;

        public Account.Account? AuthenticateAccount(int accountNumber, string password)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            return account != null && account.VerifyPassword(password) ? account : null;
        }
    }
}
