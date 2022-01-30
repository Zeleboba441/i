using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lublicorp_2._0
{
    
        public class EditTrenerViewModel : INotifyPropertyChanged
    {
        private Trener trener;

        public Trener Trener
        {
            get => trener;
            set
            {
                trener = value;
                Signal();
            }
        }
        public CustomCommand AddTrener { get; set; }
        public CustomCommand ListTrener { get; set; }

        public EditTrenerViewModel(Trener trener)
        {
            Trener = trener;
            AddTrener = new CustomCommand(() =>
            {
                if (!Data.Treners.Contains(Trener))
                    Data.Treners.Add(Trener);
                Trener = new Trener();
            }, () => true);

            ListTrener = new CustomCommand(() =>
            {
                Data.CurrentPage = new ListTrenerPage();
            }, () => true);
        }

        public EditTrenerViewModel() : this(new Trener())
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
    }
}


