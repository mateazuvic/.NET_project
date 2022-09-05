using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FavouritePlayers : Form
    {

        private const string dataApi = "Api";
        private const string wUrl = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";

        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string wTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\teams.json");
        private static readonly string wTeamFilePath = Path.GetFullPath(wTeamFile);

        private static readonly string mTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\teams.json");
        private static readonly string mTeamFilePath = Path.GetFullPath(mTeamFile);

        private static readonly string wMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string wMatchesFilePath = Path.GetFullPath(wMatchesFile);

        private static readonly string mMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string mMatchesFilePath = Path.GetFullPath(mMatchesFile);

        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string favTeamFile = Path.Combine(dir, @"..\..\..\favTeam.txt");
        private static readonly string favTeamFilePath = Path.GetFullPath(favTeamFile);

        private static readonly string favPlayersFile = Path.Combine(dir, @"..\..\..\favPlayers.txt");
        private static readonly string favPlayersFilePath = Path.GetFullPath(favPlayersFile);

        private static readonly string imagesFile = Path.Combine(dir, @"..\..\..\slike.txt");
        private static readonly string imagesFilePath = Path.GetFullPath(imagesFile);

        public static bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;

        Settings s;
        public int Percentage
        {
            get
            {
                return progressBar.Value;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    return;
                }
                progressBar.Value = value;

            }
        }

        private List<DataLayer.Models.Image> images = new List<DataLayer.Models.Image>();

        public FavouritePlayers()
        {
            InitializeComponent();
            LoadImages();
            FillWithData();
            this.FormClosing += FavouritePlayers_FormClosing;
            
        }

       

        private void FavouritePlayers_Load(object sender, EventArgs e)
        {
            
        }

        //ucitaj slike
        private void LoadImages()
        {
            if (File.Exists(imagesFilePath))
            {
                images = GetData.LoadFromTxtImages(imagesFilePath);
            }
            progressBar.Value = GetData.IncreasePercentage(Percentage, 15);
        }

        //napuni podacima
        private async void FillWithData()
        {
            s = GetData.LoadFromFile(settingsFilePath);
            FavouriteTeam ft = GetData.LoadFromFileFavTeam(favTeamFilePath);

            progressBar.Value = GetData.IncreasePercentage(Percentage, 15);

            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var wResults = await GetData.FromUrlAsync<Match>(wUrl + ft.Code);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            Fill(ft, wResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            LoadTxt();
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 20);

                            break;
                        case Championship.Men2018:
                            var mResults = await GetData.FromUrlAsync<Match>(mUrl + ft.Code);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            Fill(ft, mResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            LoadTxt();
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 20);
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
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            Fill(ft, resultsW);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            LoadTxt();
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 20);
                            break;
                        case Championship.Men2018:            
                            var resultsM = GetData.ReadFromFile<Match>(mMatchesFilePath);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            Fill(ft, resultsM);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 25);
                            LoadTxt();
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 20);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "GREŠKA8!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Fill(FavouriteTeam ft, List<Match> results)
        {
            foreach (var item in results)
            {
                var name = ft.Country.ToLower();
                var name2 = item.HomeTeamCountry.ToLower();
                if (name == name2)
                {
                    var players = item.HomeTeamStatistics.StartingEleven;
                    item.HomeTeamStatistics.Substitutes.ForEach(sub => players.Add(sub));
                    foreach (var p in players)
                    {
                        for (int i = 0; i < images.Count; i++)
                        {
                            if (p.ShirtNumber == images[i].ShirtNbr)
                            {
                                p.Picture = images[i].Path;
                            }
                        }
                    }
                    players.ForEach(p => flpAllPlayers.Controls.Add(new PlayersUC(p)));
                    

                    break;
                }
            }
        }

        // ako postoje vec odabrani favoriti, postavi ih u Fav panelu
        private void LoadTxt()
        {
            if (File.Exists(favPlayersFilePath))
            {
                List<StartingEleven> lse = GetData.LoadFromFileFavPlayers(favPlayersFilePath);
                FillFavPlayers(lse);

            }
        }

        private void FillFavPlayers(List<StartingEleven> favs)
        {
            foreach (var player in favs)
            {
                foreach (PlayersUC p in flpAllPlayers.Controls)
                {
                    if (player.Name == p.Player.Name)
                    {
                       
                        MoveUCtoFav(p);
                        p.SetStar();


                    }
                }
            }
        }

        //prebaci iz fav u all
        internal void MoveUCtoAll(PlayersUC playersUC)
        {
            if (flpFavPlayers.Contains(playersUC))
            {
                flpFavPlayers.Controls.Remove(playersUC);
                flpAllPlayers.Controls.Add(playersUC);

            }
            
        }

        //prebaci iz all u fav
        internal void MoveUCtoFav(PlayersUC playersUC)
        {
            if (flpAllPlayers.Contains(playersUC))
            {
                flpAllPlayers.Controls.Remove(playersUC);
                flpFavPlayers.Controls.Add(playersUC);
                
            }
        }

        //najvise 3 igraca, dodaj zvjezdicu
        internal void CheckSituation(PlayersUC playersUC)
        {
            if (flpFavPlayers.Controls.Count < 3)
            {
                MoveUCtoFav(playersUC);
                playersUC.SetStar();
            }
            else
            {
                if (s.Language == Language.English)
                {
                    MessageBox.Show("There can be a maximum of 3 fav players!"); 
                }
                else
                {
                    MessageBox.Show("Možete odabrati najviše 3 omiljena igrača!");
                }
            }
        }

        //drag and drop
        private void FlpFavPlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void FlpFavPlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayersUC uc = (PlayersUC)e.Data.GetData(typeof(PlayersUC));
            CheckSituation(uc);


        }

        private void FlpAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayersUC uc = (PlayersUC)e.Data.GetData(typeof(PlayersUC));
            flpAllPlayers.Controls.Add(uc);
            uc.RemoveStar();
           

        }

        //spremi i otvori novu formu
        private void btnSavePlayers_Click(object sender, EventArgs e)
        {
            List<StartingEleven> favPlayers = new List<StartingEleven>();
            foreach (PlayersUC c in flpFavPlayers.Controls)
            {
                favPlayers.Add(c.Player);
               
            }

            GetData.WriteInFileList<StartingEleven>(favPlayers, favPlayersFilePath);
            StartSavingProject();
            this.Hide();
            this.FormClosed += FavouritePlayers_FormClosed;
            RankList rl = new RankList();
            rl.ShowDialog();
            Close();

        }

        private void FavouritePlayers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            base.OnClosed(e);
        }

        // spremi slike, otvori save file dialog
        private void StartSavingProject()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveProject(sfd.FileName);
            }
        }

        private void SaveProject(string path)
        {
            try
            {
                File.WriteAllLines(path, GetSaveData());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<string> GetSaveData()
        {
            List<string> lines = new List<string>();

            foreach (PlayersUC uc in flpAllPlayers.Controls)
            {    
                lines.Add($"{uc.Player.Picture}, {uc.Player.ShirtNumber}");
            }
            foreach (PlayersUC uc in flpFavPlayers.Controls)
            {
                lines.Add($"{uc.Player.Picture}, {uc.Player.ShirtNumber}");
            }

            return lines;
        }

      
        //zatvaranje
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
                ClosedByXButtonOrAltF4 = true;
            base.WndProc(ref msg);

        }

        private void FavouritePlayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedByXButtonOrAltF4)
            {
                MyMessageBox mb = new MyMessageBox();
                DialogResult dr = mb.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    mb.Close();
                }
            }
            
        }
    }
}
