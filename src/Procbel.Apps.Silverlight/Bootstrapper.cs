using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
//ojo Mefextensions tambien tiene Modularity (para funcion createModuleCatalog)
using Modularity = Microsoft.Practices.Prism.Modularity;

namespace Procbel.Apps.Silverlight
{
    [CLSCompliant(false)]
    public class Bootstrapper : MefBootstrapper
    {

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
        }

        protected override DependencyObject CreateShell()
        {
            //Shell shell = new Shell();
            //Application.Current.RootVisual = shell;
            //return shell;
            return new Shell();

        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = this.Shell as UIElement;
        }

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing(typeof(Procbel.Apps.Silverlight.Infrastructure.Behaviors.AutoPopulateExportedViewsBehavior).Name, typeof(AutoPopulateExportedViewsBehavior));
            return factory;
        }


        /// <summary>
        /// Creates the <see cref="IModuleCatalog"/> used by Prism.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
            // return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/CRM;component/ModulesCatalog.xaml", UriKind.Relative));
            return Modularity.ModuleCatalog.CreateFromXaml(new Uri("/Procbel.Apps.Silverlight;component/ModulesCatalog.xaml", UriKind.Relative));
        }
    }
}
