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
    public partial class InitialSettings : Form
    {
       
        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string file = Path.Combine(dir, @"..\..\..\settings.txt");
        private static readonly string filePath = Path.GetFullPath(file);


        public static bool ClosedByXButtonOrAltF4 { get; private set; }
        private const int SC_CLOSE = 0xF060;
        private const int WM_SYSCOMMAND = 0x0112;


        public InitialSettings()
        {
            
            InitializeComponent();
            LoadSettings();
            this.FormClosing += InitialSettings_FormClosing;
        
        }


        private void InitialSettings_Load(object sender, EventArgs e)
        {
            FillWithData();
        }

        //napuni s podacima (iz enuma)
        private void FillWithData()
        {

            cbChooseChampionship.DataSource = Enum.GetValues(typeof(Championship));
            cbChooseChampionship.DisplayMember = "Value";

            cbChooseLanguage.DataSource = Enum.GetValues(typeof(Language));
            cbChooseLanguage.DisplayMember = "Value";
        }

        private void LoadSettings()
        {

            if (File.Exists(filePath))
            {
                this.FormClosed += InitialSettings_FormClosed;
                FavouriteNationalTeam fnt = new FavouriteNationalTeam();
                Close();
                fnt.ShowDialog();

            }
        }

       
        //spremi i otvori novu formu
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Settings set = new Settings((Championship)cbChooseChampionship.SelectedItem, (Language)cbChooseLanguage.SelectedItem);

            GetData.WriteInFile<Settings>(set, filePath);


            this.Hide();
            this.FormClosed += InitialSettings_FormClosed;
            FavouriteNationalTeam fnt = new FavouriteNationalTeam();
            fnt.ShowDialog();
            Close();
        }

        private void InitialSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();

        }


        private void InitialSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
           
             MyMessageBox mb = new MyMessageBox();
             DialogResult dr = mb.ShowDialog();
             if (dr == DialogResult.Cancel)
             {
                  e.Cancel = true;
                  mb.Close();
                
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
