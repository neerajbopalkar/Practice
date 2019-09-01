using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Event;

namespace WpfApplication1.ViewModels
{
    public class ViewAViewModel : BindableBase //INotifyPropertyChanged
    {

        private string _firstName ="neeraj";

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                SetProperty(ref _firstName, value);
                MyCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime? _lastUpdated;
        private IEventAggregator _eventAggregator;

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { 
            SetProperty(ref _lastUpdated, value);
            }
        }
        

        public DelegateCommand MyCommand{get;set;}

        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            MyCommand = new DelegateCommand(Execute, CanExecute);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
            _eventAggregator.GetEvent<UpdateEvent>().Publish(LastUpdated.ToString());
        }
        

        //private int _height;

        //public int Height
        //{
        //    get { return _height; }
        //    set
        //    {
        //        _height = value;
        //        OnPropertyChanged("Height");
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged(string propName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //    }
        //}

        private bool CanExecute() 
        {
            return !string.IsNullOrWhiteSpace(FirstName);
        }
    }
}
