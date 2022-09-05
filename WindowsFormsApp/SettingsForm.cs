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
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class SettingsForm : Form
    {
        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string settingsFile = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string settingsFilePath = Path.GetFullPath(settingsFile);

        public static bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;

        Settings set;
        public SettingsForm()
        {
            InitializeComponent();
            this.FormClosing += SettingsForm_FormClosing;
            
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillWithData();
        }

        //napuni s podacima
        private void FillWithData()
        {
            Settings s = GetData.LoadFromFile(settingsFilePath);

            cbChampionship.DataSource = Enum.GetValues(typeof(Championship));
            cbChampionship.DisplayMember = "Value";
            cbChampionship.SelectedItem = s.Championship;
          

            cbLanguage.DataSource = Enum.GetValues(typeof(Language));
            cbLanguage.DisplayMember = "Value";
            cbLanguage.SelectedItem = s.Language;
        }

       
        //spremi promijene i otvori sljedecu formu
        private void btnSave_Click(object sender, EventArgs e)
        {
            //jeste li sigurni, ako stisne da zapisi u file
            set = new Settings((Championship)cbChampionship.SelectedItem, (Language)cbLanguage.SelectedItem);
            MyMessageBox mb = new MyMessageBox();
            DialogResult dr = mb.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GetData.WriteInFile<Settings>(set, settingsFilePath);
                this.Hide();
                FavouriteNationalTeam fnt = new FavouriteNationalTeam();
                fnt.ShowDialog();

            }
            
        }

        //zatvaranje
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedByXButtonOrAltF4)
            {
                MyMessageBox mb = new MyMessageBox();
                DialogResult dr = mb.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
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
