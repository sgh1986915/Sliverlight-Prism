using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class ApplicationNavigator
    {
        [Import]
        public AtomicModuleLoader ModuleLoader { private get; set; }

        [Import]
        public IModuleManager ModuleManager { private get; set; }

        [Import]
        public IRegionManager RegionManager { private get; set; }

        [Import]
        public IModuleCatalog ModuleCatalog { private get; set; }

        private IDictionary<string, string> ModuleDefaultViewNames = new Dictionary<string, string>()
        {
            { ModuleNames.InicioModule, "InicioView" },
            { ModuleNames.VentasModule, "VentasView" },
            { ModuleNames.DashboardModule, "DashboardView" },
            { ModuleNames.CompaniesModule, "CompaniesView" },
            { ModuleNames.ActivitiesModule, "ActivitiesView" },
            { ModuleNames.ContactsModule, "ContactsView" },
            { ModuleNames.OpportunitiesModule, "OpportunitiesView" },
            { ModuleNames.CalidadModule, "CalidadView" },
            { ModuleNames.IncidenciasModule, "IncidenciasView"}
        };

        private string currentUri;
        public void NavigateToModule(string uri, Action<int> progressChangedCallback = null, Action completedCallback = null)
        {
            this.currentUri = uri;

            if (this.ModuleLoader.IsModuleLoaded(uri))
            {
                this.NavigateToDefaultRegion(uri);
                completedCallback();
            }
            else
            {
                EventHandler completed = null;
                EventHandler<ProgressChangedEventArgs> progressChanged = null;
                completed = (s, e) =>
                {
                    this.ModuleLoader.PriorityOperationCompleted -= completed;
                    this.NavigateToDefaultRegion(this.currentUri);
                    completedCallback();
                };

                progressChanged = (s, e) =>
                {
                    progressChangedCallback(e.ProgressPercentage);
                };

                this.ModuleLoader.PriorityOperationCompleted += completed;
                this.ModuleLoader.PriorityOperationProgressChanged += progressChanged;

                this.ModuleLoader.ProcessWithPriority(uri);
            }
        }

        private void NavigateToDefaultRegion(string moduleName)
        {
            if (this.ModuleDefaultViewNames.ContainsKey(moduleName))
            {
                var viewName = this.ModuleDefaultViewNames[moduleName];
                this.RegionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
            }
            else
            {
                throw new InvalidOperationException("Cannot navigate to unknown module name.");
            }
        }
    }
}
