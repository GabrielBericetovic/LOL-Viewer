using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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

        public static MainWindow AppWindow; 

        #region connectionstring
        const string connectionString = "server=localhost;uid=root;database=lol";
        #endregion

        private SoundPlayer Player = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();

            AppWindow = this;

            this.Player.SoundLocation = $@"../../Sounds/musik.wav";
            this.Player.PlayLooping();

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

            Roll_Button.IsEnabled = false;
        }

        public void Champ_Select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var uriSource = new Uri($@"images/{Champ_Select.SelectedItem}.png", UriKind.Relative);
            BgImage.Source = (new BitmapImage(uriSource));
            
            var sounds = new Uri($@"../../Sounds/{Champ_Select.SelectedItem}.mp3", UriKind.Relative);
            voice.Source = sounds;
            voice.Play();

            ObservableCollection<Champ> eintrag = new ObservableCollection<Champ>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select * from Champ where C_Name = '{Champ_Select.SelectedItem}'", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Champ c = new Champ((int)reader[0], (int)reader[1], (string)reader[2]);
                        eintrag.Add(c);

                        if (c.CR_ID == 1)
                        {
                            var uri2Source = new Uri($@"images/Top Laner.png", UriKind.Relative);
                            Roll_IMG.Source = new BitmapImage(uri2Source);
                        }
                        else if (c.CR_ID == 2)
                        {
                                var uri2Source = new Uri($@"images/Jungler.png", UriKind.Relative);
                                Roll_IMG.Source = new BitmapImage(uri2Source);
                        }
                        else if (c.CR_ID == 3)
                        {
                            var uri2Source = new Uri($@"images/Mid Laner.png", UriKind.Relative);
                            Roll_IMG.Source = new BitmapImage(uri2Source);
                        }
                        else if (c.CR_ID == 4)
                        {
                            var uri2Source = new Uri($@"images/ADC.png", UriKind.Relative);
                            Roll_IMG.Source = new BitmapImage(uri2Source);
                        }
                        else if (c.CR_ID == 5)
                        {
                            var uri2Source = new Uri($@"images/Support.png", UriKind.Relative);
                            Roll_IMG.Source = new BitmapImage(uri2Source);
                        }

                        AttackInfo.Text = "";
                    }
                }
            }
        }

        private void Q_Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select Champ.C_ID, faehigkeiten.Q, faehigkeiten.W, faehigkeiten.E, Faehigkeiten.r from Champ, faehigkeiten where C_Name = '{Champ_Select.SelectedItem}' && C_ID = F_ID;", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faehigkeiten c = new Faehigkeiten((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);


                        AttackInfo.Text = c.Q;
                    }
                }
            }
        }

        private void W_Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select Champ.C_ID, faehigkeiten.Q, faehigkeiten.W, faehigkeiten.E, Faehigkeiten.r from Champ, faehigkeiten where C_Name = '{Champ_Select.SelectedItem}' && C_ID = F_ID;", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faehigkeiten c = new Faehigkeiten((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);

                        AttackInfo.Text = c.W;
                    }
                }
            }
        }

        private void E_Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select Champ.C_ID, faehigkeiten.Q, faehigkeiten.W, faehigkeiten.E, Faehigkeiten.r from Champ, faehigkeiten where C_Name = '{Champ_Select.SelectedItem}' && C_ID = F_ID;", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faehigkeiten c = new Faehigkeiten((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);

                        AttackInfo.Text = c.E;
                    }
                }
            }
        }

        private void R_Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select Champ.C_ID, faehigkeiten.Q, faehigkeiten.W, faehigkeiten.E, Faehigkeiten.r from Champ, faehigkeiten where C_Name = '{Champ_Select.SelectedItem}' && C_ID = F_ID;", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faehigkeiten c = new Faehigkeiten((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);
             
                        AttackInfo.Text = c.R;
                    }
                }
            }
         }

        private void playbutton_Click(object sender, RoutedEventArgs e)
        {
            var sounds = new Uri($@"../../Sounds/{Champ_Select.SelectedItem}.mp3", UriKind.Relative);
            voice.Source = sounds;
            voice.Play();
        }
    }
}
