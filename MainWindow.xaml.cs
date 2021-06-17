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
        #region connectionstring
        const string connectionString = "server=localhost;uid=root;database=lol";
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Champ> eintrag = new ObservableCollection<Champ>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

                var a = (DataViewer)Rolle_Image.DataContext;
                foreach (var item in eintrag)
                {
                    a.Champs.Add(item);
                }
            }

        }

        private void Roll_Button_Click(object sender, RoutedEventArgs e)
        {
            new Rolle_Info().Show();
        }

        private void ChampList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var uri2Source = new Uri($@"images/{ChampList.SelectedItem}.png", UriKind.Relative);
            BgImage.Source = (new BitmapImage(uri2Source));

        }

        private void Q_Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Faehigkeiten> eintrag = new ObservableCollection<Faehigkeiten>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand("select * from Faehigkeiten", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faehigkeiten c = new Faehigkeiten((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);
                        eintrag.Add(c);


                        AttackInfo.Content = c.Q;
                    }
                }

                var a = (DataViewer)Rolle_Image.DataContext;
                foreach (var item in eintrag)
                {
                    a.faehigkeitens.Add(item);

                }


                
            }
        }

        private void W_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void R_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
