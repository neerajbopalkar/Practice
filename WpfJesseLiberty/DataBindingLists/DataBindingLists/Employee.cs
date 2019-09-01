using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingLists
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
                new Employee(){ Name = "AAA", Title="111"  },
                new Employee(){ Name = "BBB", Title="222"  },
                new Employee(){ Name = "CCC", Title="333"  },
                new Employee(){ Name = "DDD", Title="444"  },
                new Employee(){ Name = "EEE", Title="555"  },
                new Employee(){ Name = "FFF", Title="666"  },
                new Employee(){ Name = "GGG", Title="777"  }
            };

        }
    }

}
