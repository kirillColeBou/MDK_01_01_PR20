using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationSettings_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public MainWindow mainWindow;
        System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        ColorDialog colorDialog = new ColorDialog();

        public Settings(MainWindow _main)
        {
            InitializeComponent();
            mainWindow = _main;
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "Access file (*.accdb) | *.accdb | All files (*.*) | *.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = false;
        }

        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            tb_database.Text = ofd.FileName;    
        }

        private void SelectScreenresolution(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox cB = sender as System.Windows.Controls.ComboBox;
            TextBlock tB = cB.SelectedValue as TextBlock;
            string resolution = tB.Text;
            string[] separator = new string[1] {" x "};
            mainWindow.Width = int.Parse(resolution.Split(separator, StringSplitOptions.None)[0]);
            mainWindow.Height = int.Parse(resolution.Split(separator, StringSplitOptions.None)[1]);
        }

        private void SelectColorApplication(object sender, RoutedEventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color color = colorDialog.Color;
                gr_header.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                gr_application.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectColorText(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color color = colorDialog.Color;
                gr_text.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                lb_text.Foreground = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectFonts(object sender, RoutedEventArgs e)
        {

        }
    }
}
