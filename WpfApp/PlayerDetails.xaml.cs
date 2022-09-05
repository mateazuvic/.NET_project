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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        public PlayerDetails(DataLayer.Models.StartingEleven player)
        {
            InitializeComponent();
            lblNameBox.Content = player.Name;
            lblNbrBox.Content = player.ShirtNumber;
            lblPosBox.Content = player.Position;
            if (player.Captain == true)
            {
                lblCaptain.Content = "CAPTAIN";
            }
            lblGoalsBox.Content = player.NbrOfGoals;
            lblYellowBox.Content = player.NbrOfYellowCards;
            if (!String.IsNullOrEmpty(player.Picture))
            {
                Uri i = new Uri(player.Picture);
                imgPlayer.Source = new BitmapImage(i);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
