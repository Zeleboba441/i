using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lublicorp_2._0
{
     static class Data
    {
        public static ObservableCollection<Person> Persons = new ObservableCollection<Person>();
        public static ObservableCollection<Trener> Treners = new ObservableCollection<Trener>();
        private static Page currentPage;
        public static event EventHandler CurrentPageChanged;
        public static Page CurrentPage
        {
            get => currentPage;
            internal set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(CurrentPage, new EventArgs());
            }

        }
    }
}
