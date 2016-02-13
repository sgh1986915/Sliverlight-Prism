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
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    public partial class CompanyImageEditView : UserControl
    {
        private Storyboard FadeIn;
        private Storyboard FadeOut;
        public CompanyImageEditView()
        {
            InitializeComponent();
            this.FadeIn = (Storyboard)this.LayoutRoot.Resources["FadeIn"];
            this.FadeOut = (Storyboard)this.LayoutRoot.Resources["FadeOut"];

            this.imageEditor.ToolSettingsContainer = this.settingsContainer;
           
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.FadeOut.Stop();
            this.FadeIn.Begin();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.FadeIn.Stop();
            this.FadeOut.Begin();
        }

       
    }
}

