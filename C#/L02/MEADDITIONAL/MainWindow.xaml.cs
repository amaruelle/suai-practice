using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MEADDITIONAL
{
    public partial class MainWindow : Window
    {
        string[] files = Directory.GetFiles(@"C:\Users\amaru\OneDrive\Desktop\CODED\C#\MEADDITIONAL\images", "*.jpg", SearchOption.AllDirectories);
        public int selectedItem;
        public MainWindow()
        {
            InitializeComponent();
            switch (files.Length)
            {
                case 1:
                    Image1.Source = new BitmapImage(new Uri(files[0], UriKind.RelativeOrAbsolute));
                    Image2.IsEnabled = false;
                    Image3.IsEnabled = false;
                    Left.IsEnabled = false;
                    Right.IsEnabled = false;
                    break;
                case 2:
                    Image1.Source = new BitmapImage(new Uri(files[0], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[1], UriKind.RelativeOrAbsolute));
                    Image3.IsEnabled = false;
                    Left.IsEnabled = false;
                    Right.IsEnabled = false;
                    break;
                case 3:
                    Image1.Source = new BitmapImage(new Uri(files[0], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[2], UriKind.RelativeOrAbsolute));
                    Left.IsEnabled = false;
                    Right.IsEnabled = false;
                    break;
                default:
                    Image1.Source = new BitmapImage(new Uri(files[0], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[2], UriKind.RelativeOrAbsolute));
                    break;
            }
        }

        private void SwapPhoto(bool direction)
        {
            if (direction)
            {
                if (selectedItem + 2 < files.Length)
                {
                    Image1.Source = new BitmapImage(new Uri(files[selectedItem], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[selectedItem + 1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[selectedItem + 2], UriKind.RelativeOrAbsolute));
                    selectedItem++;
                }
                else
                {
                    selectedItem = 0;
                    Image1.Source = new BitmapImage(new Uri(files[selectedItem], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[selectedItem + 1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[selectedItem + 2], UriKind.RelativeOrAbsolute));
                    selectedItem++;
                }
            }
            else //Если листаем назад
            {
                if (selectedItem - 2 > 0)
                {
                    Image1.Source = new BitmapImage(new Uri(files[selectedItem], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[selectedItem - 1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[selectedItem - 2], UriKind.RelativeOrAbsolute));
                    selectedItem--;
                }
                else
                {
                    selectedItem = files.Length - 1;
                    Image1.Source = new BitmapImage(new Uri(files[selectedItem], UriKind.RelativeOrAbsolute));
                    Image2.Source = new BitmapImage(new Uri(files[selectedItem - 1], UriKind.RelativeOrAbsolute));
                    Image3.Source = new BitmapImage(new Uri(files[selectedItem - 2], UriKind.RelativeOrAbsolute));
                    selectedItem--;
                }
            }
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            SwapPhoto(true);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            SwapPhoto(false);
        }
    }
}