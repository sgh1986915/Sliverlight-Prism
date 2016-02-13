using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using System;
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

namespace Procbel.Apps.Silverlight.Modules.Inicio.ViewModels
{
        [Export]
    public class InicioViewModel : NotificationObject, IPartImportsSatisfiedNotification
    {
            [Import]
            public IRegionManager RegionManager { get; set; }

            public void OnImportsSatisfied()
            {
              
            }

    }
}
