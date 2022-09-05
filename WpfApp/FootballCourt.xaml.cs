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
    /// Interaction logic for StartingEleven.xaml
    /// </summary>
    public partial class StartingEleven : Window
    {
        private const string dataApi = "Api";
        private const string Ycard = "yellow-card";
        private const string Gpenalty = "goal-penalty";
        private const string Goal = "goal";
        private const string Gown = "goal-own";
        private const string wUrl = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const char DEL = '-';
        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string wMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string wMatchesFilePath = Path.GetFullPath(wMatchesFile);

        private static readonly string mMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string mMatchesFilePath = Path.GetFullPath(mMatchesFile);

        private static readonly string imagesFile = Path.Combine(dir, @"..\..\..\slike.txt");
        private static readonly string imagesFilePath = Path.GetFullPath(imagesFile);

        public double height;
        public double width;
        public double formHe;
        public double formWi;

        private FavouriteTeam ft;
        private OpponentTeam ot;

        private List<DataLayer.Models.Image> images = new List<DataLayer.Models.Image>();

        List<DataLayer.Models.StartingEleven> favPlayers;
        List<DataLayer.Models.StartingEleven> oppPlayers;
        static string favTactic = "";
        static string oppTactic = "";

        public StartingEleven(double width, double height, FavouriteTeam fav, OpponentTeam opp)
        {
            if (width == SystemParameters.PrimaryScreenWidth)
            {
                WindowState = WindowState.Maximized;
                width = SystemParameters.PrimaryScreenWidth;
                height = SystemParameters.PrimaryScreenHeight;
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
            ft = fav;
            ot = opp;
            favPlayers = new List<DataLayer.Models.StartingEleven>();
            oppPlayers = new List<DataLayer.Models.StartingEleven>();
            LoadImages();
            LoadData();
            this.Closing += StartingEleven_Closing;
            
        }

        private void LoadImages()
        {
            if (File.Exists(imagesFilePath))
            {
                images = GetData.LoadFromTxtImages(imagesFilePath);
            }
        }

        //napuni s podacima
        private async void LoadData()
        {
            Settings s = GetData.LoadFromFile(settingsFilePath);
           


            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var wResultsF = await GetData.FromUrlAsync<Match>(wUrl + ft.Code);
                            GetPlayers(wResultsF);
                            break;
                        case Championship.Men2018:
                            var mResultsF = await GetData.FromUrlAsync<Match>(mUrl + ft.Code);
                            GetPlayers(mResultsF);
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
                            var resultsW = GetData.ReadFromFile<Match>(wMatchesFilePath);
                            GetPlayers(resultsW);
                            break;
                        case Championship.Men2018:
                            var resultsM = GetData.ReadFromFile<Match>(mMatchesFilePath);
                            GetPlayers(resultsM);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetPlayers(List<Match> results)
        {
            foreach (var match in results)
            {
                if (match.HomeTeam.Country.ToUpper() == ft.Country && match.AwayTeam.Country.ToUpper() == ot.Country)
                {

                    match.HomeTeamStatistics.StartingEleven.ForEach(p => favPlayers.Add(p));
                    match.AwayTeamStatistics.StartingEleven.ForEach(p => oppPlayers.Add(p));
                    favTactic = match.HomeTeamStatistics.Tactics;
                    oppTactic = match.AwayTeamStatistics.Tactics;

                    foreach (var i in match.HomeTeamEvents)
                    {
                        foreach (var p in favPlayers)
                        {
                            CheckGoalsAndYellowCards(i, p);
                        }
                    }
                    foreach (var j in match.AwayTeamEvents)
                    {
                        foreach (var p in oppPlayers)
                        {

                            CheckGoalsAndYellowCards(j, p);

                        }
                    }

                }
                else if (match.HomeTeam.Country.ToUpper() == ot.Country && match.AwayTeam.Country.ToUpper() == ft.Country)
                {
                    
                    match.HomeTeamStatistics.StartingEleven.ForEach(p => oppPlayers.Add(p));
                    match.AwayTeamStatistics.StartingEleven.ForEach(p => favPlayers.Add(p));
                    oppTactic = match.HomeTeamStatistics.Tactics;
                    favTactic = match.AwayTeamStatistics.Tactics;

                    foreach (var i in match.AwayTeamEvents)
                    {
                        foreach (var p in favPlayers)
                        {
                            CheckGoalsAndYellowCards(i, p);
                        }
                    }
                    foreach (var j in match.HomeTeamEvents)
                    {
                        foreach (var p in oppPlayers)
                        {

                            CheckGoalsAndYellowCards(j, p);
                           
                        }
                    }
                   

                }
                continue;
            }


            favPlayers = CheckPositions(favPlayers);
            oppPlayers = CheckPositions(oppPlayers);
            DrawPlayersPos(favTactic, favPlayers, true);
            DrawPlayersPos(oppTactic, oppPlayers, false);
        }

        //prebroji zute kartone i golove
        private static void CheckGoalsAndYellowCards(TeamEvent i, DataLayer.Models.StartingEleven p)
        {

            if (i.TypeOfEvent == Ycard && i.Player == p.Name)
            {
                p.NbrOfYellowCards += 1;
            }
            //ja sam uracunala i autogolove (ipak su ih oni zabili)
            else if ((i.TypeOfEvent == Gpenalty || i.TypeOfEvent == Goal || i.TypeOfEvent == Gown) && i.Player == p.Name)
            {
                p.NbrOfGoals += 1;
            }


        }

        //prodi po pozicijama i sortiraj
        private List<DataLayer.Models.StartingEleven> CheckPositions(List<DataLayer.Models.StartingEleven> currentPlayers)
        {
            List<DataLayer.Models.StartingEleven> temp = new List<DataLayer.Models.StartingEleven>();

            DataLayer.Models.StartingEleven goalkeeper = new DataLayer.Models.StartingEleven();
            List<DataLayer.Models.StartingEleven> def = new List<DataLayer.Models.StartingEleven>();
            List<DataLayer.Models.StartingEleven> mid = new List<DataLayer.Models.StartingEleven>();
            List<DataLayer.Models.StartingEleven> forw = new List<DataLayer.Models.StartingEleven>();

            for (int i = 0; i < currentPlayers.Count(); i++)
            {
                switch (currentPlayers[i].Position)
                {
                    case Position.Defender:
                        def.Add(currentPlayers[i]);
                        break;
                    case Position.Midfield:
                        mid.Add(currentPlayers[i]);
                        break;
                    case Position.Forward:
                        forw.Add(currentPlayers[i]);
                        break;
                    case Position.Goalie:
                        goalkeeper = currentPlayers[i];
                        break;
                    default:
                        break;
                }
            }

            temp.Add(goalkeeper);
            temp.AddRange(def);
            temp.AddRange(mid);
            temp.AddRange(forw);

            return temp;
        }

        //ovisno o taktici iscrtaj
        private void DrawPlayersPos(string tactic, List<DataLayer.Models.StartingEleven> players, bool IsFav)
        {
            if (string.IsNullOrEmpty(tactic))
            {
                return;
            }

            string[] details = tactic.Split(DEL);
            int numberOfColumns = details.Length + 1;


            int def = int.Parse(details[0]);
            int mid = int.Parse(details[1]);
            int forw = 10 - (def + mid);

            for (int i = 0; i < numberOfColumns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                if (IsFav)
                {
                    gridFavorite.ColumnDefinitions.Add(cd);
                }
                else
                {
                    gridOpponent.ColumnDefinitions.Add(cd);
                }
                   
            }



            if (IsFav)
            {
                foreach (var p in players)
                {
                    for (int j = 0; j < images.Count; j++)
                    {
                        if (p.ShirtNumber == images[j].ShirtNbr)
                        {
                            p.Picture = images[j].Path;
                        }
                    }
                }
                gridFavorite.Children.Add(FillPlayerUC(players, 0, 1, 0));
                
            }
            else
            {
                gridOpponent.Children.Add(FillPlayerUC(players, 0, 1, numberOfColumns - 1));
            }
               


            int indexPlayers = 1;
            for (int i = 0; i < numberOfColumns - 1; i++)
            {
                int colIndex = i + 1;
                if (!IsFav)
                {
                    colIndex = (numberOfColumns - 2) - i;
                }
                    

                StackPanel sp = new StackPanel();

                sp = FillPlayerUC(players, indexPlayers, indexPlayers + int.Parse(details[i]), colIndex);
                if (IsFav)
                {
                    gridFavorite.Children.Add(FillPlayerUC(players, 0, 1, 0));
                    gridFavorite.Children.Add(sp);

                }
                else
                {
                    gridOpponent.Children.Add(sp);
                }
                   

                indexPlayers += int.Parse(details[i]);
            }
        }

        //napuni s user kontrolom
        private StackPanel FillPlayerUC(List<DataLayer.Models.StartingEleven> playerList, int from, int to, int collNumber)
        {
            StackPanel sp = new StackPanel();

            for (int i = from; i < to; i++)
            {

                PlayerUC puc = new PlayerUC(playerList[i]);
                
                sp.Children.Add(puc);
            }

            sp.MinWidth = 30;
            sp.MinHeight = 50;
            sp.Orientation = Orientation.Vertical;
            sp.VerticalAlignment = VerticalAlignment.Center;
            

            Grid.SetColumn(sp, collNumber);
            return sp;

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

        //otvori postavke
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            this.Closed += StartingEleven_Closed;
            MainWindow initSett = new MainWindow();
            initSett.ShowDialog();
            Close();

        }

        //zatvaranje
        private void StartingEleven_Closed(object sender, EventArgs e)
        {
            Close();
            base.OnClosed(e);
        }

        private void StartingEleven_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
