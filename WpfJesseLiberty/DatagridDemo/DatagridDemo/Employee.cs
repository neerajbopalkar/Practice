using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatagridDemo
{
    public class Employee : INotifyPropertyChanged
    {

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool WasReelected
        {
            get
            {
                return _wasReelected;
            }
            set
            {
                _wasReelected = value;
                OnPropertyChanged();
            }
        }

        public Party Affiliation
        {
            get
            {
                return _affiliation;
            }
            set
            {
                _affiliation = value;
                OnPropertyChanged();
            }
        }

        public static Employee GetEmployee()
        {
            return new Employee()
            {
                Name = "neeraj",
                Title = "Developer"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _title;
        private bool _wasReelected;
        private Party _affiliation;
        //helper method for property changes

        private void OnPropertyChanged(
            [CallerMemberName]
            string caller = "")
        {
            //If there are 1+ subscribers to event, raise an event
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>()
            {
                new Employee(){ Name = "Washington", Title="President 1", WasReelected = true, Affiliation = Party.Independent  },
                new Employee(){ Name = "Eisenhower", Title="President 34",WasReelected = true, Affiliation = Party.DemocratRepublican  },
                new Employee(){ Name = "Jefferson", Title="President 3"  ,WasReelected = false, Affiliation = Party.Federelist},
                new Employee(){ Name = "Madison", Title="President 4",WasReelected = false, Affiliation = Party.Independent  }
                
            };

        }
    }

    public enum Party
    {
        Independent,
        Federelist,
        DemocratRepublican
    }
}
