using BillybobbeepOverlay.Frames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace BillybobbeepOverlay
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool windowActive = true;
		public MainWindow()
		{
			InitializeComponent();
			if (!File.Exists("Settings.billy"))
			{
				PageFrame.Content = new Frames.Settings();
			} 
			else if (PageFrame.Content == null)
			{
				PageFrame.Content = new Frames.Overlay();
			}
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}
		private void Window_Activated(object sender, EventArgs e)
        {
			if (!windowActive)
            {
				windowActive = true;
				SettingsBtn.Visibility = Visibility.Visible;
			}
		}
		private void Window_Deactivated(object sender, EventArgs e)
        {
			if (windowActive)
            {
				windowActive = false;
				SettingsBtn.Visibility = Visibility.Hidden;
			}
		}
		public bool WindowIsActive()
        {
			return windowActive;
        }
		public bool ChangePage(object page)
		{
			PageFrame.Content = page;
			return true;
		}

        private void Open_Settings(object sender, MouseButtonEventArgs e)
        {
			if (windowActive)
            {
				PageFrame.NavigationService.Navigate(new Frames.Settings());
				SettingsBtn.Visibility = Visibility.Hidden;
			}
        }
    }
}