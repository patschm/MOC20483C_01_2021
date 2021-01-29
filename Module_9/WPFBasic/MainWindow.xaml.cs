using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFBasic.Model;

namespace WPFBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel model;
        public MainWindow()
        {
            LoadData();
            InitializeComponent();
            DataContext = model;
        }

        private void LoadData()
        {
            model = new MainViewModel { Color = "White", Name = "Blaat", Date = DateTime.Now };
            var list = new Bogus.Faker<Person>()
                .RuleFor(p => p.Name, pf => pf.Name.FullName())
                .RuleFor(p => p.Age, pf => pf.Random.Int(0, 123))
                .Generate(5)
                .ToList();
            model.People = new ObservableCollection<Person>(list);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person p = new Person { Name = name.Text, Age = 52 };
            model.People.Add(p);
        }
    }
}
