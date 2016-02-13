using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Imaging.Tools;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    public partial class CompanyImageEditToolsContainerView : UserControl, IToolSettingsContainer
    {
        private Action applyCallback;
        private Action cancelCallback;
        public CompanyImageEditToolsContainerView()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (this.applyCallback != null)
            {
                this.CallApplyCallback();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.cancelCallback != null)
            {
                this.CallCancelCallback();
            }
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }

        public void Show(Telerik.Windows.Media.Imaging.Tools.ITool tool, Action applyCallback, Action cancelCallback)
        {
            this.applyCallback = applyCallback;
            this.cancelCallback = cancelCallback;
            this.Visibility = Visibility.Visible;
        }
        private void CallApplyCallback()
        {
            this.applyCallback();
        }

        private void CallCancelCallback()
        {
            this.cancelCallback();
        }
    }
}
