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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace L1DBGAMUYLO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ExecuteRequest(string sql)
        {
            DataTable table = new DataTable();
            string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"E:\L1DBGAMUYLO\College.mdb;Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            OleDbCommand oleDbCommand = new OleDbCommand(sql, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(oleDbCommand);
            dataAdapter.Fill(table);
            data.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from students";
            ExecuteRequest(sql);
            showStats();
        }

        private void SurnameExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string surname = SurnameBox.Text.ToString();
                string sql = "Select Familia, №gr, Budget from students WHERE Familia=\"" + surname + "\"";
                ExecuteRequest(sql);
            }
            catch(OleDbException)
            { MessageBox.Show("Нет подключения к базе данных."); };
        }

        private void ManAge_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT Students.Familia, Students.Imya, Year(Now())-Year([Datarogd]) AS Vozrast FROM Students WHERE Pol = 'М';";
            ExecuteRequest(sql);
        }

        private void SurnameAndInitials_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT Students.№gr, Students.Familia + \" \"+ LEFT(Students.Otchestvo, 1) + \". \" + LEFT(Students.Imya, 1) + \".\" AS Inicialy FROM Students WHERE Students.№gr = \"{SurnameBox.Text}\";";
            ExecuteRequest(sql);
        }

        private void YearOfBirth_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT Students.Familia, Students.№gr, Year([Datarogd]) AS Datarogd FROM Students WHERE Year([Datarogd]) = \"{SurnameBox.Text}\";";
            ExecuteRequest(sql);
        }

        private void ForeignCountry_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT Students.Familia, Students.№gr FROM Students WHERE Students.Gorod IS NOT NULL;";
            ExecuteRequest(sql);
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from students;";
            DataTable table = new DataTable();
            string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"Z:\021\Gamuylo\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            OleDbCommand oleDbCommand = connection.CreateCommand();
            oleDbCommand.CommandText = "insert into Students(№St) values('10004');";
            try
            {
                oleDbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex}");
            }
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            dataAdapter.Fill(table);
            data.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from students;";
            DataTable table = new DataTable();
            string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"Z:\021\Gamuylo\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            OleDbCommand oleDbCommand = connection.CreateCommand();
            oleDbCommand.CommandText = "DELETE №St FROM students WHERE №St = 10004;";
            try
            {
                oleDbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex}");
            }
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            dataAdapter.Fill(table);
            data.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from students;";
            DataTable table = new DataTable();
            string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + @"Z:\021\Gamuylo\L1DBGAMUYLO\College.mdb; Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            OleDbCommand oleDbCommand = connection.CreateCommand();
            oleDbCommand.CommandText = "UPDATE Students SET Familia = \'Aboba\' WHERE Familia = \'Терентьев\';";
            try
            {
                oleDbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex}");
            }
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            dataAdapter.Fill(table);
            data.ItemsSource = table.DefaultView;
            connection.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string path = @"E:\L1DBGAMUYLO\logs.txt";
            StreamWriter logs = new StreamWriter(path, true);
            logs.WriteLine(DateTime.Now.ToString());
            logs.Close();
        }

        private void showStats()
        {
            string sql = "SELECT COUNT(Budget) as budgetOn FROM Students WHERE Budget = Yes;";
            string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"E:\L1DBGAMUYLO\College.mdb;Persist Security Info=False";
            int countOfBudgets = 0;
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            OleDbCommand oleDbCommand = new OleDbCommand(sql, connection);
            countOfBudgets = (int)oleDbCommand.ExecuteScalar();
            StatsBlock.Text = $"Количество людей на бюджете: {countOfBudgets}";
            connection.Close();
        }
    }
}
