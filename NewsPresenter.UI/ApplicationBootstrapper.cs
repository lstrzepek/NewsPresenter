using Microsoft.Practices.Prism.MefExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPresenter.UI
{
    class ApplicationBootstrapper : MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return new MainWindow();
        }
    }
}
