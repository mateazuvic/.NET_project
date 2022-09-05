using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Models;
using DataLayer;
using System.Resources;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApp
{
    public partial class PlayersUC : UserControl
    {

        public StartingEleven Player { get; private set; }
        public PlayersUC(StartingEleven player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
            ContextMenuStrip = contextMenuUC;
        }

       


        //podatke stavi u labele
        private void SetData(StartingEleven player)
        {
            lblPlayersName.Text = player.Name;
            lblPlayersNbr.Text = player.ShirtNumber.ToString();
            lblPlayersPosition.Text = player.Position.ToString();
            if (player.Captain == true)
            {
                lblCaptain.Text = "CAPTAIN";
            }
            else
            {
                lblCaptain.Text = "";
            }

            System.Drawing.Image img;
            if (String.IsNullOrEmpty(player.Picture))
            {
               
                pbImage.Image = Properties.Resources.football_player_1426973_1208513;
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                using (var bmpTemp = new Bitmap(player.Picture))
                {
                    img = new Bitmap(bmpTemp);
                }
                pbImage.Image = new Bitmap(img);
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
           
            
        }
       
        //kontekstni meni
        private void btnContextMoveToAll_Click(object sender, EventArgs e)
        {
            FavouritePlayers fp = this.ParentForm as FavouritePlayers;
            fp.MoveUCtoAll(this);
            pbStar.Visible = false;
            
        }

        private void btnContextMoveToFav_Click(object sender, EventArgs e)
        {
            FavouritePlayers fp = this.ParentForm as FavouritePlayers;
            fp.CheckSituation(this);
            

        }

        internal void SetStar()
        {
            pbStar.Visible = true;
        }

        internal void RemoveStar()
        {
            pbStar.Visible = false;
        }

        private void PlayersUC_MouseDown(object sender, MouseEventArgs e)
        {
           
            PlayersUC uc = (PlayersUC)sender;
            uc.PointToScreen(new Point(e.X, e.Y));
            uc.DoDragDrop(uc, DragDropEffects.Copy);
           
           
        }

        //dodaj sliku igraču
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = ofd.FileName;
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                Player.Picture = ofd.FileName;
                
               
            }
        }

        
    }
}
