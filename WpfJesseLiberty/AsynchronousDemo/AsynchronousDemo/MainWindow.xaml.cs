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

namespace AsynchronousDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _sum;
        public MainWindow()
        {
            InitializeComponent();
            ComputeMethodAsync();
        }

        
        private async void ComputeMethodAsync()
        {
            for (; ; )
            {
                _sum = 0.0;
                Message.Text = "Computing..";
                await LongMethod();
                Message.Text = "Sum = " + _sum;
                await LongMethod();
                Message.Text = "Sum = " + _sum;
                await LongMethod();
                Message.Text = "Sum = " + _sum;
                await LongMethod();
                Message.Text = "Sum = " + _sum;

            }
        }

        private Task LongMethod()
        {
            return Task.Run(() =>
                {
                    for (int i = 1; i < 200000000; i++)
                    {
                        _sum += Math.Sqrt(i);
                    }
                });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");

        }
    }
}
