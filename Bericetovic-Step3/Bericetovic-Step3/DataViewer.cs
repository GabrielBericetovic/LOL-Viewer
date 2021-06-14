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

        public ObservableCollection<Faehigkeiten> faehigkeitens { get; set; } = new ObservableCollection<Faehigkeiten>() { new Faehigkeiten(1, "h","g","d","s")};

        public ObservableCollection<Rolle> Rolles { get; set; } = new ObservableCollection<Rolle>();
    }
}
