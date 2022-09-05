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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WindowsFormsApp
{
    public partial class MyMessageBox : Form
    {
       
        public MyMessageBox()
        {
            InitializeComponent();
            
        }

        

        private void btnYes_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
 
        }


        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //enter i escape tipke
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        




    }
}
