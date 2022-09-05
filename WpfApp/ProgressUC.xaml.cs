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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProgressUC.xaml
    /// </summary>
    public partial class ProgressUC : UserControl
    {
        public int Percentage
        {
            get => (int)progressBar.Value;
            set
            {
                if (value < 0 || value > 100)
                {
                    return;
                }

                progressBar.Value = (int)value;
                
            }
        }

        public ProgressUC()
        {
            InitializeComponent();
        }

       


    }
}
