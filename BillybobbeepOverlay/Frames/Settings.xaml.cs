using Microsoft.Win32;
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

namespace BillybobbeepOverlay.Frames
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        public async Task WriteCache(string text, string description, string imagePath)
        {
            if (File.Exists("Settings.config"))
            {
                TextWriter sw = new StreamWriter("Settings.config");
                await sw.WriteLineAsync(string.Join(";", text,description, imagePath));
                sw.Close();
            }
            else
            {
                File.CreateText("Settings.config");
                TextWriter sw = new StreamWriter("Settings.config");
                await sw.WriteLineAsync(string.Join(";", text, description, imagePath));
                sw.Close();
            }
        }
        private void UploadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = ".png";
            fd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            if (fd.ShowDialog() == true)
            {
                string filename = fd.FileName;
                ImageName.Text = filename;
            }
        }

        private void TopMostEnabled(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow.Topmost = true;
        }

        private void TopMostDisabled(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow.Topmost = false;
        }
        private void ReturnToHomePage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Overlay());
        }
        private async Task SaveSettings(object sender, RoutedEventArgs e)
        {
            await WriteCache(TitleInput.Text, DescInput.Text, ImageName.Text);
            this.NavigationService.Navigate(new Overlay());
        }
        private void ShutdownApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}