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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AnimateEllipse();
        }

        private void AnimateEllipse()
        {
            var animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;
            animation.Duration = new Duration(TimeSpan.FromSeconds(5));
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(20));
            myEllipse.BeginAnimation(Canvas.LeftProperty, animation);
        }
    }
}
