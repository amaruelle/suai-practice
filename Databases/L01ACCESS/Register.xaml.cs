using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L1DBGAMUYLO
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        bool regCheck;
        bool role;
        bool enter;

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginInput.Text;
            string pass = passInput.Text;
            if (login.Trim() == "") { MessageBox.Show("Логин не задан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            else { if (pass.Trim() == "") { MessageBox.Show("Пароль не задан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); } else { regCheck = true; } };
            if (regCheck)
            {
                string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"E:\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
                OleDbConnection connection = new OleDbConnection(connectionstring);
                connection.Open();
                OleDbCommand oleDbCommand = connection.CreateCommand();
                string request = "SELECT login, password, userID FROM Users WHERE login = log;";
                oleDbCommand.CommandText = request;
                oleDbCommand.Parameters.Add("log", OleDbType.VarChar, 255).Value = loginInput.Text;
                oleDbCommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = passInput.Text;
                var exists = oleDbCommand.ExecuteScalar();
                if (exists is null)
                {
                    if (pass == passConfirm.Text)
                    {
                        string connectionstring2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"E:\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
                        OleDbConnection connection2 = new OleDbConnection(connectionstring2);
                        connection2.Open();
                        OleDbCommand oleDbCommand2 = connection2.CreateCommand();
                        oleDbCommand.Parameters.Add("log", OleDbType.VarChar, 255).Value = loginInput.Text;
                        oleDbCommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = passInput.Text;
                        string requestAdd = $"INSERT INTO Users ([login], [password], [role]) VALUES (log, pass, 'User');";
                        oleDbCommand2.CommandText = requestAdd;
                        oleDbCommand2.ExecuteNonQuery();
                        role = false;
                        isUser();
                    }
                    else { MessageBox.Show("Пароль и подтверждение не совпадают"); };
                }
                else { MessageBox.Show("Такой пользователь уже существует"); };
            }
        }

        private void backToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Auth window = new Auth();
            (Parent as Window).Close();
            window.Show();
        }

        public void isUser()
        {
            MainWindow window = new MainWindow();
            window.SurnameExecute.IsEnabled = false;
            window.ManAge.IsEnabled = false;
            window.SurnameAndInitials.IsEnabled = false;
            window.YearOfBirth.IsEnabled = false;
            window.ForeignCountry.IsEnabled = false;
            window.Insert.IsEnabled = false;
            window.Update.IsEnabled = false;
            window.Delete.IsEnabled = false;
            window.StatsBlock.IsEnabled = false;
            window.StatsTitle.IsEnabled = false;
            window.Show();

        }

        private void isAdmin()
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
