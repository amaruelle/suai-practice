using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace L01GAMUYLO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); // DriveInfo без квадратных скобок это класс, GetDrives статический метод который возвращает имена всех логических дисков компьютера 
            foreach (DriveInfo drive in drives) // все диски на вывод в combobox
            {
                Disks.Items.Add(drive.Name); // Заполнение comboBox именами дисков
            }
        }

        private void FoldersColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (FoldersColumn.SelectedIndex >= 0) // чтобы выделенный предмет был больше или равно нулю (-1 это ничего не выбрано)
            {
                SubfoldersColumn.Items.Clear(); // чистка листа подкаталогов
                DirectoryInfo directory1 = new DirectoryInfo(FoldersColumn.SelectedItem.ToString()); // это нужно будет для того что бы найти файл

                try // проверка на открытие файла, ловим исключение в случае отсутствия доступа
                {
                    FileInfo[] files = directory1.GetFiles(); // получаем все файлы в директории
                    foreach (FileInfo file in files) // добавляем в listBox все файлы которые получили в цикле
                    {
                        SubfoldersColumn.Items.Add(directory1 + "\\" + file.Name);
                    }
                }

                catch
                {
                    MessageBox.Show("Доступ запрещён.");
                    return;
                }


                Properties.Text = ""; // чистка сообщения
                DirectoryInfo dr = new DirectoryInfo(FoldersColumn.SelectedItem.ToString()); // создаем новый DirectoryInfo из выделения, чтобы вывести информацию
                Properties.Text = $"Полное название каталога:\n{dr.FullName}\n" +
                    $"\nВремя создания: \n{dr.CreationTime}\n" +
                    $"\nКорневой каталог:\n{dr.Root}";
            }
        }

        private void SubfoldersColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubfoldersColumn.SelectedItem != null)
            {
                Process.Start(@"" + SubfoldersColumn.SelectedItem.ToString()); // запуск файла
            }
        }

        private void Disks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Properties.Text = ""; // очистка текста
            SubfoldersColumn.Items.Clear();
            FoldersColumn.Items.Clear();


            DriveInfo disk = new DriveInfo(Disks.SelectedItem.ToString());
            DirectoryInfo dr = new DirectoryInfo(Disks.SelectedItem.ToString()); // информация обо всех каталогах в диске

            foreach (var d in dr.GetDirectories()) // Весь список подкаталогов проходим и каждый записываем в переменную, чтобы вывести
            {
                FoldersColumn.Items.Add(dr + d.Name);
                Properties.Text = $"Диск:\n{disk}\n" +
                                $"\nОбъём диска:\n{(((disk.TotalSize) / 1024) / 1024) / 1024} Гб\n" +
                                $"\nОбъем свободного места:\n{(((disk.TotalFreeSpace) / 1024) / 1024) / 1024} Гб";
            }
        }
        
    }
}