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
        }

		public void ReadConfig()
		{
			if (File.Exists("Settings.config"))
			{
				TextReader sr = new StreamReader("Settings.config");

				sr.Close();
			}
			else
			{
				File.CreateText("Settings.config");
			}
		}
	}
}
