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

namespace Bericetovic_Step3
{
    /// <summary>
    /// Interaktionslogik für Rolle_Info.xaml
    /// </summary>
    public partial class Rolle_Info : Window
    {
        public Rolle_Info()
        {
            InitializeComponent();
        }

        private void Infoback_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
