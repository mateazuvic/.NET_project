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
using DataLayer.Models;
using System.Diagnostics;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for FavouriteNationalTeam.xaml
    /// </summary>
    public partial class FavouriteNationalTeam : Window
    {
        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string wTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\teams.json");
        private static readonly string wTeamFilePath = Path.GetFullPath(wTeamFile);

        private static readonly string mTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\teams.json");
        private static readonly string mTeamFilePath = Path.GetFullPath(mTeamFile);

        private static readonly string wMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string wMatchesFilePath = Path.GetFullPath(wMatchesFile);

        private static readonly string mMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string mMatchesFilePath = Path.GetFullPath(mMatchesFile);

        private static readonly string favTeamFile = Path.Combine(dir, @"..\..\..\favTeam.txt");
        private static readonly string favTeamFilePath = Path.GetFullPath(favTeamFile);

        private static readonly string imagesFile = Path.Combine(dir, @"..\..\..\slike.txt");
        private static readonly string imagesFilePath = Path.GetFullPath(imagesFile);

        private const string wUrlOpp = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string mUrlOpp = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";

        private const string dataApi = "Api";
        private const string wUrl = "http://worldcup.sfg.io/teams/";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/teams";

        OpponentTeam ot;
        OpponentTeam selected;
        List<OpponentTeam> opponents = new List<OpponentTeam>();
        FavouriteTeam ft;
        Settings s;

        public double height;
        public double width;
        public double formHe;
        public double formWi;



        public FavouriteNationalTeam(double width, double height)
        {
            if (width == SystemParameters.PrimaryScreenWidth)
            {
                WindowState = WindowState.Maximized;
                formWi = SystemParameters.PrimaryScreenWidth;
                formHe = SystemParameters.PrimaryScreenHeight;
            }
            else
            {
                this.Width = width;
                this.Height = height;
                formHe = this.Height;
                formWi = this.Width;
                SetInCenter(width, height);
            }

           
            InitializeComponent();
            FillWithData();
            this.Closing += FavouriteNationalTeam_Closing;
        }

       
        //napuni s podacima
        private async void FillWithData()
        {
            s = GetData.LoadFromFile(settingsFilePath);
            if (File.Exists(favTeamFilePath))
            {
                ft = GetData.LoadFromFileFavTeam(favTeamFilePath); 
            }
            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);


            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var wResults = await GetData.FromUrlAsync<TeamResults>(wUrl);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            var wResultsOpp = await GetData.FromUrlAsync<Match>(wUrlOpp + ft.Code);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            if (cbOpponent.SelectedItem == null || cbFavTeam.SelectedItem == null)
                            {
                                Fill(wResults);
                                if (cbOpponent.Items.Count < 1)
                                {
                                    FillOpponent(ft, wResultsOpp);
                                }

                            }
                            else if (cbOpponent.SelectedItem != null && cbFavTeam.SelectedItem != null)
                            {
                                foreach (var item in wResultsOpp)
                                {
                                    if (selected.Country.ToLower() == item.HomeTeam.Country.ToLower() || selected.Country.ToLower() == item.AwayTeam.Country.ToLower())
                                    {
                                        CheckSelection(ft, item);
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 10);
                            break;
                        case Championship.Men2018:
                            var mResults = await GetData.FromUrlAsync<TeamResults>(mUrl);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            var mResultsOpp = await GetData.FromUrlAsync<Match>(mUrlOpp + ft.Code);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            if (cbOpponent.SelectedItem == null || cbFavTeam.SelectedItem == null)
                            {
                                Fill(mResults);
                                if (cbOpponent.Items.Count < 1)
                                {
                                    FillOpponent(ft, mResultsOpp);
                                }

                            }
                            else if (cbOpponent.SelectedItem != null && cbFavTeam.SelectedItem != null)
                            {
                                foreach (var item in mResultsOpp)
                                {
                                    if (selected.Country.ToLower() == item.HomeTeam.Country.ToLower() || selected.Country.ToLower() == item.AwayTeam.Country.ToLower())
                                    {
                                        CheckSelection(ft, item);
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 10);
                            break;
                    }

                }
                else
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var teamsW = GetData.ReadFromFile<TeamResults>(wTeamFilePath);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            var teamsWopp = GetData.ReadFromFile<Match>(wMatchesFilePath);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            if (cbOpponent.SelectedItem == null || cbFavTeam.SelectedItem == null)
                            {
                                Fill(teamsW);
                                if (cbOpponent.Items.Count < 1 && cbFavTeam.SelectedItem != null)
                                {
                                    FillOpponent(ft, teamsWopp);
                                }

                            }
                            else if (cbOpponent.SelectedItem != null && cbFavTeam.SelectedItem != null)
                            {
                                foreach (var item in teamsWopp)
                                {
                                    if ((selected.Country.ToLower() == item.HomeTeam.Country.ToLower() && ft.Country.ToLower() == item.AwayTeam.Country.ToLower()) || (selected.Country.ToLower() == item.AwayTeam.Country.ToLower() && ft.Country.ToLower() == item.HomeTeam.Country.ToLower()))
                                    {
                                        CheckSelection(ft, item);
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 10);
                            break;
                        case Championship.Men2018:
                            var teamsM = GetData.ReadFromFile<TeamResults>(mTeamFilePath);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            var teamsMopp = GetData.ReadFromFile<Match>(mMatchesFilePath);
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 30);
                            if (cbOpponent.SelectedItem == null || cbFavTeam.SelectedItem == null)
                            {
                                Fill(teamsM);
                                if (cbOpponent.Items.Count < 1)
                                {
                                    FillOpponent(ft, teamsMopp);
                                }

                            }
                            else if (cbOpponent.SelectedItem != null && cbFavTeam.SelectedItem != null)
                            {
                                foreach (var item in teamsMopp)
                                {
                                    if ((selected.Country.ToLower() == item.HomeTeam.Country.ToLower() && ft.Country.ToLower() == item.AwayTeam.Country.ToLower()) || (selected.Country.ToLower() == item.AwayTeam.Country.ToLower() && ft.Country.ToLower() == item.HomeTeam.Country.ToLower()))
                                    {
                                        CheckSelection(ft, item);
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                            progressBar.progressBar.Value = GetData.IncreasePercentage(progressBar.Percentage, 10);
                            break;

                    }
                }
            
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        

        private void SetInCenter(double w, double h)
        {
            double width = SystemParameters.PrimaryScreenWidth;
            double heigth = SystemParameters.PrimaryScreenHeight;
            double wWidth = w;
            double wHeight = h;
            Left = (width / 2) - (wWidth / 2);
            Top = (heigth / 2) - (wHeight / 2);
            
        }

        private void Fill(List<TeamResults> results)
        {

            //ako ne sadrzi dodaj, ako vec sadrzi ne!!
            foreach (var r in results)
            {
                if (!cbFavTeam.Items.Cast<TeamResults>().Contains(r))
                {
                    cbFavTeam.Items.Add(r);
                } 
            }

           
            if (File.Exists(favTeamFilePath))
            {
                cbFavTeam.SelectedIndex = GetData.LoadFromFileFavTeam(favTeamFilePath).SelectedIndex;


            }

        }

       //napuni s podacima protivnike
        private void FillOpponent(FavouriteTeam ft, List<Match> matches)
        {
            
            foreach (var item in matches)
            {
               
                var name = ft.Country.ToLower();
                var name2 = item.HomeTeamCountry.ToLower();
                var name3 = item.AwayTeamCountry.ToLower();
                  SetData(ft, item, name, name2, name3); 
                
                if (cbFavTeam.SelectedItem != null && cbOpponent.SelectedItem != null)
                {
                    CheckSelection(ft, item);
                }
                
               
            }
            
        }

        private void SetData(FavouriteTeam ft, Match item, string name, string name2, string name3)
        {
            if (name == name2)
            {

                ot = new OpponentTeam(item.AwayTeam.Country.ToUpper(), item.AwayTeam.Code.ToUpper(), item.AwayTeam.Goals);
                opponents.Add(ot);
                ft.Opponents = opponents;

                cbOpponent.Items.Add(ot);


            }
            else if (name == name3)
            {
                ot = new OpponentTeam(item.HomeTeam.Country.ToUpper(), item.HomeTeam.Code.ToUpper());
                opponents.Add(ot);
                ft.Opponents = opponents;

                cbOpponent.Items.Add(ot);

            }
        }

        private void CheckSelection(FavouriteTeam ft, Match item)
        {
           
            selected = (OpponentTeam)cbOpponent.SelectedItem;
            if (selected.Country.ToLower() == item.HomeTeamCountry.ToLower() && ft.Country.ToLower() == item.AwayTeam.Country.ToLower())
            { 
                lblOpGoals.Content = item.HomeTeam.Goals;
                lblFavGoals.Content = item.AwayTeam.Goals;
            }
            else if(selected.Country.ToLower() == item.AwayTeam.Country.ToLower() && ft.Country.ToLower() == item.HomeTeamCountry.ToLower())
            {
                lblFavGoals.Content = item.HomeTeam.Goals;
                lblOpGoals.Content = item.AwayTeam.Goals;
            }
        }

        

        //promjena Fav teama

        private void cbFavTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblOpGoals.Content = "";
            lblFavGoals.Content = "";
            string fav = ft.Country + " (" + ft.Code + ")";
            if (fav != cbFavTeam.SelectedItem.ToString())
            {
                File.Delete(imagesFilePath);
            }
            ft = new FavouriteTeam(cbFavTeam.SelectedItem.ToString(), cbFavTeam.SelectedIndex);
            GetData.WriteInFile<FavouriteTeam>(ft, favTeamFilePath);
            cbOpponent.Items.Clear();
            FillWithData();
            
           
            
        }

        //promjena protivnika
        private void cbOppTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblFavGoals.Content = "";
            lblOpGoals.Content = "";

            selected = (OpponentTeam)cbOpponent.SelectedItem;
            ot = selected;
            //cbOpponent.Items.Clear();
            foreach (var o in cbOpponent.Items)
            {
                if (o == selected)
                {
                    
                    FillWithData();
                    
                }
            }
  
        }

        //prikazi podatke o Fav timu
        private void btnFav_Click(object sender, RoutedEventArgs e)
        {

            if (cbFavTeam.SelectedItem != null)
            {
                TeamDetails td = new TeamDetails(ft);
                td.ShowDialog(); 
            }
 
        }

        //prikazi podatke o suparnickom timu
        private void btnOp_Click(object sender, RoutedEventArgs e)
        {
            if (cbOpponent.SelectedItem != null)
            {
                TeamDetails td = new TeamDetails((FavouriteTeam)cbOpponent.SelectedItem);
                td.ShowDialog(); 
            }
        }

        //spremi i zatvori, otvori novi window
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbFavTeam.SelectedItem != null && cbOpponent.SelectedItem != null)
            {
                this.Hide();
                this.Closed += FavouriteNationalTeam_Closed;
                StartingEleven se = new StartingEleven(formWi, formHe, ft, ot);
                se.Height = formHe;
                se.Width = formWi;
                se.ShowDialog();
            }
            else
            {
                if (s.Language == DataLayer.Models.Language.English)
                {
                    MessageBox.Show("Choose both of teams in order to continue!"); 
                }
                else
                {
                    MessageBox.Show("Odaberite oba dva tima kako biste nastavili!");
                }
            }
        }

        private void FavouriteNationalTeam_Closed(object sender, EventArgs e)
        {

            this.Close();

        }

        private void FavouriteNationalTeam_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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





