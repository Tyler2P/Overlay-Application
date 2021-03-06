using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			ReadConfig();
		}

		public void ReadConfig()
		{
			if (File.Exists("Settings.billy"))
			{
				string line;

				TextReader sr = new StreamReader("Settings.billy");
				while ((line = sr.ReadLine()) != null)
				{
					var seperatedData = line.Split(new[] { ";" }, StringSplitOptions.None);
					string title = seperatedData[0];
					string description = seperatedData[1];
					string image = seperatedData[2];

					try
					{
						TitleInput.Text = title;
						DescInput.Text = description;
						ImageName.Text = image;
					}
					catch
					{
						return;
					}
				}
				sr.Close();
			}
		}
		public async Task WriteCache(string text, string description, string imagePath)
		{
			if (File.Exists("Settings.billy"))
			{
				TextWriter sw = new StreamWriter("Settings.billy");
				await sw.WriteLineAsync(string.Join(";", text, description, imagePath));
				sw.Close();
			}
			else
			{
				File.CreateText("Settings.billy");
				TextWriter sw = new StreamWriter("Settings.billy");
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
		private async void SaveSettings(object sender, RoutedEventArgs e)
		{
			try
			{
				await WriteCache(TitleInput.Text, DescInput.Text, ImageName.Text);
				this.NavigationService.Navigate(new Overlay());
			}
			catch
			{
				Process.Start(Application.ResourceAssembly.Location);
				Application.Current.Shutdown();
			}
		}
		private void ShutdownApplication(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}