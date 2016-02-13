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
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;

namespace Procbel.Apps.Silverlight.Modules.Opportunities.ViewModels
{
    [Export]
    public class OpportunitiesViewModel : NotificationObject
    {
        public OpportunitiesViewModel()
        {

        }
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }



    }
}
