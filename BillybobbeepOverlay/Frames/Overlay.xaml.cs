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
    /// Interaction logic for Overlay.xaml
    /// </summary>
    public partial class Overlay : Page
    {
        public Overlay()
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
				while((line = sr.ReadLine()) != null)
				{
					var seperatedData = line.Split(new[] { ";" }, StringSplitOptions.None);
					string title = seperatedData[0];
					string description = seperatedData[1];
					string image = seperatedData[2];

					if (title == null || title == "" || title == " ") {
						this.NavigationService.Navigate(new Settings());
                    }
					try
                    {
						Title.Text = title;
						Description.Text = description;
						Logo.Source = new BitmapImage(new Uri(image));
                    }
                    catch
                    {
						return;
                    }
                }
				sr.Close();
			}
		}
	}
}
