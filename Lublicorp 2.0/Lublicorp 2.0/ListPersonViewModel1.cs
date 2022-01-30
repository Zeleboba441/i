using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lublicorp_2._0
{
    internal class ListPersonViewModel: INotifyPropertyChanged
        {
            private Person selectedPerson;

            public CustomCommandTarget RemovePerson { get; set; }

            public CustomCommand EditPerson { get; set; }
            public Person SelectedPerson
            {
                get => selectedPerson;
                set
                {
                    selectedPerson = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedPerson"));
                }
            }
            public ObservableCollection<Person> Persons => Data.Persons;

            public ListPersonViewModel()
            {

                RemovePerson = new CustomCommandTarget((person) =>
                {
                    var removing = (Person)person;
                    Persons.Remove(removing);
                });
                EditPerson = new CustomCommand(
                    () =>
                    {
                        Data.CurrentPage = new EditPersonPage(SelectedPerson);
                    }, () => SelectedPerson != null);
            }

            public event PropertyChangedEventHandler PropertyChanged;
        
    }
}