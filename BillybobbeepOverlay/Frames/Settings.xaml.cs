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

        public async Task WriteCache(string[] data)
        {
            TextWriter sw = new StreamWriter("Settings.config");
            await sw.WriteLineAsync(string.Join(";", data));
            sw.Close();
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

                //BitmapImage Image = new BitmapImage(new Uri(fd.FileName));
                //var fileName = DateTime.Now.ToFileNameFormat() + Path.GetExtension(fd.FileName);
                //var imagePath = Path.Combine("C:\" + fileNameToSave);

                //File.Copy(fd.FileName, imagePath);
            }
        }
    }
}