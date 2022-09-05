using DataLayer.Models;
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
using System.IO;
using DataLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    /// 

    public partial class TeamDetails : Window
    {
        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string wTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\results.json");
        private static readonly string wTeamFilePath = Path.GetFullPath(wTeamFile);

        private static readonly string mTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\results.json");
        private static readonly string mTeamFilePath = Path.GetFullPath(mTeamFile);


        private const string dataApi = "Api";
        private const string wUrl = "http://worldcup.sfg.io/teams/results";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/teams/results";


        private static FavouriteTeam Fav;
       

        public TeamDetails(FavouriteTeam fav)
        {
            Fav = fav;
            InitializeComponent();
            FillData();
            
        }

        //napuni s podacima
        private async void FillData()
        {
            Settings s = GetData.LoadFromFile(settingsFilePath);
            

            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var wResults = await GetData.FromUrlAsync<TeamResults>(wUrl);
                            Fill(wResults);     
                            break;
                        case Championship.Men2018:
                            var mResults = await GetData.FromUrlAsync<TeamResults>(mUrl);
                            Fill(mResults);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var teamsW = GetData.ReadFromFile<TeamResults>(wTeamFilePath);
                            Fill(teamsW);
                            break;
                        case Championship.Men2018:
                            var teamsM = GetData.ReadFromFile<TeamResults>(mTeamFilePath);
                            Fill(teamsM);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       

        private void Fill(List<TeamResults> results)
        {
            foreach (var item in results)
            {
                if (Fav.Country == item.Country.ToUpper())
                {
                    lblCountryBox.Content = item.Country;
                    lblCodeBox.Content = item.FifaCode;
                    lblPlayedBox.Content = item.GamesPlayed;
                    lblWinsBox.Content = item.Wins;
                    lblLosesBox.Content = item.Losses;
                    lblDrawsBox.Content = item.Draws;
                    lblGoalsZBox.Content = item.GoalsFor;
                    lblGoalsPBox.Content = item.GoalsAgainst;
                    lblGoalsDBox.Content = item.GoalDifferential;
                   
                }
            }
        }

        //zatvaranje
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
