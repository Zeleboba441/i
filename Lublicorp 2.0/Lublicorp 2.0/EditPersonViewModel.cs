using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lublicorp_2._0
{
    public class EditPersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        public Person Person
        {
            get => person;
            set
            {
                person = value;
                Signal();
            }
        }
        public CustomCommand AddPerson { get; set; }
        public CustomCommand ListPerson { get; set; }

        public EditPersonViewModel(Person person)
        {
            Person = person;
            AddPerson = new CustomCommand(() =>
            {
                if (!Data.Persons.Contains(Person))
                    Data.Persons.Add(Person);
                Person= new Person();
            }, () => true);

            ListPerson = new CustomCommand(() =>
            {
                Data.CurrentPage = new ListPersonPage();
            }, () => true);
        }

        public EditPersonViewModel() : this(new Person())
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
    }
}
