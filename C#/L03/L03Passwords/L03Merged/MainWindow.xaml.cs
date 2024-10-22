﻿using System;
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
using System.IO;

namespace L03Merged
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            var disp = DisplacementInput.Text;
            var pass = new Password(PasswordInput.Text);
            var passCipher = new CaesarCipher(PasswordInput.Text, Convert.ToInt32(disp));
            MessageBox.Show(pass.GetHealth());
            MessageBox.Show(passCipher.Encipher(PasswordInput.Text, Convert.ToInt32(disp)));

            StreamReader reader = new StreamReader(@"C:\Users\amaru\OneDrive\Desktop\CODED\C#\L03\L03Passwords\passwords.txt");
            bool ready = false;

            while (!reader.EndOfStream)
            {
                string iterable = reader.ReadLine();
                if (iterable == "") break;
                string comparable = passCipher.Encipher(PasswordInput.Text, Convert.ToInt32(disp)) + iterable[iterable.Length - 1];
                if (iterable == comparable)
                {
                    MessageBox.Show("Correct password.");
                    ready = true;
                    break;
                }
            }
            reader.Close();

            if (!ready)
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\amaru\OneDrive\Desktop\CODED\C#\L03\L03Passwords\passwords.txt", true);
                writer.Write(passCipher.Encipher(PasswordInput.Text, Convert.ToInt32(disp)));
                writer.WriteLine('3');
                MessageBox.Show("Password not found. Register in process...");
                writer.Close();
            }
        }
    }
}
