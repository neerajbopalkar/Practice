using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Unity;
using WpfApplication1.Views;
using Microsoft.Practices.Unity;
using System.Windows;

namespace WpfApplication1
{
    public class BootStrapper: UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType(typeof(object), typeof(ViewA), "viewA");
            Container.RegisterType(typeof(object), typeof(ViewB), "viewB");
        }
    }
}
