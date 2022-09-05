using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string file = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(file);

        public double height;
        public double width;

       
        Settings s;
       
        public MainWindow()
        {
            LoadSettings();
            InitializeComponent();
            FillWithData();
            this.Closing += MainWindow_Closing;

        }

        
        //ako je jezik vec odabran, postavi ga
        public void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                s = GetData.LoadFromFile(settingsFilePath);
                switch (s.Language)
                {
                    case DataLayer.Models.Language.English:
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
                        break;
                    case DataLayer.Models.Language.Croatian:
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                        break;
                    default:
                        break;
                }

            }
        }

      
        //napuni s podacima (iz enuma)
        private void FillWithData()
        {
            foreach (var item in Enum.GetValues(typeof(Championship)))
            {
                cbChamp.Items.Add(item);
            }
           

            foreach (var item in Enum.GetValues(typeof(Language)))
            {
                cbLanguage.Items.Add(item);
            }
           

            foreach (var item in Enum.GetValues(typeof(ScreenResolution)))
            {
                cbScreen.Items.Add(item);
            }
            

            if (File.Exists(settingsFilePath))
            {
                cbLanguage.SelectedItem = s.Language;
                cbChamp.SelectedItem = s.Championship;
                cbScreen.SelectedItem = s.Screen;  

            }
           
        }

        //rezolucija, poziva se na svaku promjenu
        private void cbScreen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            s.Screen = (ScreenResolution)Enum.Parse(typeof(ScreenResolution), cbScreen.SelectedItem.ToString());
                
            
            if(!File.Exists(settingsFilePath))
            {
                s = new Settings();
                s.Screen = (ScreenResolution)Enum.Parse(typeof(ScreenResolution), cbScreen.SelectedItem.ToString());
                SetInCenter();
            }

            switch (s.Screen)
            {
                case ScreenResolution.full:
                    WindowState = WindowState.Maximized;
                    width = SystemParameters.PrimaryScreenWidth;
                    height = SystemParameters.PrimaryScreenHeight;
                    break;
                case ScreenResolution.maxi:
                    SetScreen(1280, 720);
                    break;
                case ScreenResolution.midi:
                   SetScreen(854, 480);
                    break;
                case ScreenResolution.mini:
                    SetScreen(426, 240);
                    break;
                default:
                    break;
            }
        }

        private void SetScreen(double w, double h)
        {
            WindowState = WindowState.Normal;
            Application.Current.MainWindow.Height = h;
            Application.Current.MainWindow.Width = w;
            SetInCenter();
            width = Width;
            height = Height;
        }

        private void SetInCenter()
        {
            double width = SystemParameters.PrimaryScreenWidth;
            double heigth = SystemParameters.PrimaryScreenHeight;
            double wWidth = Width;
            double wHeight = Height;
            Left = (width / 2) - (wWidth / 2);
            Top = (heigth / 2) - (wHeight / 2);
        }
        

        //odabir prvenstva, poziv na svaku promjenu
        private void cbChamp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (File.Exists(settingsFilePath))
            {
                s.Championship = (Championship)Enum.Parse(typeof(Championship), cbChamp.SelectedItem.ToString()); 
            }
            else
            {
                s = new Settings();
                s.Championship = (Championship)Enum.Parse(typeof(Championship), cbChamp.SelectedItem.ToString());
            }
           
        }

        //odabir jezika, poziva se na svaku promjenu
        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            s.Language = (Language)Enum.Parse(typeof(Language), cbLanguage.SelectedItem.ToString());


            if (!File.Exists(settingsFilePath))
            {
                s = new Settings();
                s.Language = (Language)Enum.Parse(typeof(Language), cbLanguage.SelectedItem.ToString());
            }

            switch (s.Language)
            {
                case DataLayer.Models.Language.English:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(""); 
                    break;
                case DataLayer.Models.Language.Croatian:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                    break;
                default:
                    break;
            }

            lblChamp.Content = Properties.Resources.Prvenstvo;
            lblLanguage.Content = Properties.Resources.Jezik;
            lblScreen.Content = Properties.Resources.Rezolucija;
            btnSave.Content = Properties.Resources.Spremi;
        }


        //potvrda odabranih opcija
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (s.Language == DataLayer.Models.Language.English)
            {
                ShowMessage(sender, e, "Are you sure?", "Confirmation");
            }
            else
            {
                ShowMessage(sender, e, "Jeste li sigurni?", "Potvrda");
            }


        }

        private void ShowMessage(object sender, RoutedEventArgs e, string message, string title)
        {
            var result = MessageBox.Show(message,
                                         title,
                                         MessageBoxButton.YesNo,
                                        MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                SaveAll(sender, e);
            }
        }

        //enter i escape
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveAll(sender, e);
            }
           
        }


        //spremi i otvori novi window
        private void SaveAll(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings((Championship)cbChamp.SelectedItem, (Language)cbLanguage.SelectedItem, (ScreenResolution)cbScreen.SelectedItem);
            GetData.WriteInFile<Settings>(set, settingsFilePath);
            Hide();
            FavouriteNationalTeam ft = new FavouriteNationalTeam(width, height);
            ft.Height = height;
            ft.Width = width;
            ft.ShowDialog();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ConfirmationBox con = new ConfirmationBox();
            con.ShowDialog();
            if (con.btnCancel.ClickMode == ClickMode.Release)
            {
                e.Cancel = true;
            }

        }
    }
}
