using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lublicorp_2._0
{
    internal class ListTrenerViewModel : INotifyPropertyChanged
    {
        private Trener selectedTrener;

        public CustomCommandTarget RemoveTrener { get; set; }

        public CustomCommand EditTrener { get; set; }
        public Trener SelectedTrener
        {
            get => selectedTrener;
            set
            {
                selectedTrener = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTrener"));
            }
        }
        public ObservableCollection<Trener> Treners => Data.Treners;

        public ListTrenerViewModel()
        {

            RemoveTrener = new CustomCommandTarget((trener) =>
            {
                var removing = (Trener)trener;
                Treners.Remove(removing);
            });
            EditTrener = new CustomCommand(
                () =>
                {
                    Data.CurrentPage = new EditTrenerPage(SelectedTrener);
                }, () => SelectedTrener != null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}