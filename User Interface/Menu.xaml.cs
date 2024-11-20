using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATMApplication.User_Interface
{
    public partial class Menu : Window
    {
        private Account.Account account;

        public Menu(Account.Account account)
        {
            InitializeComponent();
            this.account = account;
            UpdateInformation();
        }

        public void UpdateInformation()
        {
            Greeting.Text = $"Welcome, {account.AccountHolderName}";
            Information.Text = $"Account Number: {account.AccountNumber}\nBalance: {account.Balance:C}\nInterest Rate: {account.InterestRate}%";
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{account.Balance:C}", "Current Balance");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to deposit:", "Deposit", "0");
            if (float.TryParse(input, out var amount) && amount > 0)
            {
                account.Deposit(amount);
                MessageBox.Show($"Deposited: {amount:C}", "Success");
            }
            UpdateInformation();
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter amount to withdraw:", "Withdraw", "0");
            if (float.TryParse(input, out var amount) && account.Withdraw(amount))
            {
                MessageBox.Show($"Withdrawn: {amount:C}", "Success");
            }
            else
            {
                MessageBox.Show("Insufficient balance or invalid amount.", "Error");
            }
            UpdateInformation();
        }

        private void TransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            var transactions = string.Join("\n", account.GetTransactions());
            MessageBox.Show(string.IsNullOrEmpty(transactions) ? "No transactions yet." : transactions, "View Transactions");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }
    }
}
