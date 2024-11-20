using ATMApplication.User_Interface;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATMApplication.User_Interface
{
    public partial class Login : Window
    {
        private Bank.Bank bank;
        public Login()
        {
            InitializeComponent();
            bank = new Bank.Bank();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int accountNumber;
            if (int.TryParse(AccountNumberBox.Text, out accountNumber))
            {
                var account = bank.AuthenticateAccount(accountNumber, PasswordBox.Password);
                if (account != null)
                {
                    MessageBox.Show($"Welcome {account.AccountHolderName}!", "Success");
                    var menu = new Menu(account);
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid account number or password.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid account number.", "Error");
            }
        }
    }
}