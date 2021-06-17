using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bericetovic_Step3
{
    class DataViewer
    {
        public ObservableCollection<Champ> Champs { get; set; } = new ObservableCollection<Champ>();
        public Champ SelectedChamp { get; set; }

        public ObservableCollection<Faehigkeiten> faehigkeitens { get; set; } = new ObservableCollection<Faehigkeiten>();

        public ObservableCollection<Rolle> Rolles { get; set; } = new ObservableCollection<Rolle>();
    }
}
