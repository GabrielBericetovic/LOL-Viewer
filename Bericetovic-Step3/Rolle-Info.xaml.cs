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
using System.Windows.Shapes;

namespace Bericetovic_Step3
{
    /// <summary>
    /// Interaktionslogik für Rolle_Info.xaml
    /// </summary>
    public partial class Rolle_Info : Window
    {

        #region connectionstring
        const string connectionString = "server=localhost;uid=root;database=lol";
        #endregion

        public Rolle_Info()
        {
            InitializeComponent();

            ObservableCollection<Rolle> eintrag = new ObservableCollection<Rolle>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // connect
                connection.Open();

                // command
                MySqlCommand cmd = new MySqlCommand($@"select Champ.CR_ID, Rolle.R_Name, Rolle.Lane, Rolle.R_Info from Champ, Rolle where C_Name = '{Bericetovic_Step3.MainWindow.AppWindow.Champ_Select.SelectedItem}' && CR_ID = R_ID", connection);

                // read result
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rolle c = new Rolle((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3]);
                        eintrag.Add(c);

                        var uri2Source = new Uri($@"images/{c.R_Name}.png", UriKind.Relative);
                        Rolle_Image_Icon.Source = new BitmapImage(uri2Source);


                        Rolle_Info_Text.Text = c.R_Info;
                    }
                }

                var a = (DataViewer)Rolle_Text.DataContext;
                foreach (var item in eintrag)
                {
                    a.Rolles.Add(item);
                }
            }
        }

        private void Infoback_Click(object sender, RoutedEventArgs e)
        {
            Bericetovic_Step3.MainWindow.AppWindow.Roll_Button.IsEnabled = true;

            this.Close();
        }
    }
}

