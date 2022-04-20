using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BowlingApp.ViewModels;

namespace BowlingApp
{

    // Bootstrapper class from the Caliburn Micro Package will set our program to run the 'MainViewModel' at startup
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
