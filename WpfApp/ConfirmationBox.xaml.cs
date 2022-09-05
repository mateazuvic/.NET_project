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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ConfirmationBox.xaml
    /// </summary>
    public partial class ConfirmationBox : Window
    {
        
        public ConfirmationBox()
        {
            InitializeComponent();
        }

        //enter i escape
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConfirm_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitBox.Close();
              
        }

        
    }
}
