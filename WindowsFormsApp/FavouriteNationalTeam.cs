using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FavouriteNationalTeam : Form
    {
        private const string dataApi = "Api";
        
        private const string wUrl = "http://worldcup.sfg.io/teams/";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/teams";

        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string wTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\teams.json");
        private static readonly string wTeamFilePath = Path.GetFullPath(wTeamFile);

        private static readonly string mTeamFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\teams.json");
        private static readonly string mTeamFilePath = Path.GetFullPath(mTeamFile);

        private static readonly string favTeamFile = Path.Combine(dir, @"..\..\..\favTeam.txt");
        private static readonly string favTeamFilePath = Path.GetFullPath(favTeamFile);

        public bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;

        private const string HR = "hr";
        private const string EN = "en";

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

        public FavouriteNationalTeam()
        {
            InitializeComponent();
            this.FormClosing += FavouriteNationalTeam_FormClosing;
        }


        private void FavouriteNationalTeam_Load(object sender, EventArgs e)
        {
            SetLanguage();
            FillWithData();
            
        }

        //postavi jezik
        private void SetLanguage()
        {
            Settings s = GetData.LoadFromFile(settingsFilePath);
            if (s.Language == Language.English)
            {
                GetData.SetCulture(EN);
            }
            else
            {
                GetData.SetCulture(HR);
            }

            this.Controls.Clear();
            InitializeComponent();
        }

        
        //napuni s podacima
        private async void FillWithData()
        { 
            // procitaj konfiguracijsku dat. i vidi kojim nacinom da dohvatis podatke pa vidi koje prventsvo je odabrano
            Settings s = GetData.LoadFromFile(settingsFilePath);
            progressBar.Value = GetData.IncreasePercentage(Percentage, 10);

            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        
                        case Championship.Women2019:
                            var wResults = await GetData.FromUrlAsync<TeamResults>(wUrl);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            Fill(wResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            break;
                        case Championship.Men2018:
                            var mResults = await GetData.FromUrlAsync<TeamResults>(mUrl);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            Fill(mResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
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
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            Fill(teamsW);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            break;
                        case Championship.Men2018:
                            var teamsM = GetData.ReadFromFile<TeamResults>(mTeamFilePath);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            Fill(teamsM);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 45);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "GREŠKA6!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Fill(List<TeamResults> results)
        {
           
            results.ForEach(r => cbChooseTeam.Items.Add(r));
            if (File.Exists(favTeamFilePath))
            {
                //nek je Fav team selektiran ako postoji, tj ako je vec odabran
                cbChooseTeam.SelectedIndex = GetData.LoadFromFileFavTeam(favTeamFilePath).SelectedIndex;
            }
           
            
        }

        //spremi i otvori novu formu
        private void btnSaveFavTeam_Click(object sender, EventArgs e)
        {

            FavouriteTeam ft = new FavouriteTeam(cbChooseTeam.SelectedItem.ToString(), cbChooseTeam.SelectedIndex);
             
            GetData.WriteInFile<FavouriteTeam>(ft, favTeamFilePath);

            this.Hide();
            this.FormClosed += FavouriteNationalTeam_FormClosed;
            FavouritePlayers fp = new FavouritePlayers();
            fp.ShowDialog();
        }

        private void FavouriteNationalTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            base.OnClosed(e);
            

        }

        //zatvaranje
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
                ClosedByXButtonOrAltF4 = true;
            base.WndProc(ref msg);

        }

        private void FavouriteNationalTeam_FormClosing(object sender, FormClosingEventArgs e)
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
