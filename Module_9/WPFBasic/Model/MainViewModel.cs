using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WPFBasic.Model
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public DateTime Date { get; set; }
        public string Color { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
