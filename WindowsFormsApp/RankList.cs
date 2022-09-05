using DataLayer;
using DataLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RankList : Form
    {
        //konstante
        private const string dataApi = "Api";
        private const string wUrl = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string mUrl = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const string Ycard = "yellow-card";
        private const string Gpenalty = "goal-penalty";
        private const string Goal = "goal";
        private const string Gown = "goal-own";

        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        private static readonly string favTeamFile = Path.Combine(dir, @"..\..\..\favTeam.txt");
        private static readonly string favTeamFilePath = Path.GetFullPath(favTeamFile);

        private static readonly string wMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string wMatchesFilePath = Path.GetFullPath(wMatchesFile);

        private static readonly string mMatchesFile = Path.Combine(dir, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string mMatchesFilePath = Path.GetFullPath(mMatchesFile);

        public static bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;

        readonly int pomakY = 20;
        readonly int pomakX = 230;

        List<StartingEleven> players = new List<StartingEleven>();
        PrintDocument doc;
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

        public RankList()
        {
            InitializeComponent();
            doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            doc.EndPrint += Doc_EndPrint;
            this.FormClosing += RankList_FormClosing;
               
        }

       
        private void RankList_Load(object sender, EventArgs e)
        {
            FillWithData();
        }

        // napuni s podacima
        private async void FillWithData()
        {
             s = GetData.LoadFromFile(settingsFilePath);
            FavouriteTeam ft = GetData.LoadFromFileFavTeam(favTeamFilePath);
            progressBar.Value = GetData.IncreasePercentage(Percentage, 10);

            try
            {
                if (GetData.ReadConfig() == dataApi)
                {
                    switch (s.Championship)
                    {
                        case Championship.Women2019:
                            var wResults = await GetData.FromUrlAsync<Match>(wUrl + ft.Code);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            FillAttendance(ft, wResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            Fill(ft, wResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            break;
                        case Championship.Men2018:
                            var mResults = await GetData.FromUrlAsync<Match>(mUrl + ft.Code);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            FillAttendance(ft, mResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            Fill(ft, mResults);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
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
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            FillAttendance(ft, resultsW);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            Fill(ft, resultsW);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            break;
                        case Championship.Men2018:
                            var resultsM = GetData.ReadFromFile<Match>(mMatchesFilePath);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            FillAttendance(ft, resultsM);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
                            Fill(ft, resultsM);
                            progressBar.Value = GetData.IncreasePercentage(Percentage, 30);
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

        private void FillAttendance(FavouriteTeam ft, List<Match> results)
        {
            results.Sort();
           
            foreach (var item in results)
            {

                if (item.HomeTeam.Country.ToUpper() == ft.Country || item.AwayTeam.Country.ToUpper() == ft.Country)
                {
                    lbAttendance.Items.Add(item.Location + " " + item.Attendance + " " + item.HomeTeam.Country + "-" + item.AwayTeam.Country);
                    
                }
            }

        }

        private void Fill(FavouriteTeam ft, List<Match> results)
        {
            foreach (var item in results)
            {
                if (ft.Country == item.HomeTeam.Country.ToUpper())
                {
                    players = item.HomeTeamStatistics.StartingEleven;
                    item.HomeTeamStatistics.Substitutes.ForEach(sub => players.Add(sub));

                    break;

                }
                else if (ft.Country == item.AwayTeam.Country.ToUpper())
                {
                    players = item.AwayTeamStatistics.StartingEleven;
                    item.AwayTeamStatistics.Substitutes.ForEach(sub => players.Add(sub));

                    break;

                }
            }

            foreach (var item in results)
            {
                foreach (var i in item.HomeTeamEvents)
                {
                    foreach (var p in players)
                    {
                        CheckGoalsAndYellowCards(i, p);
                    }
                }
                foreach (var j in item.AwayTeamEvents)
                {
                    foreach (var p in players)
                    {

                        CheckGoalsAndYellowCards(j, p);
                    }
                }
            }

            Sort();
        }

        //sortiraj dohvacene podatke
        private void Sort()
        {
            players.Sort((x, y) => -x.NbrOfGoals.CompareTo(y.NbrOfGoals));
            foreach (var pl in players)
            {
                lbGoals.Items.Add(pl.Name + "   " + pl.NbrOfGoals);
            }

            players.Sort((x, y) => -x.NbrOfYellowCards.CompareTo(y.NbrOfYellowCards));
            foreach (var pl in players)
            {
                lbYellowCards.Items.Add(pl.Name + "   " + pl.NbrOfYellowCards);
            }
        }

        private static void CheckGoalsAndYellowCards(TeamEvent i, StartingEleven p)
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

        //printanje
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog.Document = doc;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
           
        }

        private void Doc_EndPrint(object sender, PrintEventArgs e)
        {
            if (s.Language == Language.English)
            {
                MessageBox.Show("Done"); 
            }
            else
            {
                MessageBox.Show("Gotovo");
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics page = e.Graphics;
            int x = 60, y = 20; // x su kolone, y redovi

            Write(page, x, y, lblGoals, lbGoals);
            x += pomakX;

            Write(page, x, y, lblYellowCards, lbYellowCards);
            x += pomakX;

            Write(page, x, y, lblAttendance, lbAttendance);

        }

        private void Write(Graphics page, int x, int y, System.Windows.Forms.Label l, System.Windows.Forms.ListBox lb)
        {
            page.DrawString(l.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(x, y));
            y += pomakY;
            foreach (string str in lb.Items)
            {
                page.DrawString(str, new Font("Arial", 8), Brushes.Black, new Point(x, y));
                y += pomakY;
            }


        }

        //otvori formu postavke
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            this.Hide();
            sf.ShowDialog();
        }


        //zatvaranje
        private void RankList_FormClosing(object sender, FormClosingEventArgs e)
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


        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
                ClosedByXButtonOrAltF4 = true;
            base.WndProc(ref msg);
        }


    }

}


