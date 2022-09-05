using System;
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
using DataLayer;
using DataLayer.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsxaml.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        private DataLayer.Models.StartingEleven player = new DataLayer.Models.StartingEleven();
        public PlayerUC(DataLayer.Models.StartingEleven se)
        {
            player = se;
            InitializeComponent();
            lblName.Content = se.Name;
            lblShirtNbr.Content = se.ShirtNumber;

            if (!String.IsNullOrEmpty(se.Picture))
            {
                Uri i = new Uri(se.Picture);
                imgPlayer.Source = new BitmapImage(i);
            }
        }

        //na klik otvori detalje o igracu
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PlayerDetails pd = new PlayerDetails(player);
            pd.ShowDialog();
        }
    }
}
