using System;
using System.Collections.Generic;
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

namespace Lublicorp_2._0
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : Page
    {
        public EditPersonPage()
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel();
        }
        public EditPersonPage(Person selectedPerson)
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel(selectedPerson);
        }

        
    }
}
