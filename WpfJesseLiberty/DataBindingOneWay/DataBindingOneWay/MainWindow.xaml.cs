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

namespace DataBindingTwoWay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee _employee;
        public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //DataContext = Employee.GetEmployee();
            _employee = new Employee()
            {
                Name = "Joe",
                Title = "QA"
            };
            DataContext = _employee;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var exception = args.ExceptionObject as Exception;
            var terminatingMessage = args.IsTerminating ? " The application is terminating." : string.Empty;
            var exceptionMessage = exception.Message ?? "An unmanaged exception occured.";
            var message = string.Concat(exceptionMessage, terminatingMessage);
            MessageBox.Show(exception + Environment.NewLine + message);
        }


        private void btnChange_Click_1(object sender, RoutedEventArgs e)
        {
            _employee.Name = "Jesse";
            _employee.Title = "Evangelist";
        }
    }
}
