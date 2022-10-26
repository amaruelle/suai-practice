using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
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
using L1DBGAMUYLO;

namespace L1DBGAMUYLO
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        bool loginCheck;
        bool role;
        bool enter;
        string enterLogin = "SELECT * from Users where login = log AND password = pass;";

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginInput.Text;
            string pass = passInput.Text;
            if (login.Trim() == "") { MessageBox.Show("Логин не задан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            else { if (pass.Trim() == "") { MessageBox.Show("Пароль не задан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); } else { loginCheck = true; } };
            if (loginCheck)
            {
                string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"E:\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
                OleDbConnection connection = new OleDbConnection(connectionstring);
                connection.Open();
                OleDbCommand oleDbCommand = connection.CreateCommand();
                oleDbCommand.CommandText = enterLogin;
                oleDbCommand.Parameters.Add("log", OleDbType.VarChar, 255).Value = loginInput.Text;
                oleDbCommand.Parameters.Add("pass", OleDbType.VarChar, 255).Value = passInput.Text;
                var exists = oleDbCommand.ExecuteScalar();

                if (exists != null)
                {
                    string sql = "SELECT login, role FROM Users where login = log AND role = 'Admin';";
                    string connectionstring2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"E:\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
                    OleDbConnection connection2 = new OleDbConnection(connectionstring2);
                    connection2.Open();
                    OleDbCommand oleDbCommand2 = connection2.CreateCommand();
                    oleDbCommand2.CommandText = sql;
                    oleDbCommand2.Parameters.Add("log", OleDbType.VarChar, 255).Value = loginInput.Text;
                    var adminControl = oleDbCommand2.ExecuteScalar();
                    string path = @"E:\L1DBGAMUYLO\logs.txt";
                    StreamWriter logs = new StreamWriter(path, true);
                    if (adminControl != null)
                    {
                        logs.Write($"{login}, {DateTime.Now.ToString()},  ");
                        logs.Close();
                        isAdmin();
                    }
                    else
                    {
                        logs.Write($"{login}, {DateTime.Now.ToString()}, ");
                        logs.Close();
                        isUser();
                    }
                }
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Content = register;
        }

        public MainWindow isUser()
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
            return window;
        }

        private void isAdmin()
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
