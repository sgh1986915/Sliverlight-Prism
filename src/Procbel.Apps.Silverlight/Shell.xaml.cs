using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight
{
    //public partial class Shell : UserControl
    //{
    //    public Shell()
    //    {
    //        InitializeComponent();
    //    }
    //}

    [Export(typeof(Shell))]
    public partial class Shell : UserControl, IPartImportsSatisfiedNotification
    {
        [Import]
        public AtomicModuleLoader ModuleLoader { private get; set; }

        [Import]
        [CLSCompliant(false)]
        public IApplicationViewModel ViewModel
        {
            private get
            {
                return this.DataContext as IApplicationViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        [Import]
        public ApplicationNavigator ApplicationNavigator;

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            LoadModulesInBackground();
            NavigateToInicioModule();
        }

        private void NavigateToInicioModule()
        {
            //this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ActivitiesModule);
            this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.InicioModule);
            //this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.CompaniesModule);
            //this.ViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ActivitiesModule);
        }

        private void LoadModulesInBackground()
        {
            //JLSF
            // waiting Telerik Issue with loading Modules after Initial Loading
            Queue<string> urls = new Queue<string>(new string[]
                                               {
                                                  
                                                   ModuleNames.InicioModule
                                                  ,ModuleNames.ActivitiesModule
                                                  ,ModuleNames.CompaniesModule
                                                  ,ModuleNames.ContactsModule
                                                  ,ModuleNames.VentasModule
                                                  ,ModuleNames.CalidadModule
                                                  ,ModuleNames.IncidenciasModule
                                                  ,ModuleNames.OpportunitiesModule
                                                  
                                               });

            foreach (var url in urls)
            {
                ModuleLoader.AddLoadOperation(url);
            }

            ModuleLoader.ProcessQueueAsync();
        }
    }
}
