using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bericetovic_Step3
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Champ> eintrag = new ObservableCollection<Champ>();
           /** using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand("select * from Champ", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Champ c = new Champ((int)reader[0], (int)reader[1], (string)reader[2]);
                        eintrag.Add(c);
                    }
                }
            }**/
            var a = (DataViewer)Rolle_Image.DataContext;
            a.Champs = eintrag;
        }

        private void Roll_Button_Click(object sender, RoutedEventArgs e)
        {
            new Rolle_Info().Show();
        }
    }
}
