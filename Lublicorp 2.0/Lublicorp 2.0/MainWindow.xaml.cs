using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Lublicorp_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Page CurrentPage
        {
            get => Data.CurrentPage;
            set
            {
                Data.CurrentPage = value;
                Signal();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Data.CurrentPageChanged += Data_CurrentPageChanged;
            DataContext = this;
            CurrentPage = new EditPersonPage();
        }

        private void Data_CurrentPageChanged(object sender, EventArgs e)
        {
            Signal("CurrentPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));

        private void openEditor(object sender, RoutedEventArgs e)
        {
            CurrentPage = new EditPersonPage();

        }

        private void openList(object sender, RoutedEventArgs e)
        {
            CurrentPage = new ListPersonPage();
        }

        private void openTrener(object sender, RoutedEventArgs e)
        {
            CurrentPage = new EditTrenerPage();

        }

        private void openTrenerList(object sender, RoutedEventArgs e)
        {
            CurrentPage = new ListTrenerPage();
        }
    }

}
